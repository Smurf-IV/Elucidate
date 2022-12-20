#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="ElucidateForm.cs" company="Smurf-IV">
//
//  Copyright (C) 2010-2022 Simon Coghlan (Aka Smurf-IV)
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
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Elucidate.Forms;

using Krypton.Navigator;
using Krypton.Toolkit;

using NLog;

// ReSharper disable once CheckNamespace
namespace Elucidate
{
    public sealed partial class ElucidateForm : KryptonForm
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private readonly ConfigFileHelper srConfig = new ();
        private readonly LiveLog liveLog = new ();

        public ElucidateForm()
        {
            // For some reason the designer keeps removing the following !!
            tpCoverage = new Controls.ProtectedDrivesDisplay();
            Icon = Properties.Resources.ElucidateIco;

            InitializeComponent();

            if (Properties.Settings.Default.UpdateRequired)
            {
                // Thanks go to http://cs.rthand.com/blogs/blog_with_righthand/archive/2005/12/09/246.aspx
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateRequired = false;
                Properties.Settings.Default.Save();
            }
            WindowLocation.GeometryFromString(Properties.Settings.Default.WindowLocation, this);
            if (Enum.TryParse(Properties.Settings.Default.Theme, out PaletteModeManager value))
            {
                RecalcNonClient();
                kryptonManager1.GlobalPaletteMode = value;
            }

            liveLog.Show(); // go modeless
            liveRunLogControl1.TaskStarted += LiveRunLogControl_TaskStarted;

            recover1.RunLogControl = liveRunLogControl1;
            commonTab.RunLogControl = liveRunLogControl1;
            // Hook into changes in the global palette
            KryptonManager.GlobalPaletteChanged += OnPaletteChanged;
            ThemeManager.PropagateThemeSelector(themeComboBox);
            themeComboBox.Text = ThemeManager.ReturnPaletteModeManagerAsString(PaletteModeManager.Office2007Blue, kryptonManager1);
        }

