#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  Forked by BlueBlock on July 28th, 2018
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="Form1.cs" company="Smurf-IV">
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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elucidate.Controls;
using Elucidate.HelperClasses;
using Elucidate.Logging;
using Elucidate.Shared;

namespace Elucidate
{
    public sealed partial class ElucidateForm : Form
    {
        private readonly ConfigFileHelper _srConfig = new ConfigFileHelper();

        public ElucidateForm()
        {
            InitializeComponent();

            if (Properties.Settings.Default.UpdateRequired)
            {
                // Thanks go to http://cs.rthand.com/blogs/blog_with_righthand/archive/2005/12/09/246.aspx
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateRequired = false;
                Properties.Settings.Default.Save();
            }
            WindowLocation.GeometryFromString(Properties.Settings.Default.WindowLocation, this);
            liveRunLogControl1.ActionWorker.RunWorkerCompleted += liveRunLogControl1_RunWorkerCompleted;
            recover1.TaskStarted += Recover1_TaskStarted;
            recover1.TaskCompleted += Recover1_TaskCompleted;
            AppUpdate.NewVersionAvailable += VersionCheck_NewVersonAvailable;
            AppUpdate.NewVersionInstallReady += VersionCheck_NewVersonInstallReady;
            Settings.ConfigSaved += Settings_ConfigUpdated;
        }

        private void Settings_ConfigUpdated(object sender, EventArgs e)
        {
            if (File.Exists(Properties.Settings.Default.ConfigFileLocation))
            {
                LoadConfigFile(Properties.Settings.Default.ConfigFileLocation);
            }

            EnableIfValid(Properties.Settings.Default.ConfigFileIsValid);
        }

        private void ElucidateForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Properties.Settings.Default.ConfigFileLocation))
            {
                Properties.Settings.Default.ConfigFileIsValid = false;
            }

            VersionIndicator.Text = AppUpdate.GetInstalledVersion();

            // check for new version and notify if available
            if (AppUpdate.IsNewVersionAvailable())
            {
                MenuItemNewVersionAvailable.Visible = true;
            }
        }

        private void ElucidateForm_Shown(object sender, EventArgs e)
        {
            if (File.Exists(Properties.Settings.Default.ConfigFileLocation))
            {
                LoadConfigFile(Properties.Settings.Default.ConfigFileLocation);
            }

            EnableIfValid(Properties.Settings.Default.ConfigFileIsValid);
        }

        private void VersionCheck_NewVersonAvailable(object sender, EventArgs e)
        {
            MenuItemNewVersionReadyForInstall.Enabled = false;
            MenuItemNewVersionReadyForInstall.Visible = false;
        }

        private void VersionCheck_NewVersonInstallReady(object sender, EventArgs e)
        {
            MenuItemNewVersionAvailable.Enabled = false;
            MenuItemNewVersionAvailable.Visible = false;
            MenuItemNewVersionReadyForInstall.Enabled = true;
            MenuItemNewVersionReadyForInstall.Visible = true;
            AppUpdate.InstallNewVersion();
        }

        private void Recover1_TaskStarted(object sender, EventArgs e)
        {
            tabControl.Deselecting += tabControl_Deselecting;
        }

        private void Recover1_TaskCompleted(object sender, EventArgs e)
        {
            tabControl.Deselecting -= tabControl_Deselecting;
        }

        private void liveRunLogControl1_RunWorkerCompleted(object sender, EventArgs e) => SetCommonButtonsEnabledState(true);

        private void SetCommonButtonsEnabledState(bool enabled)
        {
            editSnapRAIDConfigToolStripMenuItem.Enabled = enabled;
            btnDiff.Enabled = enabled;
            btnSync.Enabled = enabled;
            btnCheck.Enabled = enabled;
            btnStatus.Enabled = enabled;
            btnScrub.Enabled = enabled;
            btnFix.Enabled = enabled;
            btnDupFinder.Enabled = enabled;
            btnForceFullSync.Enabled = enabled;
            logViewToolStripMenuItem.Enabled = enabled;
            if (enabled)
            {
                tabControl.Deselecting -= tabControl_Deselecting;
            }
            else
            {
                tabControl.Deselecting += tabControl_Deselecting;
            }
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabCoveragePage")
            {
                driveSpace.RefreshGraph();
            }
        }

        private void tabControl_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = true;
        }

        // ReSharper disable once InconsistentNaming
        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void EnableIfValid(bool enabled)
        {
            SetCommonButtonsEnabledState(enabled);
        }

        #region Main Menu Toolbar Handlers

        private void RefreshDriveDisplayAfterConfigSaved(object sender, FormClosedEventArgs formClosedEventArgs)
        {
            driveSpace.RefreshGraph();
        }

        private void logViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (liveRunLogControl1.ActionWorker.IsBusy) { return; }

            string userAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Elucidate");

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Path.Combine(userAppData, @"Logs"),
                Filter = @"Log files (*.log)|*.log|Archive logs (*.*)|*.*",
                FileName = "*.log",
                FilterIndex = 2,
                Title = @"Select name to view contents"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            if (Properties.Settings.Default.UseWindowsSettings)
            {
                Process word = Process.Start("Wordpad.exe", '"' + openFileDialog.FileName + '"');
                if (word == null) return;
                word.WaitForInputIdle();
                SendKeys.SendWait("^{END}");
            }
            else
            {
                // Launch whatever "Knows" how to view log files
                Process.Start('"' + openFileDialog.FileName + '"');
            }
        }

        private void changeLogLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (liveRunLogControl1.ActionWorker.IsBusy) { return; }
            new LogFileLocation().ShowDialog(this);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/BlueBlock/Elucidate/wiki/Documentation");
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ReSharper disable once RedundantAssignment
            var bookmark = AppUpdate.GetInstalledVersion().Replace(".", "");
