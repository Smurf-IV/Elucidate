#region Copyright (C)
//  <copyright file="RunControl.cs" company="Smurf-IV">
//
//  Copyright (C) 2018-2021 Smurf-IV & BlueBlock 2018
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Elucidate.wyDay.Controls;

using Krypton.Toolkit;

using NLog;

namespace Elucidate.Controls
{
    public partial class RunControl : UserControl
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        // ReSharper disable once InconsistentNaming
        private const int MAX_COMMAND_ARG_LENGTH = 7000;

        /// <summary>
        /// eventing idea taken from http://stackoverflow.com/questions/1423484/using-bashcygwin-inside-c-program
        /// </summary>
        private readonly ManualResetEvent mreProcessExit = new (false);

        private readonly ManualResetEvent mreOutputDone = new (false);
        private readonly ManualResetEvent mreErrorDone = new (false);
        private ProcessPriorityClass requested = ProcessPriorityClass.Normal;
        private string lastError;
        private Stack<string> batchPaths;

        public bool IsRunning { get; private set; }

        public CommandType CommandTypeRunning { get; private set; }

        public RunControl()
        {
            InitializeComponent();

            AddThreadingCallbacks();

            tsStartTime.Text = DateTime.Now.ToString("G");

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

        public enum CommandType
        {
            Status,
            Diff,
            Check,
            Sync,
            Scrub,
            Fix,
            Dup,
            CheckForMissing,
            RecoverFix,
            ForceFullSync
        }

        private void LiveRunLogControl_Load(object sender, EventArgs e)
        {
        }

        private readonly BackgroundWorker actionWorker = new ()
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };

        private void AddThreadingCallbacks()
        {
            // Add threading callbacks
            actionWorker.DoWork += actionWorker_DoWork;
            actionWorker.ProgressChanged += actionWorker_ProgressChanged;
            actionWorker.RunWorkerCompleted += actionWorker_RunWorkerCompleted;
            comboBoxProcessStatus.Text = @"Stopped";
            comboBoxProcessStatus.Enabled = false;
        }

        internal void StartSnapRaidProcess(CommandType commandToRun, Stack<string> paths = null)
        {
            if (IsRunning)
            {
                Log.Debug(@"Command button clicked but a command is still running.");
                return;
            }

            CommandTypeRunning = commandToRun;

            var command = new StringBuilder();
            var defaultOption = string.Empty;

            switch (commandToRun)
            {
                case CommandType.Status:
                    command.Append(@"status");
                    break;
                case CommandType.Diff:
                    command.Append(@"diff");
                    break;
                case CommandType.CheckForMissing:
                    command.Append(@"check");
                    defaultOption = @" -m";
                    break;
                case CommandType.Check:
                    command.Append(@"check");
                    defaultOption = @" -a";
                    break;
                case CommandType.Sync:
                    command.Append(@"sync");
                    break;
                case CommandType.Scrub:
                    command.Append(@"scrub");
                    defaultOption = @" -p100 -o0";
                    break;
                case CommandType.Fix:
                    command.Append(@"fix");
                    defaultOption = @" -e";
                    break;
                case CommandType.Dup:
                    command.Append(@"dup");
                    break;
                case CommandType.ForceFullSync:
                    command.Append(@"sync");
                    defaultOption = @" -F";
                    break;
                case CommandType.RecoverFix:
                    command.Append(@"fix");
                    if (paths != null)
                    {
                        batchPaths = paths;
                    }

                    break;
            }

            if (checkBoxCommandLineOptions.Checked)
            {
                var addCmd = txtAddCommands.Text;
                if (addCmd.StartsWith(@"+"))
                {
                    addCmd = addCmd.TrimStart(@"+".ToCharArray());
                }
                else
                {
                    command.Append(defaultOption);
                }

                command.Append(' ').Append(addCmd);
            }
            else
            {
                command.Append(defaultOption);
            }

            comboBoxProcessStatus.Enabled = true;

            comboBoxProcessStatus.Text = @"Running";

            requested = ProcessPriorityClass.Normal;

            actionWorker.RunWorkerAsync(command.ToString());

            toolStripProgressBar1.DisplayText = "Running...";

            toolStripProgressBar1.State = ProgressBarState.Normal;

            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

            toolStripProgressBar1.Value = 0;

            tsStartTime.Text = DateTime.Now.ToString("G");

        }

        private void actionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var command = e.Argument as string;

                lastError = string.Empty;

