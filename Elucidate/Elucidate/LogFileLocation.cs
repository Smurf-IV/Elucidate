#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="LogFileLocations.cs" company="Smurf-IV">
//
//  Copyright (C) 2012 Smurf-IV
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
using System.Windows.Forms;
using Elucidate.Logging;

namespace Elucidate
{
    public partial class LogFileLocation : Form
    {
        public LogFileLocation()
        {
            InitializeComponent();

            txtNewLocation.Text = txtCurrentLocation.Text = GetLogFileLocation();
        }

        private static string GetLogFileLocation()
        {
            return string.IsNullOrEmpty(Properties.Settings.Default.NlogFileLocation) ? Log.DefaultLogLocation : Properties.Settings.Default.NlogFileLocation;
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            txtNewLocation.Text = Log.DefaultLogLocation;
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNewLocation.Text))
                {
                    txtNewLocation.Text = Log.DefaultLogLocation;
                }
                Log.SetLogPath(txtNewLocation.Text);
                txtCurrentLocation.Text = txtNewLocation.Text;
            }
            catch (Exception ex)
            {
                ExceptionHandler.ReportException(ex);
            }
        }

        private void btnLaunchBrowser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtNewLocation.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        
    }
}