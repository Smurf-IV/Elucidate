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
using System.Media;
using System.Reflection;
using System.Windows.Forms;

namespace Elucidate
{
    public sealed partial class Elucidate : Form
    {
        public Elucidate()
        {
            InitializeComponent();
            miscTabCtrl.Elucidate = this;
            if (Properties.Settings.Default.UpdateRequired)
            {
                // Thanks go to http://cs.rthand.com/blogs/blog_with_righthand/archive/2005/12/09/246.aspx
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateRequired = false;
                Properties.Settings.Default.Save();
            }
            WindowLocation.GeometryFromString(Properties.Settings.Default.WindowLocation, this);
            AddThreadingCallbacks();
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

        private void Form1_Shown(object sender, EventArgs e)
        {
            VersionIndicator.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            EnableIfValid(Properties.Settings.Default.ConfigFileIsValid);
            if (!Properties.Settings.Default.ConfigFileIsValid)
            {
                settingsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                runWithoutCaptureMenuItem.Checked = Properties.Settings.Default.RunWithoutCapture;
                toolStripStatusLabel1.Text = DateTime.Now.ToString("u");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // persist our geometry string.
            Properties.Settings.Default.WindowLocation = WindowLocation.GeometryToString(this);
            Properties.Settings.Default.Save();
        }

        private void EnableIfValid(bool enabled)
        {
            EnableCommonButtons(enabled);
            miscTabCtrl.EnableIfValid(enabled);
            EnableScheduleButtons(enabled);
        }

        #region Main Menu Toolbar Handlers

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (actionWorker.IsBusy)
            {
                SystemSounds.Beep.Play();
                return;
            }
            toolStripStatusLabel1.Text = DateTime.Now.ToString("u");
            new Settings().ShowDialog(this);
            EnableIfValid(Properties.Settings.Default.ConfigFileIsValid);
            runWithoutCaptureMenuItem.Checked = Properties.Settings.Default.RunWithoutCapture;
        }

        private void logViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (actionWorker.IsBusy)
            {
                SystemSounds.Beep.Play();
                return;
            }
            toolStripStatusLabel1.Text = DateTime.Now.ToString("u");
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
            if (actionWorker.IsBusy)
            {
                SystemSounds.Beep.Play();
                return;
            }
            new LogFileLocation().ShowDialog(this);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://github.com/Smurf-IV/Elucidatedocumentation");
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ChangeLog.htm"));
            }
            catch
            {
                // Default to launching the checkin page :-!
                Process.Start(@"https://github.com/Smurf-IV/ElucidateSourceControl/list/changesets");
            }
        }

        #endregion Menu Handlers

    }
}