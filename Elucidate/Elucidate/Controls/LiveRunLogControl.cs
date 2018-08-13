using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.IO;
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
        private readonly LexerNlog _lexerNlog = new LexerNlog(
            keywordsError: new[] { "ERROR", "FATAL" },
            keywordsWarning: new[] { "WARN" },
            keywordsDebug: new[] { "DEBUG", "TRACE" });

        public LiveRunLogControl()
        {
            InitializeComponent();
            AddThreadingCallbacks();
            IsRunning = false;
            timer1.Enabled = false;
            comboBox1.Enabled = false;
            runWithoutCaptureMenuItem.Checked = Properties.Settings.Default.RunWithoutCapture;
            
            // size the margin for the line numbers
            //var maxLineNumberCharLength = scintilla.Lines.Count.ToString().Length;
            //const int padding = 2;
            //scintilla.Margins[0].Width = scintilla.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;

            scintilla.StyleResetDefault();
            //scintilla.Styles[Style.Default].Font = "Lucida Grande";
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
            comboBox1.Text = @"Stopped";
            comboBox1.Enabled = false;
        }

        internal void StartSnapRaidProcess(CommandType commandToRun, List<string> paths = null)
        {
            if (IsRunning)
            {
                Log.Instance.Debug("Command button clicked but a command is still running.");
                return;
            }

            CommandTypeRunning = commandToRun;
            timer1.Enabled = true;
            //UseWaitCursor = true;
            
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

            comboBox1.Enabled = true;
            comboBox1.Text = @"Running";
            _requested = ProcessPriorityClass.Normal;
            ActionWorker.RunWorkerAsync(command.ToString());
            toolStripStatusLabel1.Text = DateTime.Now.ToString("u");
            toolStripProgressBar1.DisplayText = "Running...";
            toolStripProgressBar1.State = ProgressBarState.Normal;
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.Value = 0;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // Now lock in case the timer is overlapping !
                lock (this)
                {
                    if (!LiveLog.LogQueueCommon.Any()) return;

                    while (LiveLog.LogQueueCommon.Any())
                    {
                        LiveLog.LogString log = LiveLog.LogQueueCommon.Dequeue();
                        scintilla.AppendText($"{log.Message}{Environment.NewLine}");
                    }

                    //scintillaNET.SetSel(scintillaNET.TextLength, scintillaNET.TextLength);
                    //scintillaNET.ScrollCaret();
                    int scintillaTextLength = scintilla.TextLength;
                    scintilla.ScrollRange(scintillaTextLength, scintillaTextLength);
                }
            }
            catch
            {
                // ignored
            }
        }

        private void actionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                IsRunning = true;
                OnTaskStarted(e);

                Log.Instance.Debug("actionWorker_DoWork");
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

                string args = Util.FormatSnapRaidCommandArgs(command, txtAddCommands.Text, out string appPath);

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
            int exitCode;

            // RecoveryFix
            if (CommandTypeRunning == CommandType.RecoverFix)
            {
                StringBuilder sbPaths = new StringBuilder();
                do
                {
                    sbPaths.Append($"-f \"{_batchPaths[_batchPaths.Count - 1]}\" ");
                    _batchPaths.RemoveAt(_batchPaths.Count - 1);
                } while (sbPaths.Length < 7000 && _batchPaths.Any());

                args += sbPaths.ToString();
            }

            if (runWithoutCaptureMenuItem.Checked)
            {
                Log.Instance.Warn("Running without Capture mode");
                Log.Instance.Info("Starting minimised {0} {1}", appPath, args);
                Log.Instance.Info("Working...");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "CMD.exe",
                    Arguments = $" /C \"{appPath} {args}\"",
                    WorkingDirectory = $"{Path.GetDirectoryName(Properties.Settings.Default.SnapRAIDFileLocation)}",
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Minimized,
                    ErrorDialog = true
                };
                Process process = Process.Start(startInfo);
                if (process != null) Log.Instance.Info("Process is running PID[{0}]", process.Id);
                return;
            }

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
                ThreadObject threadObject = new ThreadObject {BgdWorker = worker, CmdProcess = process};
                ThreadPool.QueueUserWorkItem(o => ReadStandardOutput(threadObject));
                ThreadPool.QueueUserWorkItem(o => ReadStandardError(threadObject));

                if (process.HasExited)
                {
                    _mreProcessExit.Set();
                }

                while (!WaitHandle.WaitAll(new WaitHandle[] {_mreErrorDone, _mreOutputDone, _mreProcessExit}, 250))
                {
                    if (process.HasExited) continue;
                    if (worker.CancellationPending)
                    {
                        Log.Instance.Fatal("Attempting process KILL");
                        process.Kill();
                    }
                    else
                    {
                        ProcessPriorityClass current = process.PriorityClass;
                        if (current == _requested) continue;
                        Log.Instance.Fatal("Setting the processpriority to[{0}]", _requested);
                        process.PriorityClass = _requested;
                    }
                }

                exitCode = process.ExitCode;
                if (exitCode == 0)
                {
                    Log.Instance.Info("ExitCode=[{0}]", exitCode);
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
                case 1:
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
            if (toolStripProgressBar1.Style == ProgressBarStyle.Marquee)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            }
            if (e.ProgressPercentage < 101)
            {
                toolStripProgressBar1.Value = e.ProgressPercentage;
            }
            else if (e.ProgressPercentage == 101)
            {
                toolStripProgressBar1.State = ProgressBarState.Error;
                toolStripProgressBar1.Value = 100;
                _lastError = e.UserState.ToString();
            }
        }

        private void actionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //UseWaitCursor = false;
            //ElucidateForm.SetCommonButtonsEnabledState(true);
            
            IsRunning = false;

            // continue running additional times if there is more work to be done
            if (CommandTypeRunning == CommandType.RecoverFix && _batchPaths.Any())
            {
                StartSnapRaidProcess(CommandType.RecoverFix);
                return;
            }

            OnTaskCompleted(e);
            comboBox1.Enabled = false;
            timer1.Enabled = false;
            
            if (toolStripProgressBar1.Style == ProgressBarStyle.Marquee)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            }
            if (e.Cancelled)
            {
                toolStripProgressBar1.State = ProgressBarState.Pause;
                toolStripProgressBar1.DisplayText = "Cancelled";
                Log.Instance.Error("The thread has been cancelled");
                comboBox1.Text = @"Abort";
            }
            else if (e.Error != null)
            {
                toolStripProgressBar1.State = ProgressBarState.Error;
                toolStripProgressBar1.DisplayText = "Error";
                Log.Instance.Error(e.Error, "Thread threw: ");
                comboBox1.Text = @"Abort";
            }
            else
            {
                if (toolStripProgressBar1.State == ProgressBarState.Normal)
                {
                    toolStripProgressBar1.DisplayText = "Completed";
                    toolStripProgressBar1.Value = 100;
                    comboBox1.Text = @"Stopped";
                }
            }

            if (CommandTypeRunning == CommandType.RecoverCheck || CommandTypeRunning == CommandType.RecoverFix)
            {
                toolStripProgressBar1.State = ProgressBarState.Normal;
                toolStripProgressBar1.DisplayText = "Completed";
                toolStripProgressBar1.Value = 100;
                comboBox1.Text = @"Completed";
            }
            else
            {
                if (string.IsNullOrEmpty(_lastError)) return;
                toolStripProgressBar1.DisplayText = "Error";
                Log.Instance.Info($"Last Error: {_lastError}");
            }
        }

        private void ReadStandardError(ThreadObject threadObject)
        {
            try
            {
                Log.Instance.Info("Start Verbose handler");
                string buf;
                do
                {
                    if (!string.IsNullOrEmpty(buf = threadObject.CmdProcess.StandardError.ReadLine()))
                    {
                        _lastError = buf;
                        Log.Instance.Warn($"Verbose[{_lastError}]");
                    }
                    else
                    {
                        _mreProcessExit.WaitOne(100);
                    }
                } while (!string.IsNullOrEmpty(buf)
                         || !_mreProcessExit.WaitOne(0) // If millisecondsTimeout is zero, the method does not block. It tests the state of the wait handle and returns immediately.
                );
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
                Log.Instance.Debug("Start StdOut handler");
                string buf;
                do
                {
                    if (!string.IsNullOrEmpty(buf = threadObject.CmdProcess.StandardOutput.ReadLine()))
                    {
                        Log.Instance.Info($"StdOut[{buf}]");
                        if (!buf.Contains("%")) continue;
                        string[] splits = buf.Split('%');
                        if (int.TryParse(splits[0], out int percentProgress))
                        {
                            threadObject.BgdWorker.ReportProgress(percentProgress, buf);
                        }
                    }
                    else
                    {
                        _mreProcessExit.WaitOne(100);
                    }
                } while (!string.IsNullOrEmpty(buf)
                         || !_mreProcessExit.WaitOne(0) // If millisecondsTimeout is zero, the method does not block. It tests the state of the wait handle and returns immediately.
                );
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex, "ReadStandardOutput: ");
            }
            _mreOutputDone.Set();
        }

        private void Exited(object o, EventArgs e)
        {
            Log.Instance.Debug("Exited.");
            Thread.Sleep(1000);  // When the process has exited, the buffers are _still_ flushing
            _mreProcessExit.Set();
        }

        private void scintilla_StyleNeeded(object sender, StyleNeededEventArgs e)
        {
            if (scintilla == null) return;

            lock (scintilla)
            {
                var startPos = scintilla.GetEndStyled();
                var endPos = e.Position;
                _lexerNlog.Style(scintilla, startPos, endPos);
            }
        }
    }
}
