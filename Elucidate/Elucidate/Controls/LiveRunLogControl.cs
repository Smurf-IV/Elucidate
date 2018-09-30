using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Elucidate.HelperClasses;
using Elucidate.Logging;
using Elucidate.wyDay.Controls;

using ScintillaNET;

namespace Elucidate.Controls
{
    public partial class LiveRunLogControl : UserControl
    {
        public bool HighlightErrorEnabled { get; set; } = true;
        public bool HighlightWarningEnabled { get; set; } = true;
        public bool HighlightDebugEnabled { get; set; } = true;
        
        // ReSharper disable once InconsistentNaming
        private const int MAX_COMMAND_ARG_LENGTH = 7000;

        private bool IsCommandLineOptionsEnabled { get; set; }

        private readonly LexerNlog _lexerNlog = new LexerNlog(
            keywordsError: new[] { "ERROR", "FATAL" },
            keywordsWarning: new[] { "WARN" },
            keywordsDebug: new[] { "DEBUG", "TRACE" });

        /// <summary>
        /// eventing idea taken from http://stackoverflow.com/questions/1423484/using-bashcygwin-inside-c-program
        /// </summary>
        private readonly ManualResetEvent _mreProcessExit = new ManualResetEvent(false);
        private readonly ManualResetEvent _mreOutputDone = new ManualResetEvent(false);
        private readonly ManualResetEvent _mreErrorDone = new ManualResetEvent(false);
        private ProcessPriorityClass _requested = ProcessPriorityClass.Normal;
        private string _lastError;
        private List<string> _batchPaths;

        public bool IsRunning { get; set; }
        private CommandType CommandTypeRunning { get; set; }

        public LiveRunLogControl()
        {
            InitializeComponent();

            AddThreadingCallbacks();

            toolStripStatusLabel1.Text = DateTime.Now.ToString("u");

            IsRunning = false;

            timerScantilla.Enabled = false;

            comboBoxProcessStatus.Enabled = false;

            checkBoxDisplayOutput.Checked = Properties.Settings.Default.IsDisplayOutputEnabled;
            
            ConfigureScintillaControl();
        }

        private void ConfigureScintillaControl()
        {
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll();

            scintilla.Styles[LexerNlog.StyleDefault].ForeColor = Color.Black;
            scintilla.Styles[LexerNlog.StyleError].ForeColor = Color.White;
            scintilla.Styles[LexerNlog.StyleError].BackColor = Color.Firebrick;
            scintilla.Styles[LexerNlog.StyleError].Bold = true;
            scintilla.Styles[LexerNlog.StyleWarning].ForeColor = Color.White;
            scintilla.Styles[LexerNlog.StyleWarning].BackColor = Color.DarkOrange;
            scintilla.Styles[LexerNlog.StyleWarning].Bold = true;
            scintilla.Styles[LexerNlog.StyleDebug].ForeColor = Color.Gray;

            scintilla.Lexer = Lexer.Container;
        }

        public event EventHandler TaskStarted;

        private void OnTaskStarted(EventArgs e)
        {
            EventHandler handler = TaskStarted;
            handler?.Invoke(this, e);
        }

        public event EventHandler TaskCompleted;

        private void OnTaskCompleted(EventArgs e)
        {
            EventHandler handler = TaskCompleted;
            handler?.Invoke(this, e);
        }
        
        private class ThreadObject
        {
            public BackgroundWorker BgdWorker;
            public Process CmdProcess;
        }

        public enum CommandType {
            Status,
            Diff,
            Check,
            Sync,
            Scrub,
            Fix,
            Dup,
            QuickCheck,
            RecoverCheck,
            RecoverFix,
            ForceFullSync
        }

        private void LiveRunLogControl_Load(object sender, EventArgs e)
        {
        }
        
        public void HideAdditionalCommands()
        {
            tableLayoutPanelAdditionalCommands.Visible = false;
        }

        public readonly BackgroundWorker ActionWorker = new BackgroundWorker
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true,
        };
        
        private void AddThreadingCallbacks()
        {
            // Add threading callbacks
            ActionWorker.DoWork += actionWorker_DoWork;
            ActionWorker.ProgressChanged += actionWorker_ProgressChanged;
            ActionWorker.RunWorkerCompleted += actionWorker_RunWorkerCompleted;
            comboBoxProcessStatus.Text = @"Stopped";
            comboBoxProcessStatus.Enabled = false;
        }

