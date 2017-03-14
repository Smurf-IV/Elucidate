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
//  Url: http://Elucidate.codeplex.com/
//  Email: http://www.codeplex.com/site/users/view/smurfiv
//  </summary>
// --------------------------------------------------------------------------------------------------------------------

#endregion Copyright (C)

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace Elucidate
{
   public partial class LogFileLocation : Form
   {
      private const string configurationNlogVariableNameLogdirValue = @"/configuration/nlog/variable[@name='LogDir'][@value]";

      public LogFileLocation()
      {
         InitializeComponent();

         // retrieve appSettings node
         txtNewLocation.Text = txtCurrentLocation.Text = GetLogFileLocation();
      }

      private void btnDefault_Click(object sender, EventArgs e)
      {
         txtCurrentLocation.Text = txtNewLocation.Text = @"${specialfolder:folder=CommonApplicationData}/Elucidate/Logs";
         WriteSetting(txtCurrentLocation.Text);
      }

      private void btnCommit_Click(object sender, EventArgs e)
      {
         WriteSetting(txtNewLocation.Text);
         txtCurrentLocation.Text = txtNewLocation.Text;
      }

      private void btnLaunchBrowser_Click(object sender, EventArgs e)
      {
         if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            txtNewLocation.Text = folderBrowserDialog1.SelectedPath;
      }

      public static void WriteSetting(string value)
      {
         try
         {
            XmlDocument doc = loadConfigDocument();
            XmlAttribute att = doc.SelectSingleNode(configurationNlogVariableNameLogdirValue).Attributes["value"];
            att.Value = value;
            doc.Save(getConfigFilePath());
         }
         catch
         {
            throw;
         }
      }

      public static string GetLogFileLocation()
      {
         XmlDocument doc = loadConfigDocument();
         return doc.SelectSingleNode(configurationNlogVariableNameLogdirValue).Attributes["value"].Value;
      }

      private static XmlDocument loadConfigDocument()
      {
         XmlDocument doc = null;
         try
         {
            doc = new XmlDocument();
            doc.Load(getConfigFilePath());
            return doc;
         }
         catch (FileNotFoundException e)
         {
            throw new Exception("No configuration file found.", e);
         }
      }

      private static string getConfigFilePath()
      {
         return Assembly.GetExecutingAssembly().Location + ".config";
      }
   }
}