        private void LiveRunLogControl_TaskStarted(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)(() => liveLog.BringToFront()));
        }

        private void ElucidateForm_Load(object sender, EventArgs e)
        {
            TextExtra = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void ElucidateForm_Shown(object sender, EventArgs e)
        {
            var args = Environment.GetCommandLineArgs().Skip(1).ToArray();
            if (args.Contains(@"-H")
                || args.Contains(@"--help")
            )
            {
                commonTab.PerformArgs(args);
                commonTab.SetCommonButtonsEnabledState(false); // Prevent button pushing !
            }
            else
            {

                LoadConfigFile();

                // display any warnings from the config validation
                if (srConfig.HasWarnings)
                {
                    KryptonMessageBox.Show(
                        this,
                        $"There are warnings for the configuration file:{Environment.NewLine} - {string.Join(" - ", srConfig.ConfigWarnings)}",
                        "Configuration File Warnings",
                        MessageBoxButtons.OK,
                        KryptonMessageBoxIcon.Warning);
                }
                else
                {
                    commonTab.PerformArgs(args);
                }
            }
        }

        #region Main Menu Toolbar Handlers
        private void EditSnapRAIDConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (liveRunLogControl1.IsRunning)
            {
                SystemSounds.Beep.Play();
                return;
            }

            using (var settingsForm = new Settings())
            {
                settingsForm.ShowDialog(this);
            }

            LoadConfigFile(false);
        }

        private void deleteAllSnapRAIDRaidFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.Info(@"Generate list of file for MessageBiox and deletion code");
            var parityFiles = new List<string>();

            if (!string.IsNullOrWhiteSpace(srConfig.ParityFile1))
            {
                parityFiles.Add(srConfig.ParityFile1);
            }

            if (!string.IsNullOrWhiteSpace(srConfig.ParityFile2))
            {
                parityFiles.Add(srConfig.ParityFile2);
            }

            if (!string.IsNullOrWhiteSpace(srConfig.ZParityFile))
            {
                parityFiles.Add(srConfig.ZParityFile);
            }

            if (!string.IsNullOrWhiteSpace(srConfig.ParityFile3))
            {
                parityFiles.Add(srConfig.ParityFile3);
            }

            if (!string.IsNullOrWhiteSpace(srConfig.ParityFile4))
            {
                parityFiles.Add(srConfig.ParityFile4);
            }

            if (!string.IsNullOrWhiteSpace(srConfig.ParityFile5))
            {
                parityFiles.Add(srConfig.ParityFile5);
            }

            if (!string.IsNullOrWhiteSpace(srConfig.ParityFile6))
            {
                parityFiles.Add(srConfig.ParityFile6);
            }


            var sb = new StringBuilder();

            sb.AppendLine(@"Are you sure you want to remove the files below?");

            sb.AppendLine(@"This action cannot be undone.");

            sb.AppendLine();

            foreach (var file in parityFiles)
            {
                sb.AppendLine($@"Parity File: {file}");
            }

            var contentFiles = srConfig.ContentFiles.ToList();
            foreach (var file in contentFiles)
            {
                sb.AppendLine($@"Content File: {file}");
            }

            DialogResult result = KryptonMessageBox.Show(
                this,
                sb.ToString(),
                @"Delete All SnapRAID Files",
                MessageBoxButtons.YesNoCancel,
                KryptonMessageBoxIcon.Warning);

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

                    KryptonMessageBox.Show(this, @"The SnapRAID files have been removed", @"Files Removed");
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/Smurf-IV/Elucidate/blob/master/docs/Documentation.md");
        }

        private void changeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/Smurf-IV/Elucidate/commits");
        }

        private void editConfigDirectlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (liveRunLogControl1.IsRunning)
            {
                SystemSounds.Beep.Play();
                return;
            }
            using (var process = new Process
            {
                StartInfo = new ProcessStartInfo(@"Wordpad.exe", Properties.Settings.Default.ConfigFileLocation)
            })
            {
                process.Start();
                //Wait for the window to finish loading.
                process.WaitForInputIdle();
                //Wait for the process to end.
                process.WaitForExit();
            }
            LoadConfigFile(true);
        }

        private void showMeTheLatestReleaseStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://www.somsubhra.com/github-release-stats/?username=Smurf-IV&repository=Elucidate");
        }
        #endregion Menu Handlers

        private void OnPaletteChanged(object sender, EventArgs e)
        {
            // persist our geometry string.
            RecalcNonClient();
            Properties.Settings.Default.Theme = kryptonManager1.GlobalPaletteMode.ToString();
            Properties.Settings.Default.Save();
        }

        private void LoadConfigFile(bool launchEditSnapRAID = true)
        {
            srConfig.LoadConfigFile(Properties.Settings.Default.ConfigFileLocation);

            Properties.Settings.Default.ConfigFileIsValid = srConfig.IsValid;
            var exists = File.Exists(Properties.Settings.Default.SnapRAIDFileLocation);

            commonTab.SetCommonButtonsEnabledState(srConfig.IsValid && exists);

            if (srConfig.IsValid
                && exists
                )
            {
                BeginInvoke((MethodInvoker)delegate { SetElucidateFormTitle(Properties.Settings.Default.ConfigFileLocation); });
                if (tabControl.SelectedPage == tabCoveragePage)
                {
                    tpCoverage.RefreshGrid(srConfig, false);
                }
            }
            else
            {
                srConfig.ConfigErrors.Add(@"Please Edit the Settings and ensure no errors when saving!");
                Log.Fatal("The config file is not valid.[{0}]\n{1}", Properties.Settings.Default.ConfigFileLocation,
                    string.Join($@"{Environment.NewLine} - ", srConfig.ConfigErrors));
                if (launchEditSnapRAID)
                {
                    BeginInvoke((MethodInvoker)delegate
                   {
                       EditSnapRAIDConfigToolStripMenuItem_Click(this, EventArgs.Empty);
                   });
                }
            }
        }

        private void SetElucidateFormTitle(string filePath)
        {
            var newTitle = "Elucidate";

            if (!string.IsNullOrEmpty(filePath))
            {
                newTitle += $" - {filePath}";
            }

            Text = newTitle;
        }

        private void ElucidateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tpCoverage.StopProcessing();
            Properties.Settings.Default.LogWindowLocation = WindowLocation.GeometryToString(liveLog);
            Properties.Settings.Default.WindowLocation = WindowLocation.GeometryToString(this);
            Properties.Settings.Default.Save();
        }

        private void tabControl_SelectedPageChanged(object sender, EventArgs e)
        {
            Log.Trace(@"tabControl_SelectedPageChanged - IN");
            KryptonPage currentTab = tabControl.SelectedPage;
            tpCoverage.StopProcessing();

            if (currentTab == tabCommonOperations)
            {
                //tabCommonOperations.Reset();
            }
            else if (currentTab == tabLogs)
            {
                // tabLogs.Reset();
            }
            else if (currentTab == tabCoveragePage)
            {
                tpCoverage.RefreshGrid(srConfig, false);
            }
            else if (currentTab == tabSchedulePage)
            {
                //tpSchedule.Reset();
            }
            else if (currentTab == tabRecoverFiles)
            {
                //  tabCoveragePage.Reset();
            }
            Log.Trace(@"tabControl_SelectedPageChanged - OUT");
        }

        private void themeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThemeManager.SetTheme(themeComboBox.Text, kryptonManager1);

        }
    }
}