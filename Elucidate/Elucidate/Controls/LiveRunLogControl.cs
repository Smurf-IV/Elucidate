#region Copyright (C)
//  <copyright file="ConfigFileHelper.cs" company="Smurf-IV">
//
//  Copyright (C) 2018-2019 Smurf-IV & BlueBlock
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 2 of the License, or
//   any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see http://www.gnu.org/licenses/.
//  </copyright>
//  <summary>
//  Url: https://github.com/Smurf-IV/Elucidate
//  Email: https://github.com/Smurf-IV
//  </summary>
#endregion Copyright (C)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Elucidate.wyDay.Controls;

using NLog;

namespace Elucidate.Controls
{
    public partial class LiveRunLogControl : UserControl
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        // ReSharper disable once InconsistentNaming
        private const int MAX_COMMAND_ARG_LENGTH = 7000;

        private bool IsCommandLineOptionsEnabled { get; set; }

        /// <summary>
        /// eventing idea taken from http://stackoverflow.com/questions/1423484/using-bashcygwin-inside-c-program
        /// </summary>
        private readonly ManualResetEvent mreProcessExit = new ManualResetEvent(false);
        private readonly ManualResetEvent mreOutputDone = new ManualResetEvent(false);
        private readonly ManualResetEvent mreErrorDone = new ManualResetEvent(false);
        private ProcessPriorityClass requested = ProcessPriorityClass.Normal;
        private string lastError;
        private List<string> batchPaths;
        private static ListBoxLog listBoxLog;

        public bool IsRunning { get; set; }
        private CommandType CommandTypeRunning { get; set; }

        public LiveRunLogControl()
        {
            InitializeComponent();

            listBoxLog = new ListBoxLog(rtbLiveLog);

            AddThreadingCallbacks();

            toolStripStatusLabel1.Text = DateTime.Now.ToString("u");

            IsRunning = false;

            comboBoxProcessStatus.Enabled = false;

            checkBoxDisplayOutput.Checked = Properties.Settings.Default.IsDisplayOutputEnabled;
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
                Log.Debug("Command button clicked but a command is still running.");
                return;
            }

            CommandTypeRunning = commandToRun;

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
                    if (paths != null) { batchPaths = paths; }
                    break;
            }

            comboBoxProcessStatus.Enabled = true;

            comboBoxProcessStatus.Text = @"Running";

            requested = ProcessPriorityClass.Normal;

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

                lastError = string.Empty;

                if (worker == null)
                {
                    Log.Error("Passed in worker is null");
                    e.Cancel = true;
                    return;
                }

                if (string.IsNullOrWhiteSpace(command))
                {
                    Log.Error("Passed in command is null");
                    e.Cancel = true;
                    return;
                }

                mreProcessExit.Reset();
                mreOutputDone.Reset();
                mreErrorDone.Reset();

                string args = Util.FormatSnapRaidCommandArgs(
                    command: command,
                    additionalCommands: IsCommandLineOptionsEnabled ? txtAddCommands.Text : string.Empty, 
                    appPath: out string appPath);

                RunSnapRaid(e, args, appPath, worker);
            }
            catch (Exception ex)
            {
                lastError = "Thread closing abnormally";
                Log.Fatal(ex, @"Failed to attach unhandled exception handler...");
                throw;
            }
        }

        private void RunSnapRaid(DoWorkEventArgs e, string args, string appPath, BackgroundWorker worker)
        {
            Log.Info("#########################################");

            // RecoveryFix
            if (CommandTypeRunning == CommandType.RecoverFix)
            {
                StringBuilder sbPaths = new StringBuilder();

                do
                {
                    sbPaths.Append($"-f \"{batchPaths[batchPaths.Count - 1]}\" ");
                    batchPaths.RemoveAt(batchPaths.Count - 1);
                } while (sbPaths.Length < MAX_COMMAND_ARG_LENGTH && batchPaths.Any());

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
                Log.Info("Using: {0}", process.StartInfo.FileName);
                Log.Info("with: {0}", process.StartInfo.Arguments);

                process.Exited += Exited;

                process.Start();

                // Redirect the output stream of the child process.
                ThreadObject threadObject = new ThreadObject { BgdWorker = worker, CmdProcess = process };
                ThreadPool.QueueUserWorkItem(o => ReadStandardOutput(threadObject));
                ThreadPool.QueueUserWorkItem(o => ReadStandardError(threadObject));

                if (process.HasExited)
                {
                    mreProcessExit.Set();
                }

                while (!WaitHandle.WaitAll(new WaitHandle[] { mreErrorDone, mreOutputDone, mreProcessExit }, 250))
                {
                    if (process.HasExited)
                    {
                        continue;
                    }

                    if (worker.CancellationPending)
                    {
                        Log.Fatal("Attempting to stop the process..");
                        process.Kill();
                    }
                    else
                    {
                        ProcessPriorityClass current = process.PriorityClass;
                        if (current == requested)
                        {
                            continue;
                        }

                        Log.Fatal("Setting the process priority to[{0}]", requested);
                        process.PriorityClass = requested;
                    }
                }

                exitCode = process.ExitCode;

                if (exitCode == 0)
                {
                    Log.Info("ExitCode=[{0}]", exitCode);
                    lastError = string.Empty;
                }
                else
                {
                    Log.Error("ExitCode=[{0}]", exitCode);
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
                    Log.Debug($"Unhandled ExitCode of {exitCode}");
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
                lastError = e.UserState.ToString();
            }

            if (toolStripProgressBar1.Style == ProgressBarStyle.Marquee)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            }

            if (progressPercentage < 101)
            {
                // even if SnapRaid is reporting 100%, it may still be running so only100% is only shown in RunWorkerCompleted
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
            if (CommandTypeRunning == CommandType.RecoverFix && batchPaths.Any())
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
                Log.Error("The thread has been cancelled");
                comboBoxProcessStatus.Text = @"Abort";
            }
            else if (e.Error != null)
            {
                toolStripProgressBar1.State = ProgressBarState.Error;
                toolStripProgressBar1.DisplayText = "Error";
                Log.Error(e.Error, "Thread threw: ");
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
                    if (string.IsNullOrEmpty(lastError))
                    {
                        return;
                    }

                    toolStripProgressBar1.DisplayText = "Error";
                    Log.Debug($"Last Error: {lastError}");
                }
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

                    lastError = buf;

                    Log.Warn(lastError);

                } while (!string.IsNullOrEmpty(buf));
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, lastError);
            }

            mreErrorDone.Set();
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

                    Log.Info($"StdOut[{buf}]");

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
                Log.Fatal(ex, @"ReadStandardOutput: ");
            }

            mreOutputDone.Set();
        }

        private void Exited(object o, EventArgs e)
        {
            Log.Debug("Process has exited");
            mreProcessExit.Set();
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
                    Log.Info("Cancelling the running process...");
                    break;
            }
        }

        private void LiveRunLogControl_Resize(object sender, EventArgs e)
        {
            toolStripProgressBar1.Width = 100;
        }


        // ReSharper disable UnusedMember.Global
        // This is used by the logging to force all to the output window
        public static void LogMethod(string levelUppercase, string message)
        {
            listBoxLog?.LogMethod(levelUppercase, message);
        }
    }
}