#if DEBUG
            bookmark = AppUpdate.GetLatestVersionInfo().Version.Replace(".", "");
#endif
            Process.Start($"https://github.com/BlueBlock/Elucidate/wiki/ChangeLog#{bookmark}");
        }

        #endregion Menu Handlers

        private void btnStatus_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Status);
        }

        private void btnDiff_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Diff);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            if (Util.IsExecutableRunning(Properties.Settings.Default.SnapRAIDFileLocation))
            {
                SetCommonButtonsEnabledState(true);
                MessageBox.Show(@"A SnapRAID process is already running");
                return;
            }
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Check);
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Sync);
        }

        private void btnScrub_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Scrub);
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Fix);
        }

        private void btnDupFinder_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Dup);
        }

        private void ElucidateForm_ResizeEnd(object sender, EventArgs e)
        {
            // persist our geometry string.
            Properties.Settings.Default.WindowLocation = WindowLocation.GeometryToString(this);
            Properties.Settings.Default.Save();
        }

        private void installNewVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppUpdate.VersionInfo info = AppUpdate.GetLatestVersionInfo();

            if (info?.DownloadUrl == null)
            {
                MessageBox.Show(
                    @"A problem was encountered trying to download the new version. Please try again later.",
                    @"New Version Download Failed",
                    MessageBoxButtons.OK);
                return;
            }

            Task.Run(() => AppUpdate.DownloadLatestVersionAsync(info.DownloadUrl));

        }

        private void changeLogOfNewVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppUpdate.VersionInfo info = AppUpdate.GetLatestVersionInfo();
            ProcessStartInfo processStartInfo = new ProcessStartInfo(info.ChangeLogUrl);
            Process.Start(processStartInfo);
        }

        private void MenuItemNewVersionReadyForInstall_Click(object sender, EventArgs e)
        {
            AppUpdate.InstallNewVersion();
        }

        private void btnForceFullSync_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.ForceFullSync);
        }

        private void openSnapRAIDConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = @"Config Files|*.conf*|All files (*.*)|*.*",
                Title = @"Select a Config File"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadConfigFile(openFileDialog1.FileName);
            }
        }

        private void LoadConfigFile(string configFile)
        {
            _srConfig.LoadConfigFile(configFile);

            if (_srConfig.IsValid)
            {
                Properties.Settings.Default.ConfigFileIsValid = true;
                Properties.Settings.Default.ConfigFileLocation = configFile;
                BeginInvoke((MethodInvoker)delegate { SetElucidateFormTitle(configFile); });
            }
            else
            {
                MessageBoxExt.Show(this, "The config file is not valid.", "Config File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Properties.Settings.Default.ConfigFileIsValid = false;
                Properties.Settings.Default.ConfigFileLocation = string.Empty;
                return;
            }

            EnableIfValid(Properties.Settings.Default.ConfigFileIsValid);
        }

        private void SetElucidateFormTitle(string filePath)
        {
            string newTitle = "Elucidate";

            if (!string.IsNullOrEmpty(filePath))
            {
                newTitle += $" - {filePath}";
            }

            Text = newTitle;
        }

        private void editSnapRAIDConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (liveRunLogControl1.ActionWorker.IsBusy) { return; }

            Settings settingsForm = new Settings();

            if (!Properties.Settings.Default.ConfigFileIsValid)
            {
                Properties.Settings.Default.ConfigFileLocation = "";
            }

            settingsForm.FormClosed += RefreshDriveDisplayAfterConfigSaved;

            settingsForm.ShowDialog(this);

            EnableIfValid(Properties.Settings.Default.ConfigFileIsValid);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ElucidateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void closeSnapRAIDConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate { SetElucidateFormTitle(string.Empty); });
            Properties.Settings.Default.ConfigFileLocation = string.Empty;
            Properties.Settings.Default.ConfigFileIsValid = false;
            EnableIfValid(false);
        }

        private void deleteAllSnapRAIDRaidFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> parityFiles = new List<string>();

            List<string> contentFiles = new List<string>();

            if (!string.IsNullOrEmpty(_srConfig.ParityFile1))
                parityFiles.Add(_srConfig.ParityFile1);

            if (!string.IsNullOrEmpty(_srConfig.ParityFile2))
                parityFiles.Add(_srConfig.ParityFile2);

            if (!string.IsNullOrEmpty(_srConfig.ParityFile3))
                parityFiles.Add(_srConfig.ParityFile3);

            if (!string.IsNullOrEmpty(_srConfig.ParityFile4))
                parityFiles.Add(_srConfig.ParityFile4);

            if (!string.IsNullOrEmpty(_srConfig.ParityFile5))
                parityFiles.Add(_srConfig.ParityFile5);

            if (!string.IsNullOrEmpty(_srConfig.ParityFile6))
                parityFiles.Add(_srConfig.ParityFile6);

            foreach (var file in _srConfig.ContentFiles)
            {
                contentFiles.Add(file);
            }

            var sb = new StringBuilder();

            sb.AppendLine(@"Are you sure you want to remove the files below?");

            sb.AppendLine(@"This action cannot be undone.");

            sb.AppendLine("");

            foreach (var file in parityFiles)
            {
                sb.AppendLine($"Parity File: {file}");
            }

            foreach (var file in contentFiles)
            {
                sb.AppendLine($"Content File: {file}");
            }
            
            var result = MessageBox.Show(
                this, 
                sb.ToString(), 
                @"Delete All SnapRAID Files", 
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    foreach (var file in parityFiles)
                    {
                        File.Delete(file);
                    }

                    foreach (var file in contentFiles)
                    {
                        File.Delete(file);
                    }

                    MessageBoxExt.Show(this, @"The SnapRAID files have been removed", @"Files Removed");
                }
                catch (Exception ex)
                {
                    Log.Instance.Error(ex);
                }
            }
        }
    }
}