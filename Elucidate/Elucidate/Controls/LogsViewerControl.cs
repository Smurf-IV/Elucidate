using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Elucidate.HelperClasses;
using Elucidate.Logging;
using ScintillaNET;

namespace Elucidate.Controls
{
    public partial class LogsViewerControl : UserControl
    {
        public enum LexerNameEnum { ScanRaid, NLog }

        public LexerNameEnum LexerToUse { get; set; } = LexerNameEnum.NLog;

        private readonly LexerNlog _lexerNlog = new LexerNlog(
            keywordsError: new[] { "ERROR", "FATAL" }, 
            keywordsWarning: new[] { "WARN" }, 
            keywordsDebug: new[] { "DEBUG", "TRACE" });

        private readonly LexerScanRaid _lexerScanRaid = new LexerScanRaid();

        private string _snapraidErrorSearchTerm = "error: ";
        private string _snapraidWarningSearchTerm = "WARNING";
        private string _elucidateErrorSearchTerm = "] ERROR ";
        private string _elucidateWarningSearchTerm = "] WARN ";

        // log file path is based upon the config file location
        private string _logSourcePath;

        public LogsViewerControl()
        {
            InitializeComponent();
        }

        private void LogsViewerControl_Load(object sender, EventArgs e)
        {
            comboBoxLogType.DataSource = new[] { "SnapRAID Scheduled Jobs", "Elucidate" };
            comboBoxLogType.SelectedIndex = 0;
        }

        // Read the contents of the file.  
        static string GetFileText(string name)
        {
            string fileContents = String.Empty;
            if (File.Exists(name))
            {
                fileContents = File.ReadAllText(name);
            }
            return fileContents;
        }

        private void UpdateLogFileList(string selectedDirectoryTitle)
        {
            string errorSearchTerm;
            string warningSearchTerm;

            switch (selectedDirectoryTitle)
            {
                case "SnapRAID Scheduled Jobs":
                    // SnapRAID Scheduled Jobs
                    _logSourcePath = $@"{Path.GetDirectoryName(Properties.Settings.Default.ConfigFileLocation)}\{Properties.Settings.Default.LogFileDirectory}\";
                    errorSearchTerm = _snapraidErrorSearchTerm;
                    warningSearchTerm = _snapraidWarningSearchTerm;
                    LexerToUse = LexerNameEnum.ScanRaid;
                    break;
                case "Elucidate":
                    // Elucidate
                    _logSourcePath = LogFileLocation.GetActiveLogFileLocation();
                    errorSearchTerm = _elucidateErrorSearchTerm;
                    warningSearchTerm = _elucidateWarningSearchTerm;
                    LexerToUse = LexerNameEnum.NLog;
                    break;
                default:
                    return;
            }

            Log.Instance.Debug($"_logSourcePath : {_logSourcePath}");

            listBoxViewLogFiles.Items.Clear();

            if (!Directory.Exists(_logSourcePath)) return;

            DirectoryInfo logFileDirectoryInfo = new DirectoryInfo(_logSourcePath);

            List<FileInfo> allLogs = logFileDirectoryInfo.GetFiles("*.log").OrderByDescending(a => a.Name).ToList();

            List<FileInfo> filteredLogs = new List<FileInfo>();

            if (checkedFilesWithError.Checked)
            {
                IEnumerable<FileInfo> filesWithErrors = from file in allLogs
                                                        let fileText = GetFileText(file.FullName)
                                                        where fileText.Contains(errorSearchTerm)
                                                        select file;
                filteredLogs = filteredLogs.Union(filesWithErrors).ToList();
            }

            if (checkedFilesWithWarn.Checked)
            {
                IEnumerable<FileInfo> filesWithWarnings = from file in allLogs
                                                          let fileText = GetFileText(file.FullName)
                                                          where fileText.Contains(warningSearchTerm)
                                                          select file;
                filteredLogs = filteredLogs.Union(filesWithWarnings).ToList();
            }

            List<FileInfo> logsToShow = filteredLogs.Count > 0 ? filteredLogs : allLogs;
            logsToShow = logsToShow.OrderByDescending(a => a.Name).ToList();
            foreach (FileInfo log in logsToShow)
            {
                listBoxViewLogFiles.Items.Add(log.Name);
            }
        }
        
