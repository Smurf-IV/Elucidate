using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elucidate.Logging;
using Elucidate.wyDay.Controls;

namespace Elucidate.Controls
{
    public partial class LiveRunLogControl : UserControl
    {
        public LiveRunLogControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// eventing idea taken from http://stackoverflow.com/questions/1423484/using-bashcygwin-inside-c-program
        /// </summary>
        private readonly ManualResetEvent mreProcessExit = new ManualResetEvent(false);
        private readonly ManualResetEvent mreOutputDone = new ManualResetEvent(false);
        private readonly ManualResetEvent mreErrorDone = new ManualResetEvent(false);
        private ProcessPriorityClass requested = ProcessPriorityClass.Normal;
        private string _lastError;

        private readonly BackgroundWorker actionWorker = new BackgroundWorker
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true,
        };

        private class ThreadObject
        {
            public BackgroundWorker BgdWorker;
            public Process CmdProcess;
        }

        internal void StartSnapRaidProcess(string command)
        {
            Log.Instance.Debug("Command buttcon clicked but a command is still running.");
            if (actionWorker.IsBusy) return;
            //UseWaitCursor = true;
            //EnableIfValid(false);
            comboBox1.Enabled = true;
            comboBox1.Text = @"Running";
            requested = ProcessPriorityClass.Normal;
            actionWorker.RunWorkerAsync(command);
            toolStripStatusLabel1.Text = DateTime.Now.ToString("u");
            toolStripProgressBar1.DisplayText = $"{command} - Starting";
            toolStripProgressBar1.State = ProgressBarState.Normal;
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.Value = 0;
        }


        private void actionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Log.Instance.Debug("actionWorker_DoWork");
                BackgroundWorker worker = sender as BackgroundWorker;
                string command = e.Argument as string;

                if (worker == null)
                {
                    Log.Instance.Error("Passed in worker is null");
                    e.Cancel = true;
                    return;
                }
                else if (string.IsNullOrWhiteSpace(command))
                {
                    Log.Instance.Error("Passed in command is null");
                    e.Cancel = true;
                    return;
                }

                int exitCode;
                mreProcessExit.Reset();
                mreOutputDone.Reset();
                mreErrorDone.Reset();
                string args = Util.FormatSnapRaidCommandArgs(command, txtAddCommands.Text, out string appPath);

                if (runWithoutCaptureMenuItem.Checked)
                {
                    Log.Instance.Warn("Running without Capture mode");
                    Log.Instance.Info("Starting minimised {0} {1}", appPath, args);
                    Log.Instance.Info("Working...");
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = "CMD.exe",
                        Arguments = $" /K \"{appPath} {args}\"",
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
                        mreProcessExit.Set();
                    }

                    while (!WaitHandle.WaitAll(new WaitHandle[] { mreErrorDone, mreOutputDone, mreProcessExit }, 250))
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
                            if (current == requested) continue;
                            Log.Instance.Fatal("Setting the processpriority to[{0}]", requested);
                            process.PriorityClass = requested;
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
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex, "Thread closing abnormally");
                throw;
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
                        Log.Instance.Warn("Verbose[{0}]", buf);
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
                Log.Instance.Debug("Start StdOut handler");
                string buf;
                do
                {
                    if (!string.IsNullOrEmpty(buf = threadObject.CmdProcess.StandardOutput.ReadLine()))
                    {
                        Log.Instance.Info("StdOut[{0}]", buf);
                        if (!buf.Contains("%")) continue;
                        string[] splits = buf.Split('%');
                        if (int.TryParse(splits[0], out int percentProgress))
                        {
                            threadObject.BgdWorker.ReportProgress(percentProgress, buf);
                        }
                    }
                    else
                    {
                        mreProcessExit.WaitOne(100);
                    }
                    //Log.Instance.Debug("sleep");
                    //Thread.Sleep(1000);
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
            Log.Instance.Debug("Exited.");
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
                toolStripProgressBar1.DisplayText = _lastError;
                toolStripProgressBar1.Value = 100;
            }
        }

        private void actionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //UseWaitCursor = false;
            //EnableIfValid(true);

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
                toolStripProgressBar1.DisplayText = e.Error.Message;
                Log.Instance.Error(e.Error, "Thread threw: ");
                comboBox1.Text = @"Abort";
            }
            else
            {
                //if (toolStripProgressBar1.State == ProgressBarState.Normal)
                {
                    toolStripProgressBar1.DisplayText = "Completed";
                    toolStripProgressBar1.Value = 100;
                    comboBox1.Text = @"Stopped";
                }
                //Log.Instance.Info("Completed");
            }
            comboBox1.Enabled = false;
        }







    }
}
