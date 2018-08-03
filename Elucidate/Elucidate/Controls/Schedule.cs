using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;
using Elucidate.Logging;
using Microsoft.Win32.TaskScheduler;

namespace Elucidate.Controls
{
    public partial class Schedule : UserControl
    {
        public Schedule()
        {
            InitializeComponent();
        }

        //
        // See the code in the following location for how to do these things
        // http://taskscheduler.codeplex.com/wikipage?title=Examples&referringTitle=Documentation
        //
        
        private const string TaskName = "SnapRAID Sync - task created by Elucidate";
        //private const string OldTaskName = "SnapRAID Sync";

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
                td.RegistrationInfo.Documentation = "https://github.com/BlueBlock/Elucidatedocumentation";
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
                LogonTrigger lTrigger = td.Triggers.Add(new LogonTrigger());
                if (newVer)
                {
                    lTrigger.Delay = TimeSpan.FromMinutes(1);
                    lTrigger.UserId = user;
                }
                lTrigger.Repetition.Interval = TimeSpan.FromDays(1);
                // Create an action which opens a log file in notepad
                string args = Util.FormatSnapRaidCommandArgs(command: "Sync", additionalCommands: string.Empty, appPath: out string appPath);
                td.Actions.Add(new ExecAction("cmd", $"/k \"\"{appPath}\" {args}\""));
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

        private void GetTaskScheduleItems()
        {
            try
            {
                using (TaskService ts = new TaskService())
                {
                    // Display version and server state
                    Version ver = ts.HighestSupportedVersion;
                    Log.Instance.Debug("Highest version: {0}", ver);
                    //Log.Instance.Debug("Server: {0} ({1})", ts.TargetServer, ts.Connected ? "Connected" : "Disconnected");
                    // Output all the tasks in the root folder with their triggers and actions
                    TaskFolder tf = ts.RootFolder;
                    Log.Instance.Debug("Root folder task count ({0}):", tf.Tasks.Count);
                    taskListView.Tasks = ts.RootFolder.Tasks;
                }
            }
            catch
            {
                Log.Instance.Error("Unable to retrieve tasks from the Windows Task Scheduler");
            }
        }

        private void Scheduler_Load(object sender, EventArgs e)
        {
        }

        private void btnGetSchedules_Click(object sender, EventArgs e)
        {
            try
            {
                GetTaskScheduleItems();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
        }

        private void btnNewReplace_Click(object sender, EventArgs e)
        {
            try
            {
                GetTaskTemplate();
                btnGetSchedules_Click(sender, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (TaskService ts = new TaskService())
                {
                    if (ts.RootFolder.Tasks.Exists(TaskName))
                    {
                        // Remove the task we created
                        ts.RootFolder.DeleteTask(TaskName);
                    }
                }
                btnGetSchedules_Click(sender, e);
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
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
                ExceptionHandler.ReportException(ex);
            }
        }
    }
}
