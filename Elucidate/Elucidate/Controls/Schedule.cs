using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Elucidate.Logging;
using Microsoft.Win32.TaskScheduler;

namespace Elucidate.Controls
{
    // See the code in the following location for taskscheduler
    // http://taskscheduler.codeplex.com/wikipage?title=Examples&referringTitle=Documentation

    // The TaskListView behaves strangely, the item
    // clicked event seems to not aways contain 
    // the item clicked, so instead we'll go directly
    // to the control and the get the selected item

    public partial class Schedule : UserControl
    {
        private string appExecuteScript = "snapraid.ps1";
        private string TaskNameSelected { get; set; } = string.Empty;
        private readonly string _uniqueKeyForThisConfig;
        private readonly ContextMenuStrip _menuStripNew = new ContextMenuStrip();
        private enum ScheduledTaskTypeEnum { Sync, Check, Diff }
        private ScheduledTaskTypeEnum ScheduledTaskType { get; set; }
        private const string MENU_STRIP_NEW_SYNC = "Sync";
        private const string MENU_STRIP_NEW_CHECK = "Check";
        private const string MENU_STRIP_NEW_DIFF = "Diff";
        private const string TaskFolder = "Elucidate";
        private const string TaskName = "SnapRAID <TASK_TYPE> - task created by Elucidate";

        public Schedule()
        {
            InitializeComponent();

            _uniqueKeyForThisConfig = GetUniqueKeyForThisConfig();

            _menuStripNew.Items.Add(MENU_STRIP_NEW_SYNC);
            _menuStripNew.Items.Add(MENU_STRIP_NEW_CHECK);
            _menuStripNew.Items.Add(MENU_STRIP_NEW_DIFF);
            menuButtonNewScheduleItem.ShowMenuUnderCursor = false;
            menuButtonNewScheduleItem.Menu = _menuStripNew;
            menuButtonNewScheduleItem.Menu.ItemClicked += menuStrip_ItemClicked;
            taskListView.TaskSelected += TaskListView_TaskSelected;
            taskListView.MouseDoubleClick += TaskListView_MouseDoubleClick;
        }

        private void TaskListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (taskListView.SelectedIndex < 0) return;

            if (taskListView.Tasks[taskListView.SelectedIndex] == null) return;

            if (!taskListView.Tasks[taskListView.SelectedIndex].Name.Contains(GetUniqueKeyForThisConfig()))
            {
                using (Task target = taskListView.Tasks[taskListView.SelectedIndex])
                {
                    string msg = "The selected task does not belong to this SnapRAID \n" +
                                 "configuration and cannot be edited.";
                    if (target.Definition.RegistrationInfo.Description != null &&
                        target.Definition.RegistrationInfo.Description.Contains("SnapRAID config file"))
                    {
                        msg += "\nOpen the SnapRaid \n" +
                               "configuration found at:\n\n" +
                               $@"{target.Definition.RegistrationInfo.Description}";
                    }

                    MessageBox.Show(msg);
                    return;
                }
            }

            btnEdit_Click(null, null);
        }

        private void Scheduler_Load(object sender, EventArgs e)
        {
            DisplayTaskScheduleItems();
        }

        private void TaskListView_TaskSelected(object sender, TaskListView.TaskSelectedEventArgs e)
        {
            if (!e.Task.Name.Contains(_uniqueKeyForThisConfig))
            {
                TaskNameSelected = string.Empty;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnEnableDisable.Enabled = false;
                btnRun.Enabled = false;
            }
            else
            {
                TaskNameSelected = e.Task.Name;
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
                btnEnableDisable.Enabled = true;
                btnRun.Enabled = true;
            }
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                switch (e.ClickedItem.Text)
                {
                    case MENU_STRIP_NEW_SYNC:
                        ScheduledTaskType = ScheduledTaskTypeEnum.Sync;
                        break;
                    case MENU_STRIP_NEW_CHECK:
                        ScheduledTaskType = ScheduledTaskTypeEnum.Check;
                        break;
                    case MENU_STRIP_NEW_DIFF:
                        ScheduledTaskType = ScheduledTaskTypeEnum.Diff;
                        break;
                    default:
                        ExceptionHandler.ReportException(new ArgumentOutOfRangeException($"Menu item '{e.ClickedItem.Text}' does not exist"));
                        break;
                }

                CreateScheduledTask(ScheduledTaskType);

                DisplayTaskScheduleItems();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
        }

