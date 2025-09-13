﻿#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="LogsViewerControl.cs" company="Smurf-IV">
// 
//  Copyright (C) 2018-2025  Simon Coghlan (Aka Smurf-IV) & BlueBlock 2018
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
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using NLog;
using NLog.Targets;

namespace Elucidate.Controls;

public partial class LogsViewerControl : UserControl
{
    private static readonly Logger Log = LogManager.GetCurrentClassLogger();

    public enum LexerNameEnum { ScanRaid, NLog }
    public LexerNameEnum LexerToUse { get; set; } = LexerNameEnum.NLog;

    private readonly FileSystemWatcher logFileWatcher = new();
    private readonly string snapraidErrorSearchTerm = @"error: ";
    private readonly string snapraidWarningSearchTerm = @"WARNING";
    private readonly string elucidateErrorSearchTerm = @"] ERROR ";
    private readonly string elucidateWarningSearchTerm = @"] WARN ";

    // log file path is based upon the config file location
    private string logSourcePath;

    public LogsViewerControl()
    {
        InitializeComponent();

        logFileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName;
        //_logFileWatcher.Changed += new FileSystemEventHandler(LogFileWatcher_OnChanged);
        logFileWatcher.Created += LogFileWatcher_OnChanged;
        logFileWatcher.Deleted += LogFileWatcher_OnChanged;
        //_logFileWatcher.Renamed += new RenamedEventHandler(LogFileWatcher_OnChanged);
        logFileWatcher.EnableRaisingEvents = false;
    }

    private void LogFileWatcher_OnChanged(object sender, FileSystemEventArgs e)
    {
        // let's keep the file selected by the user as selected after the refresh
        listBoxViewLogFiles.BeginInvoke((MethodInvoker)delegate { UpdateLogFileList(); });
    }

    private void LogsViewerControl_Load(object sender, EventArgs e)
    {
        comboBoxLogType.DataSource = new[] { "SnapRAID Scheduled Jobs", "Elucidate" };
        comboBoxLogType.SelectedIndex = 0;
    }

    // Read the contents of the file.  
    private static string GetFileText(string name)
    {
        var fileContents = string.Empty;
        if (File.Exists(name))
        {
            fileContents = File.ReadAllText(name);
        }
        return fileContents;
    }

    private void UpdateLogFileList(string selectedDirectoryTitle = null)
    {
        if (selectedDirectoryTitle == null)
        {
            var fileTarget = (FileTarget)LogManager.Configuration.FindTargetByName("file");
            // Need to set timestamp here if filename uses date. 
            // For example - filename="${basedir}/logs/${shortdate}/trace.log"
            var logEventInfo = new LogEventInfo { TimeStamp = DateTime.Now };
            var fileName = fileTarget.FileName.Render(logEventInfo);
            selectedDirectoryTitle = Path.GetDirectoryName(fileName);
        }
        else
        {
            // TODO:
            //this.selectedDirectoryTitle = selectedDirectoryTitle;
        }

        string errorSearchTerm;
        string warningSearchTerm;

        // remember user selection
        string selectedIndexValue = null;
        var selectedIndex = listBoxViewLogFiles.SelectedIndex;
        if (selectedIndex >= 0)
        {
            selectedIndexValue = listBoxViewLogFiles.SelectedItems[0].ToString();
        }

        switch (selectedDirectoryTitle)
        {
            case @"SnapRAID Scheduled Jobs":
                // SnapRAID Scheduled Jobs
                errorSearchTerm = snapraidErrorSearchTerm;
                warningSearchTerm = snapraidWarningSearchTerm;
                LexerToUse = LexerNameEnum.ScanRaid;
                logSourcePath = selectedDirectoryTitle;
                if (!Directory.Exists(logSourcePath))
                {
                    return;
                }

                logFileWatcher.Path = selectedDirectoryTitle;
                logFileWatcher.Filter = "*.log";
                logFileWatcher.EnableRaisingEvents = true;
                break;

            case @"Elucidate":
                // Elucidate
                errorSearchTerm = elucidateErrorSearchTerm;
                warningSearchTerm = elucidateWarningSearchTerm;
                LexerToUse = LexerNameEnum.NLog;
                logSourcePath = selectedDirectoryTitle;
                if (!Directory.Exists(logSourcePath))
                {
                    return;
                }

                logFileWatcher.Path = selectedDirectoryTitle;
                logFileWatcher.Filter = "*.log";
                logFileWatcher.EnableRaisingEvents = true;
                break;

            default:
                logFileWatcher.EnableRaisingEvents = false;
                return;
        }

        Log.Debug($@"logSourcePath : {logSourcePath}");

        listBoxViewLogFiles.Items.Clear();

        var logFileDirectoryInfo = new DirectoryInfo(logSourcePath);

        var allLogs = logFileDirectoryInfo.GetFiles(@"*.log").OrderByDescending(static a => a.Name).ToList();

        var filteredLogs = new List<FileInfo>();

        if (checkedFilesWithError.Checked)
        {
            var filesWithErrors = from file in allLogs
                                  let fileText = GetFileText(file.FullName)
                                  where fileText.Contains(errorSearchTerm)
                                  select file;
            filteredLogs = filteredLogs.Union(filesWithErrors).ToList();
        }

        if (checkedFilesWithWarn.Checked)
        {
            var filesWithWarnings = from file in allLogs
                                    let fileText = GetFileText(file.FullName)
                                    where fileText.Contains(warningSearchTerm)
                                    select file;
            filteredLogs = filteredLogs.Union(filesWithWarnings).ToList();
        }

        var logsToShow = filteredLogs.Count > 0 ? filteredLogs : allLogs;
        logsToShow = logsToShow.OrderByDescending(static a => a.Name).ToList();
        foreach (FileInfo log in logsToShow)
        {
            listBoxViewLogFiles.Items.Add(log.Name);
        }

        // restore user selection, if it still exists
        if (selectedIndex >= 0 && !string.IsNullOrEmpty(selectedIndexValue))
        {
            var indexFound = listBoxViewLogFiles.FindStringExact(selectedIndexValue);
            if (indexFound >= 0)
            {
                listBoxViewLogFiles.SelectedIndex = indexFound;
            }
        }
    }

