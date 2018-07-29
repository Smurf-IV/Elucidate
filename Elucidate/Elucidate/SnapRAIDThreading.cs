#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="SnapRAIDThreading.cs" company="Smurf-IV">
//
//  Copyright (C) 2010-2017 Simon Coghlan (Aka Smurf-IV)
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
// --------------------------------------------------------------------------------------------------------------------

#endregion Copyright (C)

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NLog;
using NLog.Targets;
using NLog.Targets.Wrappers;
using wyDay.Controls;

namespace Elucidate
{
    public sealed partial class Elucidate
    {
        /// <summary>
        /// eventing idea taken from http://stackoverflow.com/questions/1423484/using-bashcygwin-inside-c-program
        /// </summary>
        private readonly ManualResetEvent mreProcessExit = new ManualResetEvent(false);

        private readonly ManualResetEvent mreOutputDone = new ManualResetEvent(false);
        private readonly ManualResetEvent mreErrorDone = new ManualResetEvent(false);
        private ProcessPriorityClass requested = ProcessPriorityClass.Normal;

        private readonly BackgroundWorker actionWorker = new BackgroundWorker
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true,
        };

        private class ThreadObject
        {
            public BackgroundWorker bgdWorker;
            public Process cmdProcess;
        }

        private void actionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Log.Debug("actionWorker_DoWork");
                BackgroundWorker worker = sender as BackgroundWorker;
                string command = e.Argument as string;

                if (worker == null)
                {
                    Log.Error("Passed in worker is null");
                    e.Cancel = true;
                    return;
                }
                else if (string.IsNullOrWhiteSpace(command))
                {
                    Log.Error("Passed in command is null");
                    e.Cancel = true;
                    return;
                }

