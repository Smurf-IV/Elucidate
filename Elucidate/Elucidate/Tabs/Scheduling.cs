#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="Scheduling.cs" company="Smurf-IV">
//
//  Copyright (C) 2015 Simon Coghlan (Aka Smurf-IV)
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
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using wyDay.Controls;
using Elucidate.Logging;

namespace Elucidate
{
    public partial class Elucidate
    {
        private const string TaskName = "SnapRAID Sync";

        private void EnableScheduleButtons(bool b)
        {
            btnGetSchedules.Enabled = b;
            btnNew.Enabled = b;
            btnEdit.Enabled = b;
            btnDelete.Enabled = b;
        }

        //
        // See the code in the following location for how to do these things
        // http://taskscheduler.codeplex.com/wikipage?title=Examples&referringTitle=Documentation
        //

        private void btnGetSchedules_Click(object sender, EventArgs e)
        {
            try
            {
                EnableScheduleButtons(false);
                toolStripStatusLabel1.Text = DateTime.Now.ToString("u");
                toolStripProgressBar1.DisplayText = "Starting";
                toolStripProgressBar1.State = ProgressBarState.Normal;
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                toolStripProgressBar1.Value = 0;
                UseWaitCursor = true;

                using (TaskService ts = new TaskService())
                {
                    // Display version and server state
                    Version ver = ts.HighestSupportedVersion;
                    Log.Instance.Info("Highest version: {0}", ver);
                    Log.Instance.Info("Server: {0} ({1})", ts.TargetServer, ts.Connected ? "Connected" : "Disconnected");
                    // Output all the tasks in the root folder with their triggers and actions
                    TaskFolder tf = ts.RootFolder;
                    Log.Instance.Info("Root folder tasks ({0}):", tf.Tasks.Count);

                    lstHistory.Tasks = tf.Tasks;
                    //lstHistory.Tasks = ts.FindAllTasks();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
            finally
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
                UseWaitCursor = false;
                toolStripProgressBar1.DisplayText = string.Empty;
                toolStripProgressBar1.Value = 0;
                EnableScheduleButtons(true);
            }
        }

        private void GetTaskTemplate()
        {
            string user = WindowsIdentity.GetCurrent().Name;
            //bool preWin7 = Environment.OSVersion.Version < new Version(6, 1);
            // Get the service on the local machine
            using (TaskService ts = new TaskService())
            {
                // Create a new task
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.Data = "https://github.com/Smurf-IV/Elucidatedocumentation";
                //td.Principal.UserId = user;
                //td.Principal.LogonType = TaskLogonType.InteractiveToken;
                td.RegistrationInfo.Author = "Elucidate";
                td.RegistrationInfo.Description = "Performs the SnapRAID Sync command after a small delay after logon";
                td.RegistrationInfo.Documentation = "https://github.com/Smurf-IV/Elucidatedocumentation";
                td.Settings.DisallowStartIfOnBatteries = true;
                td.Settings.Enabled = true;
                td.Settings.ExecutionTimeLimit = TimeSpan.FromDays(1);
                td.Settings.Hidden = false;
                td.Settings.Priority = ProcessPriorityClass.Normal;
                td.Settings.RunOnlyIfIdle = false;
                td.Settings.RunOnlyIfNetworkAvailable = false;
                td.Settings.StopIfGoingOnBatteries = true;
                bool newVer = (ts.HighestSupportedVersion >= new Version(1, 2));
                // Create a trigger that fires 1 Minute after the current user logs on
                LogonTrigger lTrigger = (LogonTrigger)td.Triggers.Add(new LogonTrigger());
                if (newVer)
                {
                    lTrigger.Delay = TimeSpan.FromMinutes(1);
                    lTrigger.UserId = user;
                }
                lTrigger.Repetition.Interval = TimeSpan.FromDays(1);
                // Create an action which opens a log file in notepad
                string args = FormatSnapRaidCommandArgs("Sync", out string appPath);
                td.Actions.Add(new ExecAction("cmd", string.Format("/k \"\"{0}\" {1}\"", appPath, args), null));
                //if (newVer)
                //{
                //   // Create an action which shows a message to the interactive user
                //   td.Actions.Add(new ShowMessageAction("Running Notepad", "Info"));
                //   // Create an action which sends an email
                //   td.Actions.Add(new EmailAction("Testing", "dahall@codeplex.com", "user@test.com", "You've got mail.", "mail.myisp.com"));
                //}
                // Register the task definition (saves it) in the security context of the interactive user
                ts.RootFolder.RegisterTaskDefinition(TaskName, td, TaskCreation.CreateOrUpdate, null, null, TaskLogonType.InteractiveToken);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                EnableScheduleButtons(false);
                GetTaskTemplate();
                btnGetSchedules_Click(sender, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex, "btnNew_Click has thrown: ");
                MessageBox.Show(this, ex.Message, @"New Schedule Task");
            }
            finally
            {
                EnableScheduleButtons(true);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                EnableScheduleButtons(false);

                using (TaskService ts = new TaskService())
                {
                    Task target = ts.GetTask(TaskName);
                    if (target == null)
                    {
                        GetTaskTemplate();
                        target = ts.GetTask(TaskName);
                    }
                    using (target)
                    {
                        //// Edit task and re-register if user clicks Ok
                        using (TaskEditDialog editorForm = new TaskEditDialog(target)
                        {
                            Editable = true,
                            RegisterTaskOnAccept = true
                        })
                        {
                            editorForm.AvailableTabs |= AvailableTaskTabs.RunTimes;
                            editorForm.ShowDialog();
                        }
                    }
                }
                btnGetSchedules_Click(sender, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex, "btnEdit_Click has thrown: ");
                MessageBox.Show(this, ex.Message, @"Edit Schedule Task");
            }
            finally
            {
                EnableScheduleButtons(true);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                EnableScheduleButtons(false);

                using (TaskService ts = new TaskService())
                {
                    // Remove the task we created
                    ts.RootFolder.DeleteTask(TaskName);
                }
                btnGetSchedules_Click(sender, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex, "btnDelete_Click has thrown: ");
                MessageBox.Show(this, ex.Message, @"Delete Schedule Task");
            }
            finally
            {
                EnableScheduleButtons(true);
            }
        }

    }
}