                if (sender is not BackgroundWorker worker)
                {
                    Log.Error(@"Passed in worker is null");
                    e.Cancel = true;
                    return;
                }

                if (string.IsNullOrWhiteSpace(command))
                {
                    Log.Error(@"Passed in command is null");
                    e.Cancel = true;
                    return;
                }

                mreProcessExit.Reset();
                mreOutputDone.Reset();
                mreErrorDone.Reset();

                var args = Util.FormatSnapRaidCommandArgs(command, out var appPath);

                IsRunning = true;

                OnTaskStarted(e);

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
            Log.Info(@"#########################################");

            // RecoveryFix
            if (CommandTypeRunning == CommandType.RecoverFix)
            {
                var sbPaths = new StringBuilder();

                do
                {
                    var restore = batchPaths.Pop();
                    sbPaths.Append(" -f \"").Append(restore).Append('"');
                } while ((sbPaths.Length < MAX_COMMAND_ARG_LENGTH)
                         && (batchPaths.Count > 0)
                );

                args += sbPaths.ToString();
            }

            int exitCode;

            using (var process = new Process
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
                Log.Info(@"Using: [{0}]", process.StartInfo.FileName);
                Log.Info(@"with: [{0}]", process.StartInfo.Arguments);

                process.Exited += Exited;

                process.Start();

                // Redirect the output stream of the child process.
                var threadObject = new ThreadObject { BgdWorker = worker, CmdProcess = process };
                ThreadPool.QueueUserWorkItem(_ => ReadStandardOutput(threadObject));
                ThreadPool.QueueUserWorkItem(_ => ReadStandardError(threadObject));

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
                        Log.Fatal(@"Attempting to stop the process..");
                        process.Kill();
                    }
                    else
                    {
                        ProcessPriorityClass current = process.PriorityClass;
                        if (current == requested)
                        {
                            continue;
                        }
                        if (current == ProcessPriorityClass.BelowNormal)
                        {
                            process.Resume();
                        }
                        else if (requested == ProcessPriorityClass.BelowNormal)
                        {
                            process.Suspend();
                        }

                        Log.Fatal(@"Setting the process priority to[{0}]", requested);
                        process.PriorityClass = requested;
                    }
                }

                exitCode = process.ExitCode;

                if (exitCode == 0)
                {
                    Log.Info(@"ExitCode=[{0}]", exitCode);
                    lastError = string.Empty;
                }
                else
                {
                    Log.Error(@"ExitCode=[{0}]", exitCode);
                }

                process.Close();
            }

            switch (exitCode)
            {
                case 0:
                    break;
                case -1:
                    worker.ReportProgress(101, "Aborted: Error code -1");
                    break;
                case 1:
                    if (CommandTypeRunning is CommandType.Check or CommandType.CheckForMissing
                        )
                    {
                        Log.Warn(@"Missing files have been reported, the process return code is 1, instead of the default 0");
                    }
                    else
                    {
                        worker.ReportProgress(101, "Error code 1");
                    }
                    break;
                case 2:
                    if (CommandTypeRunning == CommandType.Diff)
                    {
                        Log.Warn(@"A 'sync' is required, the process return code is 2, instead of the default 0");
                    }
                    else
                    {
                        worker.ReportProgress(101, "Error code 2");
                    }

                    break;
                default:
                    Log.Error(@"Unhandled ExitCode of [{0}]", exitCode);
                    break;
            }

            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void actionWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var progressPercentage = e.ProgressPercentage;

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
                toolStripProgressBar1.Value = progressPercentage == 100 ? 99 : progressPercentage;
                toolStripProgressBar1.DisplayText = e.UserState.ToString();
            }
            else if (progressPercentage == 101)
            {
                toolStripProgressBar1.State = ProgressBarState.Error;
                toolStripProgressBar1.DisplayText = lastError;
                toolStripProgressBar1.Value = 100;
            }
        }

        private void actionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsRunning = false;
            // continue running additional times if there is more work to be done
            if (CommandTypeRunning == CommandType.RecoverFix && (batchPaths.Count > 0))
            {
                StartSnapRaidProcess(CommandType.RecoverFix);
                return;
            }

            OnTaskCompleted(e);

            comboBoxProcessStatus.Enabled = false;
            checkBoxCommandLineOptions.Checked = false; // uncheck so the next command does not include this by accident
            checkBoxCommandLineOptions.Enabled = true;

            if (toolStripProgressBar1.Style == ProgressBarStyle.Marquee)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            }

            if (e.Cancelled)
            {
                toolStripProgressBar1.State = ProgressBarState.Pause;
                toolStripProgressBar1.DisplayText = "Cancelled";
                Log.Error(@"The thread has been cancelled");
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

                if (CommandTypeRunning is CommandType.Check or CommandType.CheckForMissing or CommandType.RecoverFix
                )
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
                    Log.Debug(@"Last Error: {lastError}", lastError);
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
                // No Resharper not in while loops
                // ReSharper disable once TooWideLocalVariableScope
                string buf;
                do
                {
                    buf = threadObject.CmdProcess.StandardOutput.ReadLine();
                    Log.Info(@"StdOut[{0}]", buf);
                    if (!string.IsNullOrWhiteSpace(buf))
                    {
                        var splits = buf.Split('%');
                        if ((splits.Length > 1)
                            && int.TryParse(splits[0], out var percentProgress)
                        )
                        {
                            threadObject.BgdWorker.ReportProgress(percentProgress, buf);
                        }
                    }
                    else
                    {
                        // SnapRaid dumps a null length when drawing graphs etc. So need to check if still running..
                        mreProcessExit.WaitOne(100);
                    }
                } while (!mreProcessExit.WaitOne(0)
                ); // If millisecondsTimeout is zero, the method does not block. It tests the state of the wait handle and returns immediately.
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, @"ReadStandardOutput: ");
            }

            mreOutputDone.Set();
        }

        private void Exited(object o, EventArgs e)
        {
            Log.Debug(@"Process has exited");
            mreProcessExit.Set();
        }

        private void checkBoxDisplayOutput_MouseHover(object sender, EventArgs e)
        {
            if (sender is KryptonCheckBox senderControl)
            {
                senderControl.BackColor = Color.LightSteelBlue;
            }
        }

        private void checkBoxDisplayOutput_MouseLeave(object sender, EventArgs e)
        {
            if (sender is KryptonCheckBox senderControl)
            {
                senderControl.BackColor = Color.Empty;
            }
        }

        private void comboBoxProcessStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            KryptonComboBox control = (KryptonComboBox)sender;

            var strSelected = control.SelectedItem.ToString();

            switch (strSelected)
            {
                case @"Stopped":
                    if (actionWorker.IsBusy)
                    {
                        comboBoxProcessStatus.SelectedIndex = comboBoxProcessStatus.FindStringExact(@"Running");
                    }
                    break;
                case @"Abort":
                    actionWorker.CancelAsync();
                    Log.Info(@"Cancelling the running process...");
                    break;
                case @"Idle":
                    requested = ProcessPriorityClass.Idle;
                    break;
                case @"Running":
                    requested = ProcessPriorityClass.Normal;
                    break;
                case @"Pause":
                    requested = ProcessPriorityClass.BelowNormal;
                    break;

            }
        }

    }

    // Taken from https://stackoverflow.com/questions/71257/suspend-process-in-c-sharp
    public static class ProcessExtension
    {
        [Flags]
        private enum ThreadAccess
        {
            Terminate = (0x0001),
            SuspendResume = (0x0002),
            GetContext = (0x0008),
            SetContext = (0x0010),
            SetInformation = (0x0020),
            QueryInformation = (0x0040),
            SetThreadToken = (0x0080),
            Impersonate = (0x0100),
            DirectImpersonation = (0x0200)
        }

        [DllImport(@"kernel32.dll")]
        private static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

        [DllImport(@"kernel32.dll")]
        private static extern uint SuspendThread(IntPtr hThread);

        [DllImport("kernel32.dll")]
        private static extern int ResumeThread(IntPtr hThread);

        public static void Suspend(this Process process)
        {
            foreach (IntPtr pOpenThread in (from ProcessThread thread in process.Threads 
                         select OpenThread(ThreadAccess.SuspendResume, false, (uint)thread.Id))
                        .TakeWhile(static pOpenThread => pOpenThread != IntPtr.Zero)
                        )
            {
                SuspendThread(pOpenThread);
            }
        }

        public static void Resume(this Process process)
        {
            foreach (IntPtr pOpenThread in (from ProcessThread thread in process.Threads 
                         select OpenThread(ThreadAccess.SuspendResume, false, (uint)thread.Id))
                        .TakeWhile(static pOpenThread => pOpenThread != IntPtr.Zero)
                        )
            {
                ResumeThread(pOpenThread);
            }
        }
    }
}