        internal void StartSnapRaidProcess(CommandType commandToRun, List<string> paths = null)
        {
            if (IsRunning)
            {
                Log.Instance.Debug("Command button clicked but a command is still running.");
                return;
            }

            CommandTypeRunning = commandToRun;

            timerScantilla.Enabled = true;
            
            StringBuilder command = new StringBuilder();

            switch (commandToRun)
            {
                case CommandType.Status:
                    command.Append(@"status ");
                    break;
                case CommandType.Diff:
                    command.Append(@"diff ");
                    break;
                case CommandType.QuickCheck:
                    command.Append(@"check ");
                    command.Append(!string.IsNullOrWhiteSpace(txtAddCommands.Text) ? txtAddCommands.Text : @"-a");
                    break;
                case CommandType.Check:
                case CommandType.RecoverCheck:
                    command.Append(@"check ");
                    break;
                case CommandType.Sync:
                    command.Append(@"sync ");
                    break;
                case CommandType.Scrub:
                    command.Append(@"scrub ");
                    command.Append(!string.IsNullOrWhiteSpace(txtAddCommands.Text) ? txtAddCommands.Text : @"-p100 -o0");
                    break;
                case CommandType.Fix:
                    command.Append(@"fix ");
                    command.Append(!string.IsNullOrWhiteSpace(txtAddCommands.Text) ? txtAddCommands.Text : @"-e");
                    break;
                case CommandType.Dup:
                    command.Append(@"dup ");
                    break;
                case CommandType.ForceFullSync:
                    command.Append(@"sync ");
                    command.Append(!string.IsNullOrWhiteSpace(txtAddCommands.Text) ? txtAddCommands.Text : @"-F");
                    break;
                case CommandType.RecoverFix:
                    command.Append(@"fix ");
                    if (paths != null) { _batchPaths = paths; }
                    break;
            }

            comboBoxProcessStatus.Enabled = true;

            comboBoxProcessStatus.Text = @"Running";

            _requested = ProcessPriorityClass.Normal;

            ActionWorker.RunWorkerAsync(command.ToString());
            
            toolStripProgressBar1.DisplayText = "Running...";

            toolStripProgressBar1.State = ProgressBarState.Normal;

            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

            toolStripProgressBar1.Value = 0;

            toolStripStatusLabel1.Text = DateTime.Now.ToString("u");

        }

        private void actionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                IsRunning = true;
                
                OnTaskStarted(e);

                BackgroundWorker worker = sender as BackgroundWorker;

                string command = e.Argument as string;

                _lastError = string.Empty;

                if (worker == null)
                {
                    Log.Instance.Error("Passed in worker is null");
                    e.Cancel = true;
                    return;
                }

                if (string.IsNullOrWhiteSpace(command))
                {
                    Log.Instance.Error("Passed in command is null");
                    e.Cancel = true;
                    return;
                }

                _mreProcessExit.Reset();
                _mreOutputDone.Reset();
                _mreErrorDone.Reset();

                string args = Util.FormatSnapRaidCommandArgs(
                    command: command,
                    additionalCommands: IsCommandLineOptionsEnabled ? txtAddCommands.Text : string.Empty, 
                    appPath: out string appPath);