        private void listBoxViewLogFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(_logSourcePath)) return;
            if (listBoxViewLogFiles.SelectedItems.Count == 0) return;
            string fullPath = $@"{_logSourcePath}\{listBoxViewLogFiles.SelectedItems[0]}";

            scintilla.ReadOnly = false;
            scintilla.Text = File.ReadAllText(fullPath);
            scintilla.ReadOnly = true;
        }

        private void comboBoxLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLogFileList(comboBoxLogType.SelectedItem.ToString());
        }

        private void listBoxViewLogFiles_DoubleClick(object sender, EventArgs e)
        {
            UpdateLogFileList(comboBoxLogType.SelectedItem.ToString());
        }

        private void checkedFilesWithError_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLogFileList(comboBoxLogType.SelectedItem.ToString());
        }

        private void checkedFilesWithWarn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLogFileList(comboBoxLogType.SelectedItem.ToString());
        }

        private void scintilla_TextChanged(object sender, EventArgs e)
        {
            Scintilla control = (sender as Scintilla);
            if (control == null) return;

            // size the margin for the line numbers
            var maxLineNumberCharLength = control.Lines.Count.ToString().Length;
            const int padding = 2;
            control.Margins[0].Width = control.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;

            control.StyleResetDefault();
            control.Styles[Style.Default].Font = "Consolas";
            control.Styles[Style.Default].Size = 10;
            control.StyleClearAll();

            switch (LexerToUse)
            {
                case LexerNameEnum.NLog:
                    control.Styles[LexerNlog.StyleDefault].ForeColor = Color.Black;
                    control.Styles[LexerNlog.StyleError].ForeColor = Color.White;
                    control.Styles[LexerNlog.StyleError].BackColor = Color.Firebrick;
                    control.Styles[LexerNlog.StyleError].Bold = true;
                    control.Styles[LexerNlog.StyleWarning].ForeColor = Color.White;
                    control.Styles[LexerNlog.StyleWarning].BackColor = Color.DarkOrange;
                    control.Styles[LexerNlog.StyleWarning].Bold = true;
                    control.Styles[LexerNlog.StyleDebug].ForeColor = Color.Gray;
                    break;
                case LexerNameEnum.ScanRaid:
                    control.Styles[LexerScanRaid.StyleDefault].ForeColor = Color.Black;
                    control.Styles[LexerScanRaid.StyleError].ForeColor = Color.White;
                    control.Styles[LexerScanRaid.StyleError].BackColor = Color.Firebrick;
                    control.Styles[LexerScanRaid.StyleError].Bold = true;
                    control.Styles[LexerScanRaid.StyleWarning].ForeColor = Color.White;
                    control.Styles[LexerScanRaid.StyleWarning].BackColor = Color.DarkOrange;
                    control.Styles[LexerScanRaid.StyleWarning].Bold = true;
                    control.Styles[LexerScanRaid.StyleDebug].ForeColor = Color.Gray;
                    break;
            }
            
            control.Lexer = Lexer.Container;
        }

        private void scintilla_StyleNeeded(object sender, StyleNeededEventArgs e)
        {
            var startPos = scintilla.GetEndStyled();
            var endPos = e.Position;
            
            switch (LexerToUse)
            {
                case LexerNameEnum.NLog:
                    _lexerNlog.Style(scintilla, startPos, endPos);
                    break;
                case LexerNameEnum.ScanRaid:
                    _lexerScanRaid.Style(scintilla, startPos, endPos);
                    break;
            }
        }
    }
}