                int exitCode;
                mreProcessExit.Reset();
                mreOutputDone.Reset();
                mreErrorDone.Reset();
                string args = FormatSnapRaidCommandArgs(command, out string appPath);
                if (runWithoutCaptureMenuItem.Checked)
                {
                    Log.Warn("Running without Capture mode");

                    FileTarget fileTarget = (FileTarget)((AsyncTargetWrapper)LogManager.Configuration.FindTargetByName("file")).WrappedTarget;
                    // Need to set timestamp here if filename uses date.
                    // For example - filename="${basedir}/logs/${shortdate}/trace.log"
                    LogEventInfo logEventInfo = new LogEventInfo { TimeStamp = DateTime.Now };
                    FileInfo fi = new FileInfo(fileTarget.FileName.Render(logEventInfo));
                    args += string.Format(" 2> \"{0}\\Verbose-{1}.log\"", fi.DirectoryName, DateTime.UtcNow.ToString("yyyy-MM-dd HH.mm"));
                    Log.Info("Starting minimised {0} {1}", appPath, args);
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = "CMD.exe",
                        Arguments = string.Format(" /K \"{0} {1}\"", appPath, args),
                        WorkingDirectory = @"C:\windows\System32",
                        UseShellExecute = true,
                        WindowStyle = ProcessWindowStyle.Minimized,
                        ErrorDialog = true
                    };
                    Process process = Process.Start(startInfo);
                    Log.Info("Process is running PID[{0}]", process.Id);
                    return;
                }

                using (Process process = new Process
                {
                    StartInfo = new ProcessStartInfo(appPath, args)
                    {
                        UseShellExecute = false,      // We're redirecting !
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        StandardOutputEncoding = Encoding.UTF8,   // SnapRAID uses UTF-8 for output
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
                    ThreadObject threadObject = new ThreadObject { bgdWorker = worker, cmdProcess = process };
                    ThreadPool.QueueUserWorkItem(o => ReadStandardOutput(threadObject));
                    ThreadPool.QueueUserWorkItem(o => ReadStandardError(threadObject));

                    if (process.HasExited)
                    {
                        mreProcessExit.Set();
                    }

                    while (!WaitHandle.WaitAll(new WaitHandle[] { mreErrorDone, mreOutputDone, mreProcessExit }, 250))
                    {
                        if (process.HasExited) continue;
                        if (worker.CancellationPending)
                        {
                            Log.Fatal("Attempting process KILL");
                            process.Kill();
                        }
                        else
                        {
                            ProcessPriorityClass current = process.PriorityClass;
                            if (current == requested) continue;
                            Log.Fatal("Setting the processpriority to[{0}]", requested);
                            process.PriorityClass = requested;
                        }
                    }

                    exitCode = process.ExitCode;
                    Log.Info("ExitCode=[{0}]", exitCode);
                    process.Close();
                }
                switch (exitCode)
                {
                    case 0:
                        break;

                    case 1:
                        worker.ReportProgress(101, "Error");
                        break;
                }
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex, "Thread closing abnormally");
                throw;
            }
            finally
            {
                Log.Info("We are exiting the status thread");
            }
        }

        private string FormatSnapRaidCommandArgs(string command, out string appPath)
        {
            // Format according to this: http://snapraid.sourceforge.net/manual.html
            // e.g. "D:\snapraid-1.3-windows-x64\snapraid" -c "D:\snapraid-1.3-windows-x64\snapraid.conf" sync
            appPath = string.Format("\"{0}\"", Properties.Settings.Default.SnapRAIDFileLocation);
            // Find the meanings @ http://snapraid.sourceforge.net/manual.html  6 Options
            StringBuilder args = new StringBuilder(txtAddCommands.Text);
            args.Append(' ');
            if (Properties.Settings.Default.UseVerboseMode)
            {
                args.Append("-v ");
            }
            if (Properties.Settings.Default.UseGUIMode)
            {
                args.Append("-G ");
            }
            if (Properties.Settings.Default.FindByNameInSync)
            {
                args.Append("-N ");
            }
            args.AppendFormat("-c \"{0}\" {1}", Properties.Settings.Default.ConfigFileLocation, command.ToLower());
            return args.ToString();
        }

        private string lastError;

        private void ReadStandardError(ThreadObject threadObject)
        {
            try
            {
                Log.Warn("Start Verbose handler");
                string buf;
                do
                {
                    if (!string.IsNullOrEmpty(buf = threadObject.cmdProcess.StandardError.ReadLine()))
                    {
                        lastError = buf;
                        Log.Warn("Verbose[{0}]", buf);
                    }
                    else
                    {
                        mreProcessExit.WaitOne(100);
                    }
                } while (!string.IsNullOrEmpty(buf)
                   || !mreProcessExit.WaitOne(0) // If millisecondsTimeout is zero, the method does not block. It tests the state of the wait handle and returns immediately.
                   );
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex, "Thread closing abnormally");
            }
            mreErrorDone.Set();
        }

        private void ReadStandardOutput(ThreadObject threadObject)
        {
            try
            {
                Log.Info("Start StdOut handler");
                string buf;
                do
                {
                    if (!string.IsNullOrEmpty(buf = threadObject.cmdProcess.StandardOutput.ReadLine()))
                    {
                        Log.Info("StdOut[{0}]", buf);
                        if (!buf.Contains("%")) continue;
                        string[] splits = buf.Split('%');
                        if (int.TryParse(splits[0], out int percentProgress))
                        {
                            threadObject.bgdWorker.ReportProgress(percentProgress, buf);
                        }
                    }
                    else
                    {
                        mreProcessExit.WaitOne(100);
                    }
                } while (!string.IsNullOrEmpty(buf)
                   || !mreProcessExit.WaitOne(0) // If millisecondsTimeout is zero, the method does not block. It tests the state of the wait handle and returns immediately.
                   );
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex, "ReadStandardOutput: ");
            }
            mreOutputDone.Set();
        }

        private void Exited(object o, EventArgs e)
        {
            Log.Info("Exited.");
            Thread.Sleep(1000);  // When the process has exited, the buffers are _still_ flushing
            mreProcessExit.Set();
        }

        private void actionWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (toolStripProgressBar1.Style == ProgressBarStyle.Marquee)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            }
            if (e.ProgressPercentage < 101)
            {
                toolStripProgressBar1.DisplayText = e.UserState as string;
                toolStripProgressBar1.Value = e.ProgressPercentage;
            }
            else if (e.ProgressPercentage == 101)
            {
                toolStripProgressBar1.State = ProgressBarState.Error;
                toolStripProgressBar1.DisplayText = lastError;
                toolStripProgressBar1.Value = 100;
            }
        }

        private void actionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UseWaitCursor = false;
            EnableIfValid(true);

            if (toolStripProgressBar1.Style == ProgressBarStyle.Marquee)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            }
            if (e.Cancelled)
            {
                toolStripProgressBar1.State = ProgressBarState.Pause;
                toolStripProgressBar1.DisplayText = "Cancelled";
                Log.Error("The thread has been cancelled");
                comboBox1.Text = "Abort";
            }
            else if (e.Error != null)
            {
                toolStripProgressBar1.State = ProgressBarState.Error;
                toolStripProgressBar1.DisplayText = e.Error.Message;
                Log.Error(e.Error, "Thread threw: ");
                comboBox1.Text = "Abort";
            }
            else
            {
                //if (toolStripProgressBar1.State == ProgressBarState.Normal)
                {
                    toolStripProgressBar1.DisplayText = "Completed";
                    toolStripProgressBar1.Value = 100;
                    comboBox1.Text = "Stopped";
                }
                Log.Info("Completed");
            }
            comboBox1.Enabled = false;
        }

        internal void StartSnapRaidProcess(string command)
        {
            EnableIfValid(false);
            tabControl1.SelectTab(realTimeOutputTabPage);
            comboBox1.Enabled = true;
            comboBox1.Text = "Running";
            requested = ProcessPriorityClass.Normal;
            actionWorker.RunWorkerAsync(command);
            UseWaitCursor = true;
            toolStripStatusLabel1.Text = DateTime.Now.ToString("u");
            toolStripProgressBar1.DisplayText = command + "- Starting";
            toolStripProgressBar1.State = ProgressBarState.Normal;
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.Value = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!actionWorker.IsBusy) return;
            switch (comboBox1.Text)
            {
                case "Stopped":
                    comboBox1.Text = "Abort";
                    break;

                case "Running":
                    requested = ProcessPriorityClass.Normal;
                    break;

                case "Abort":
                    actionWorker.CancelAsync();
                    comboBox1.Enabled = false;
                    break;

                case "Idle":
                    requested = ProcessPriorityClass.Idle;
                    break;

                default:
                    Log.Error("Invalid option for comboBox1_SelectedIndexChanged()");
                    break;
            }
        }
    }
}