                RunSnapRaid(e, args, appPath, worker);
            }
            catch (Exception ex)
            {
                _lastError = "Thread closing abnormally";
                ExceptionHandler.ReportException(ex, _lastError);
                throw;
            }
        }

        private void RunSnapRaid(DoWorkEventArgs e, string args, string appPath, BackgroundWorker worker)
        {
            Log.Instance.Info("#########################################");

            // RecoveryFix
            if (CommandTypeRunning == CommandType.RecoverFix)
            {
                StringBuilder sbPaths = new StringBuilder();

                do
                {
                    sbPaths.Append($"-f \"{_batchPaths[_batchPaths.Count - 1]}\" ");
                    _batchPaths.RemoveAt(_batchPaths.Count - 1);
                } while (sbPaths.Length < MAX_COMMAND_ARG_LENGTH && _batchPaths.Any());

                args += sbPaths.ToString();
            }

            int exitCode;

            using (Process process = new Process
            {
                StartInfo = new ProcessStartInfo(appPath, args)
                {
                    UseShellExecute = false, // We're redirecting !
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    StandardOutputEncoding = Encoding.UTF8, // SnapRAID uses UTF-8 for output
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true
                },
                EnableRaisingEvents = true
            })
            {
                Log.Instance.Info("Using: {0}", process.StartInfo.FileName);
                Log.Instance.Info("with: {0}", process.StartInfo.Arguments);

                process.Exited += Exited;

                process.Start();

                // Redirect the output stream of the child process.
                ThreadObject threadObject = new ThreadObject { BgdWorker = worker, CmdProcess = process };
                ThreadPool.QueueUserWorkItem(o => ReadStandardOutput(threadObject));
                ThreadPool.QueueUserWorkItem(o => ReadStandardError(threadObject));

                if (process.HasExited)
                {
                    _mreProcessExit.Set();
                }

                while (!WaitHandle.WaitAll(new WaitHandle[] { _mreErrorDone, _mreOutputDone, _mreProcessExit }, 250))
                {
                    if (process.HasExited)
                    {
                        continue;
                    }

                    if (worker.CancellationPending)
                    {
                        Log.Instance.Fatal("Attempting to stop the process..");
                        process.Kill();
                    }
                    else
                    {
                        ProcessPriorityClass current = process.PriorityClass;
                        if (current == _requested)
                        {
                            continue;
                        }

                        Log.Instance.Fatal("Setting the process priority to[{0}]", _requested);
                        process.PriorityClass = _requested;
                    }
                }

                exitCode = process.ExitCode;

                if (exitCode == 0)
                {
                    Log.Instance.Info("ExitCode=[{0}]", exitCode);
                    _lastError = string.Empty;
                }
                else
                {
                    Log.Instance.Error("ExitCode=[{0}]", exitCode);
                }

                process.Close();
            }

            switch (exitCode)
            {
                case 0:
                    break;
                case -1:
                    worker.ReportProgress(101, "Aborted");
                    break;
                case 1:
                    worker.ReportProgress(101, "Error");
                    break;
                case 2:
                    worker.ReportProgress(101, "Error");
                    break;
                default:
                    Log.Instance.Debug($"Unhandled ExitCode of {exitCode}");
                    break;
            }

            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
        }
        
        private void actionWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progressPercentage = e.ProgressPercentage;

            if (progressPercentage == 101)
            {
                _lastError = e.UserState.ToString();
            }

            if (toolStripProgressBar1.Style == ProgressBarStyle.Marquee)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            }

            if (progressPercentage < 101)
            {
                // even if snapraid is reporting 100%, it may still be running so only100% is only shown in RunWorkerCompleted
                toolStripProgressBar1.Value = progressPercentage == 100 ? 99 : e.ProgressPercentage;
            }
            else if (e.ProgressPercentage == 101)
            {
                toolStripProgressBar1.State = ProgressBarState.Error;
                toolStripProgressBar1.Value = 100;
            }
        }

        private void actionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsRunning = false;
            
            // continue running additional times if there is more work to be done
            if (CommandTypeRunning == CommandType.RecoverFix && _batchPaths.Any())
            {
                StartSnapRaidProcess(CommandType.RecoverFix);
                return;
            }

            OnTaskCompleted(e);

            comboBoxProcessStatus.Enabled = false;
            IsCommandLineOptionsEnabled = checkBoxCommandLineOptions.Checked = false; // uncheck so the next command does not include this by accident
            checkBoxCommandLineOptions.Enabled = true;
            
            if (toolStripProgressBar1.Style == ProgressBarStyle.Marquee)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            }
            if (e.Cancelled)
            {
                toolStripProgressBar1.State = ProgressBarState.Pause;
                toolStripProgressBar1.DisplayText = "Cancelled";
                Log.Instance.Error("The thread has been cancelled");
                comboBoxProcessStatus.Text = @"Abort";
            }
            else if (e.Error != null)
            {
                toolStripProgressBar1.State = ProgressBarState.Error;
                toolStripProgressBar1.DisplayText = "Error";
                Log.Instance.Error(e.Error, "Thread threw: ");
                comboBoxProcessStatus.Text = @"Abort";
            }
            else
            {
                if (toolStripProgressBar1.State == ProgressBarState.Normal)
                {
                    toolStripProgressBar1.DisplayText = "Completed";
                    toolStripProgressBar1.Value = 100;
                    comboBoxProcessStatus.Text = @"Stopped";
                }
                
                if (CommandTypeRunning == CommandType.RecoverCheck || CommandTypeRunning == CommandType.RecoverFix)
                {
                    toolStripProgressBar1.State = ProgressBarState.Normal;
                    toolStripProgressBar1.DisplayText = "Completed";
                    toolStripProgressBar1.Value = 100;
                    comboBoxProcessStatus.Text = @"Completed";
                }
                else
                {
                    if (string.IsNullOrEmpty(_lastError))
                    {
                        return;
                    }

                    toolStripProgressBar1.DisplayText = "Error";
                    Log.Instance.Debug($"Last Error: {_lastError}");
                }
            }

        }

        private void timerScantillaTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Now lock in case the timer is overlapping !
                lock (this)
                {
                    if (!ActionWorker.IsBusy)
                    {
                        timerScantilla.Enabled = false;
                    }

                    if (!LiveLog.LogQueueCommon.Any())
                    {
                        return;
                    }

                    while (LiveLog.LogQueueCommon.Any())
                    {
                        LiveLog.LogString log = LiveLog.LogQueueCommon.Dequeue();

                        if (!checkBoxDisplayOutput.Checked)
                        {
                            continue;
                        }

                        scintilla.AppendText($"{log.Message}{Environment.NewLine}");
                    }

                    // scroll to the bottom

                    int scintillaTextLength = scintilla.TextLength;

                    scintilla.ScrollRange(scintillaTextLength, scintillaTextLength);
                }
            }
            catch
            {
                // ignored
            }
        }

        private void ReadStandardError(ThreadObject threadObject)
        {
            try
            {
                string buf;
                do
                {
                    buf = threadObject.CmdProcess.StandardError.ReadLine();

                    if (string.IsNullOrEmpty(buf) || buf.StartsWith("Reading data from missing file"))
                    {
                        continue; // skip verbose messages from file recovery
                    }

                    _lastError = buf;

                    Log.Instance.Warn(_lastError);

                } while (!string.IsNullOrEmpty(buf));
            }
            catch (Exception ex)
            {
                _lastError = "Thread closing abnormally";
                ExceptionHandler.ReportException(ex, _lastError);
            }

            _mreErrorDone.Set();
        }

        private void ReadStandardOutput(ThreadObject threadObject)
        {
            try
            {
                string buf;
                do
                {
                    if (string.IsNullOrEmpty(buf = threadObject.CmdProcess.StandardOutput.ReadLine()))
                    {
                        continue;
                    }

                    Log.Instance.Info($"StdOut[{buf}]");

                    if (!buf.Contains("%"))
                    {
                        continue;
                    }

                    string[] splits = buf.Split('%');

                    if (int.TryParse(splits[0], out int percentProgress))
                    {
                        threadObject.BgdWorker.ReportProgress(percentProgress, buf);
                    }

                } while (!string.IsNullOrEmpty(buf));
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex, "ReadStandardOutput: ");
            }

            _mreOutputDone.Set();
        }

        private void Exited(object o, EventArgs e)
        {
            Log.Instance.Debug("Process has exited");
            _mreProcessExit.Set();
        }

        private void scintilla_StyleNeeded(object sender, StyleNeededEventArgs e)
        {
            if (scintilla == null)
            {
                return;
            }

            lock (scintilla)
            {

                int startPos = scintilla.GetEndStyled();

                int endPos = e.Position;

                _lexerNlog.Style(scintilla, startPos, endPos);
            }
        }

        private void checkBoxDisplayOutput_MouseHover(object sender, EventArgs e)
        {
            if (sender is CheckBox senderControl)
            {
                senderControl.BackColor = Color.LightSteelBlue;
            }
        }

        private void checkBoxDisplayOutput_MouseLeave(object sender, EventArgs e)
        {
            if (sender is CheckBox senderControl)
            {
                senderControl.BackColor = Color.Empty;
            }
        }

        private void checkBoxCommandLineOptions_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox senderControl)
            {
                IsCommandLineOptionsEnabled = senderControl.Checked;
            }
        }

        private void comboBoxProcessStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            ComboBox control = (ComboBox)sender;

            string strSelected = control.SelectedItem.ToString();

            switch (strSelected)
            {
                case "Stopped":
                    if (ActionWorker.IsBusy)
                    {
                        comboBoxProcessStatus.SelectedIndex = comboBoxProcessStatus.FindStringExact("Running");
                    }
                    break;
                case "Abort":
                    ActionWorker.CancelAsync();
                    Log.Instance.Info("Cancelling the running process...");
                    break;
            }
        }

        private void LiveRunLogControl_Resize(object sender, EventArgs e)
        {
            toolStripProgressBar1.Width = 100;
        }
    }
}
