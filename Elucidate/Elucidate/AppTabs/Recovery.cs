#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  Forked by BlueBlock on July 28th, 2018
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="Recovery.cs" company="Smurf-IV">
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Elucidate.Shared;

namespace Elucidate
{
    public sealed partial class ElucidateForm
    {
        #region Recovery options pane

        //private void tabControl_Selected(object sender, TabControlEventArgs e)
        //{
            
        //    else if (e.TabPage == tabCoveragePage)
        //    {
        //        if (!Properties.Settings.Default.ConfigFileIsValid) return;
        //        try
        //        {
        //            ConfigFileHelper cfg = new ConfigFileHelper(Properties.Settings.Default.ConfigFileLocation);
        //            cfg.Read();
        //            List<string> displayLines = cfg.SnapShotSources;
        //            // Add the Parity lines to show the amount of drive space currently occupied by SnapRaid
        //            displayLines.Add(new FileInfo(cfg.ParityFile1).DirectoryName);
        //            if (!string.IsNullOrEmpty(cfg.ParityFile2))
        //            {
        //                displayLines.Add(new FileInfo(cfg.ParityFile2).DirectoryName);
        //            }
        //            driveSpace.StartProcessing(displayLines);
        //        }
        //        catch
        //        {
        //            // ignored
        //        }
        //    }
        //}

        //private void tabControl_Deselected(object sender, TabControlEventArgs e)
        //{
        //    if (e.TabPage != RecoveryOperations) return;
        //    if (WindowState == FormWindowState.Maximized)
        //    {
        //        WindowState = FormWindowState.Normal;
        //    }
        //}

        private void btnRemoveOutput_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != MessageBoxExt.Show(this, @"Are you sure you want to perform this task ?",
                    "Remove SnapRAID Output files.", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            try
            {
                ConfigFileHelper cfg = new ConfigFileHelper(Properties.Settings.Default.ConfigFileLocation);
                if (!cfg.Read())
                {
                    MessageBoxExt.Show(this, "Failed to read the config file.", "Config Read Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FileInfo fi;
                if (!string.IsNullOrEmpty(cfg.ParityFile1))
                {
                    fi = new FileInfo(cfg.ParityFile1);
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                }
                if (!string.IsNullOrEmpty(cfg.ParityFile2))
                {
                    fi = new FileInfo(cfg.ParityFile2);
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                }

                if (cfg.ContentFiles == null)
                {
                    return;
                }

                foreach (string contentFile in cfg.ContentFiles.Where(contentFile => !string.IsNullOrEmpty(contentFile)))
                {
                    fi = new FileInfo(contentFile);
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex, "btnRemoveOutput_Click has thrown: ");
                MessageBox.Show(this, ex.Message, @"Remove SnapRAID Output files.");
            }
        }

        #endregion Recovery options pane

    }
}