        private void CreateScheduledTask(ScheduledTaskTypeEnum scheduledTaskType)
        {
            string taskCommand;
            string taskDescription;

            switch (scheduledTaskType)
            {
                case ScheduledTaskTypeEnum.Sync:
                    taskCommand = "sync";
                    taskDescription = $"This task was created by Elucidate. " +
                                  $"| It performs the SnapRAID Sync command. " +
                                  $"| SnapRAID config file: {Properties.Settings.Default.ConfigFileLocation}";
                    break;
                case ScheduledTaskTypeEnum.Check:
                    taskCommand = "check";
                    taskDescription = $"This task was created by Elucidate. " +
                                  $"| It performs the SnapRAID Check command. " +
                                  $"| SnapRAID config file: {Properties.Settings.Default.ConfigFileLocation}";
                    break;
                case ScheduledTaskTypeEnum.Diff:
                    taskCommand = "diff";
                    taskDescription = $"This task was created by Elucidate. " +
                                  $"| It performs the SnapRAID Diff command. " +
                                  $"| SnapRAID config file: {Properties.Settings.Default.ConfigFileLocation}";
                    break;
                default:
                    return;
            }

            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.Data = "https://github.com/BlueBlock/Elucidate";
                td.RegistrationInfo.Author = "Elucidate";
                td.RegistrationInfo.Description = taskDescription;
                //td.RegistrationInfo.Documentation = "https://github.com/BlueBlock/Elucidate";
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
                string args = Util.FormatSnapRaidCommandArgs(
                    command: taskCommand.ToLower(),
                    additionalCommands: string.Empty,
                    appPath: out _);
                args = AddLoggingToArgsForSchedule(args);
                args = args.Replace(@"""", @"\""");
                ExecAction tsAction = new ExecAction
                {
                    Path = "powershell.exe",
                    Arguments = $@"-File ""{Path.Combine(Environment.CurrentDirectory, appExecuteScript)}"" -exe ""{Properties.Settings.Default.SnapRAIDFileLocation}"" -args ""{args}"" ",
                    WorkingDirectory = Path.GetDirectoryName(Properties.Settings.Default.SnapRAIDFileLocation)
                };
                td.Actions.Add(tsAction);
                // Create an action which sends an email
                // td.Actions.Add(new EmailAction("Testing", "dahall@codeplex.com", "user@test.com", "You've got mail.", "mail.myisp.com"));
                ts.RootFolder.RegisterTaskDefinition(
                    path: $@"{TaskFolder}\{GetNewTaskName()}",
                    definition: td,
                    createType: TaskCreation.CreateOrUpdate,
                    userId: null,
                    password: null,
                    logonType: TaskLogonType.InteractiveToken);
            }
        }

        private static string AddLoggingToArgsForSchedule(string args)
        {
            string appDir = Path.GetDirectoryName(Properties.Settings.Default.ConfigFileLocation);
            string logDir = Properties.Settings.Default.LogFileDirectory;
            string logFilename = "<DATETIME>.log"; // the powershell script will replace <DATETIME>
            string newArgs = $@"--log ""{appDir}\{logDir}\{logFilename}"" {args}";
            return newArgs;
        }

        private string GetNewTaskName()
        {
            string taskName = TaskName.Replace(@"<TASK_TYPE>", ScheduledTaskType.ToString());
            return $"{taskName} - Created[{DateTime.Now:yyyy-MM-dd HH-mm-ss}] - {GetUniqueKeyForThisConfig()}";
        }

        private string GetUniqueKeyForThisConfig()
        {
            // so each config can have a scheduled task, use the config file path to
            // compute a unique key as a reference for the csheduled task
            return Util.ComputeSha1Hash(Properties.Settings.Default.ConfigFileLocation.ToLower().Trim());
        }

        // ReSharper disable once UnusedMember.Local
        private bool IsTaskExist(string taskFolder, string taskName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                using (TaskService ts = new TaskService())
                {
                    Task target = ts.GetTask($@"{taskFolder}\{taskName}");
                    return target != null;
                }
            }
            catch
            {
                Log.Instance.Error("Unable to retrieve tasks from the Windows Task Scheduler");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            return false;
        }

        private void DisplayTaskScheduleItems()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                btnEnableDisable.Enabled = false;
                btnRun.Enabled = false;

                using (TaskService ts = new TaskService())
                {
                    // Display version and server state
                    Version ver = ts.HighestSupportedVersion;
                    Log.Instance.Debug("Highest version: {0}", ver);
                    Log.Instance.Debug("Server: {0} ({1})", ts.TargetServer,
                        ts.Connected ? "Connected" : "Disconnected");
                    // Output all the tasks in the root folder with their triggers and actions
                    TaskFolder tf = ts.GetFolder(TaskFolder);
                    Log.Instance.Debug($"{TaskFolder} folder task count ({0}):", tf.Tasks.Count);
                    taskListView.Tasks = tf.Tasks;
                }
            }
            catch
            {
                Log.Instance.Error("Unable to retrieve tasks from the Windows Task Scheduler");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnGetSchedules_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DisplayTaskScheduleItems();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (taskListView.SelectedIndex < 0) return;

                if (string.IsNullOrEmpty(TaskNameSelected)) return;

                using (TaskService ts = new TaskService())
                {
                    if (!ts.RootFolder.SubFolders.Exists(TaskFolder)) return;

                    TaskFolder tf = ts.GetFolder(TaskFolder);

                    foreach (Task task in tf.Tasks)
                    {
                        if (task.Name != TaskNameSelected) continue;
                        if (DialogResult.Yes == MessageBox.Show(
                                @"Do you want to delete the selected task?",
                                @"Delete Scheduled Task", MessageBoxButtons.YesNoCancel))
                        {
                            tf.DeleteTask(TaskNameSelected);
                            DisplayTaskScheduleItems();
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (taskListView.SelectedIndex < 0) return;

                if (string.IsNullOrEmpty(TaskNameSelected)) return;

                using (TaskService ts = new TaskService())
                {
                    if (ts.RootFolder.SubFolders.Exists(TaskFolder))
                    {
                        TaskFolder tf = ts.GetFolder(TaskFolder);

                        foreach (Task task in tf.Tasks)
                        {
                            if (task.Name != TaskNameSelected) continue;
                            // Edit task and re-register if user clicks Ok
                            TaskEditDialog frm = new TaskEditDialog(task);
                            frm.AvailableTabs |= AvailableTaskTabs.RunTimes;
                            frm.RegisterTaskOnAccept = true;
                            frm.ShowDialog(this);
                            break;
                        }
                    }
                }

                DisplayTaskScheduleItems();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnEnableDisable_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (taskListView.SelectedIndex < 0) return;

                if (string.IsNullOrEmpty(TaskNameSelected)) return;

                using (TaskService ts = new TaskService())
                {
                    if (ts.RootFolder.SubFolders.Exists(TaskFolder))
                    {
                        TaskFolder tf = ts.GetFolder(TaskFolder);

                        foreach (Task task in tf.Tasks)
                        {
                            if (task.Name != TaskNameSelected) continue;
                            task.Enabled = !task.Enabled;
                            break;
                        }
                    }
                }

                DisplayTaskScheduleItems();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (taskListView.SelectedIndex < 0) return;

                if (string.IsNullOrEmpty(TaskNameSelected)) return;

                using (TaskService ts = new TaskService())
                {
                    if (ts.RootFolder.SubFolders.Exists(TaskFolder))
                    {
                        TaskFolder tf = ts.GetFolder(TaskFolder);

                        foreach (Task task in tf.Tasks)
                        {
                            if (task.Name != TaskNameSelected) continue;
                            task.Run();
                            break;
                        }
                    }
                }

                DisplayTaskScheduleItems();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
