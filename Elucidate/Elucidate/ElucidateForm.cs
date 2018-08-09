#region Copyright (C)

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
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elucidate.Controls;
using Elucidate.HelperClasses;
using Elucidate.Shared;

namespace Elucidate
{
    public sealed partial class ElucidateForm : Form
    {
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
            AppUpdate.NewVersonAvailable += VersionCheck_NewVersonAvailable;
            AppUpdate.NewVersonInstallReady += VersionCheck_NewVersonInstallReady;
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
            btnDiff.Enabled = enabled;
            btnSync.Enabled = enabled;
            btnCheck.Enabled = enabled;
            btnStatus.Enabled = enabled;
            btnScrub.Enabled = enabled;
            btnFix.Enabled = enabled;
            btnDupFinder.Enabled = enabled;
            btnUndelete.Enabled = enabled;
            snapRAIDConfigToolStripMenuItem.Enabled = enabled;
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
            // keep the config menu item accessible
            snapRAIDConfigToolStripMenuItem.Enabled = true;
        }

        #region Main Menu Toolbar Handlers

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (liveRunLogControl1.ActionWorker.IsBusy) { return; }
            new Settings().ShowDialog(this);
            EnableIfValid(Properties.Settings.Default.ConfigFileIsValid);
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
            Process.Start("https://github.com/BlueBlock/Elucidate/wiki/ChangeLog#" + bookmark);
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

        private void btnUndelete_Click(object sender, EventArgs e)
        {
            SetCommonButtonsEnabledState(false);
            liveRunLogControl1.StartSnapRaidProcess(LiveRunLogControl.CommandType.Undelete);
        }
        
        private void ElucidateForm_ResizeEnd(object sender, EventArgs e)
        {
            // persist our geometry string.
            Properties.Settings.Default.WindowLocation = WindowLocation.GeometryToString(this);
            Properties.Settings.Default.Save();
        }

        private void ElucidateForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Properties.Settings.Default.ConfigFileLocation))
            {
                Properties.Settings.Default.ConfigFileIsValid = false;
            }

            VersionIndicator.Text = AppUpdate.GetInstalledVersion();

            // check for vew version and notify if available
            if (AppUpdate.IsNewVersionAvailable())
            {
                MenuItemNewVersionAvailable.Visible = true;
            }
        }

        private void ElucidateForm_Shown(object sender, EventArgs e)
        {
            ConfigFileHelper cfg = new ConfigFileHelper(Properties.Settings.Default.ConfigFileLocation);
            if (!cfg.Read())
            {
                MessageBoxExt.Show(this, "Failed to read the config file.", "Config Read Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Properties.Settings.Default.ConfigFileIsValid = cfg.ConfigFileExists;

            EnableIfValid(Properties.Settings.Default.ConfigFileIsValid);

            if (!Properties.Settings.Default.ConfigFileIsValid)
            {
                // open the settings form since the config is not valid
                settingsToolStripMenuItem_Click(sender, e);
            }
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
    }
}