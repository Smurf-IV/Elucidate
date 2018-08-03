using System;
using System.Diagnostics;
using System.IO;
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

        private const string TaskFolder = "Elucidate";
        private const string TaskName = "SnapRAID Sync - task created by Elucidate";

        private void Scheduler_Load(object sender, EventArgs e)
        {
            DisplayTaskScheduleItems();
        }

        private void CreateScheduledTask()
        {
            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.Data = "https://github.com/Smurf-IV/Elucidatedocumentation";
                //td.Principal.UserId = WindowsIdentity.GetCurrent().Name;
                //td.Principal.LogonType = TaskLogonType.InteractiveToken;
                td.RegistrationInfo.Author = "Elucidate";
                td.RegistrationInfo.Description = $"This task was created by Elucidate. | It performs the SnapRAID Sync command. | SnapRAID config file: {Properties.Settings.Default.ConfigFileLocation}";
                //td.RegistrationInfo.Documentation = "https://github.com/BlueBlock/Elucidatedocumentation";
                td.Settings.DisallowStartIfOnBatteries = true;
                td.Settings.Enabled = true;
                td.Settings.ExecutionTimeLimit = TimeSpan.FromDays(1);
                td.Settings.Hidden = true;
                td.Settings.Priority = ProcessPriorityClass.Normal;
                td.Settings.RunOnlyIfIdle = false;
                td.Settings.RunOnlyIfNetworkAvailable = false;
                td.Settings.StopIfGoingOnBatteries = true;
                bool newVer = (ts.HighestSupportedVersion >= new Version(1, 2));
                if (newVer)
                {
                    td.Triggers.Add(new DailyTrigger { DaysInterval = 1, StartBoundary = DateTime.Now + TimeSpan.FromMinutes(15) });
                }
                string args = Util.FormatSnapRaidCommandArgs(command: "Sync", additionalCommands: string.Empty, appPath: out string appPath);
                args = Util.AddLoggingToArgs(args);
                string appExe = $"{Path.GetFileName(appPath)}";
                ExecAction tsAction = new ExecAction
                {
                    Path = "CMD",
                    Arguments = $"/C {appExe} {args}",
                    WorkingDirectory = Path.GetDirectoryName(Properties.Settings.Default.SnapRAIDFileLocation)
                };
                td.Actions.Add(tsAction);
                // Create an action which sends an email
                // td.Actions.Add(new EmailAction("Testing", "dahall@codeplex.com", "user@test.com", "You've got mail.", "mail.myisp.com"));
                ts.RootFolder.RegisterTaskDefinition(
                    path: $@"{TaskFolder}\{GetTaskName()}",
                    definition: td,
                    createType: TaskCreation.CreateOrUpdate,
                    userId: null,
                    password: null,
                    logonType: TaskLogonType.InteractiveToken);
            }
        }

        private static string GetTaskName()
        {
            return $"{TaskName} - {GetUniqueKeyForThisConfig()}";
        }

        private static string GetUniqueKeyForThisConfig()
        {
            // so each config can have a scheduled task, use the config file path to
            // compute a unique key as a reference for the csheduled task
            return Util.ComputeSha256Hash(Properties.Settings.Default.ConfigFileLocation.ToLower().Trim());
        }

        private bool IsTaskExist()
        {
            try
            {
                var taskName = GetTaskName();
                using (TaskService ts = new TaskService())
                {
                    Task target = ts.GetTask($@"{TaskFolder}\{taskName}");
                    return target != null;
                }
            }
            catch
            {
                Log.Instance.Error("Unable to retrieve tasks from the Windows Task Scheduler");
            }

            return false;
        }

        private void DisplayTaskScheduleItems()
        {
            try
            {
                using (TaskService ts = new TaskService())
                {
                    // Display version and server state
                    Version ver = ts.HighestSupportedVersion;
                    Log.Instance.Debug("Highest version: {0}", ver);
                    Log.Instance.Debug("Server: {0} ({1})", ts.TargetServer, ts.Connected ? "Connected" : "Disconnected");
                    // Output all the tasks in the root folder with their triggers and actions
                    TaskFolder tf = ts.GetFolder(TaskFolder);
                    Log.Instance.Debug($"{TaskFolder} folder task count ({0}):", tf.Tasks.Count);
                    taskListView.Tasks = tf.Tasks;
                    //var taskName = GetTaskName();
                    //IEnumerable<Task> tasks = tf.Tasks.ToList().Where(a => a.Name == taskName);
                    //if (tasks.Any())
                    //{
                    //    taskListView.Tasks = tasks;
                    //}
                }
                
                bool isTaskExist = IsTaskExist();
                btnEdit.Enabled = isTaskExist;
                btnDelete.Enabled = isTaskExist;
            }
            catch
            {
                Log.Instance.Error("Unable to retrieve tasks from the Windows Task Scheduler");
            }
        }

        private void btnGetSchedules_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayTaskScheduleItems();
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
                CreateScheduledTask();
                DisplayTaskScheduleItems();
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
                    if (ts.RootFolder.SubFolders.Exists(TaskFolder))
                    {
                        TaskFolder tf = ts.GetFolder(TaskFolder);
                        var taskName = GetTaskName();
                        if (tf.Tasks.Exists(taskName))
                        {
                            // Remove the task we created
                            tf.DeleteTask(taskName);
                        }
                    }
                }
                DisplayTaskScheduleItems();
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
                var taskName = GetTaskName();
                using (TaskService ts = new TaskService())
                {
                    using (Task target = ts.GetTask($@"{TaskFolder}\{taskName}"))
                    {
                        if (target != null)
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
                }
                DisplayTaskScheduleItems();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
        }
    }
}