    private void listBoxViewLogFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!Directory.Exists(logSourcePath))
        {
            return;
        }

        if (listBoxViewLogFiles.SelectedItems.Count == 0)
        {
            return;
        }

        var fullPath = $@"{logSourcePath}\{listBoxViewLogFiles.SelectedItems[0]}";

        scintilla.ReadOnly = false;
        scintilla.Text = File.ReadAllText(fullPath);
        scintilla.ReadOnly = true;
    }

    private void comboBoxLogType_SelectedIndexChanged(object sender, EventArgs e)
    {
        listBoxViewLogFiles.BeginInvoke((MethodInvoker)delegate { UpdateLogFileList(comboBoxLogType.SelectedItem.ToString()); });
    }

    private void listBoxViewLogFiles_DoubleClick(object sender, EventArgs e)
    {
        listBoxViewLogFiles.BeginInvoke((MethodInvoker)delegate { UpdateLogFileList(comboBoxLogType.SelectedItem.ToString()); });
    }

    private void checkedFilesWithError_CheckedChanged(object sender, EventArgs e)
    {
        listBoxViewLogFiles.BeginInvoke((MethodInvoker)delegate { UpdateLogFileList(comboBoxLogType.SelectedItem.ToString()); });
    }

    private void checkedFilesWithWarn_CheckedChanged(object sender, EventArgs e)
    {
        listBoxViewLogFiles.BeginInvoke((MethodInvoker)delegate { UpdateLogFileList(comboBoxLogType.SelectedItem.ToString()); });
    }

    private void logViewToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // if (_liveRunLogControl.ActionWorker.IsBusy) { return; }

        var userAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Elucidate");

        var openFileDialog = new OpenFileDialog
        {
            InitialDirectory = Path.Combine(userAppData, @"Logs"),
            Filter = @"Log files (*.log)|*.log|Archive logs (*.*)|*.*",
            FileName = @"*.log",
            FilterIndex = 2,
            Title = @"Select name to view contents"
        };

        if (openFileDialog.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        if (Properties.Settings.Default.UseWindowsSettings)
        {
            Process word = Process.Start("Wordpad.exe", '"' + openFileDialog.FileName + '"');
            if (word == null)
            {
                return;
            }

            word.WaitForInputIdle();
            SendKeys.SendWait("^{END}");
        }
        else
        {
            // Launch whatever "Knows" how to view log files
            Process.Start('"' + openFileDialog.FileName + '"');
        }
    }
}
