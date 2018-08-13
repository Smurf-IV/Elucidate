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
        private readonly LexerNlog _lexerNlog = new LexerNlog(
            keywordsError: new[] { "ERROR", "FATAL" }, 
            keywordsWarning: new[] { "WARN" }, 
            keywordsDebug: new[] { "DEBUG", "TRACE" });

        private string _errorSearchTerm = "] ERROR ";
        private string _warningSearchTerm = "] WARN ";

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

        private void ChangeLogDirectoryToView()
        {
            switch (comboBoxLogType.SelectedIndex)
            {
                case 0:
                    // SnapRAID
                    _logSourcePath =
                        $@"{Path.GetDirectoryName(Properties.Settings.Default.ConfigFileLocation)}\{Properties.Settings.Default.LogFileDirectory}\";
                    break;
                case 1:
                    // Elucidate
                    _logSourcePath = LogFileLocation.GetActiveLogFileLocation();
                    break;
            }

            Log.Instance.Debug($"_logSourcePath : {_logSourcePath}");
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

        private void UpdateLogFileList()
        {
            listBoxViewLogFiles.Items.Clear();

            if (!Directory.Exists(_logSourcePath)) return;

            DirectoryInfo logFileDirectoryInfo = new DirectoryInfo(_logSourcePath);

            List<FileInfo> allLogs = logFileDirectoryInfo.GetFiles("*.log").OrderByDescending(a => a.Name).ToList();

            List<FileInfo> filteredLogs = new List<FileInfo>();

            if (checkedFilesWithError.Checked)
            {
                IEnumerable<FileInfo> filesWithErrors = from file in allLogs
                                                        let fileText = GetFileText(file.FullName)
                                                        where fileText.Contains(_errorSearchTerm)
                                                        select file;
                filteredLogs = filteredLogs.Union(filesWithErrors).ToList();
            }

            if (checkedFilesWithWarn.Checked)
            {
                IEnumerable<FileInfo> filesWithWarnings = from file in allLogs
                                                          let fileText = GetFileText(file.FullName)
                                                          where fileText.Contains(_warningSearchTerm)
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

        private void comboBoxLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeLogDirectoryToView();
            UpdateLogFileList();
        }

        private void listBoxViewLogFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(_logSourcePath)) return;
            if (listBoxViewLogFiles.SelectedItems.Count == 0) return;
            string fullPath = $@"{_logSourcePath}\{listBoxViewLogFiles.SelectedItems[0]}";

            scintillaNET.ReadOnly = false;
            scintillaNET.Text = File.ReadAllText(fullPath);
            scintillaNET.ReadOnly = true;
        }

        private void listBoxViewLogFiles_DoubleClick(object sender, EventArgs e)
        {
            UpdateLogFileList();
        }

        private void checkedFilesWithError_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLogFileList();
        }

        private void checkedFilesWithWarn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLogFileList();
        }

        private void scintillaNET_TextChanged(object sender, EventArgs e)
        {
            Scintilla scintilla = (sender as Scintilla);
            if (scintilla == null) return;

            // size the margin for the line numbers
            var maxLineNumberCharLength = scintilla.Lines.Count.ToString().Length;
            const int padding = 2;
            scintilla.Margins[0].Width = scintilla.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
            
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll();

            scintilla.Styles[LexerNlog.StyleDefault].ForeColor = Color.Black;
            scintilla.Styles[LexerNlog.StyleError].ForeColor = Color.White;
            scintilla.Styles[LexerNlog.StyleError].BackColor = Color.Firebrick;
            scintilla.Styles[LexerNlog.StyleError].Bold = true;
            scintilla.Styles[LexerNlog.StyleWarning].ForeColor = Color.White;
            scintilla.Styles[LexerNlog.StyleWarning].BackColor = Color.DarkOrange;
            scintilla.Styles[LexerNlog.StyleWarning].Bold = true;
            scintilla.Styles[LexerNlog.StyleDebug].ForeColor = Color.Gray;
            
            scintilla.Lexer = Lexer.Container;
        }

        private void scintillaNET_StyleNeeded(object sender, StyleNeededEventArgs e)
        {
            var startPos = scintillaNET.GetEndStyled();
            var endPos = e.Position;
            _lexerNlog.Style(scintillaNET, startPos, endPos);
        }
    }
}
