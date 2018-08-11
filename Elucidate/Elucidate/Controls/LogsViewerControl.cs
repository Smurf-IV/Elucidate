using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Elucidate.Logging;

namespace Elucidate.Controls
{
    public partial class LogsViewerControl : UserControl
    {
        // log file path is based upon the config file location
        private string _logSourcePath;

        public LogsViewerControl()
        {
            InitializeComponent();
        }
        
        private void UpdateLogFileDisplayListBox()
        {
            listBoxViewLogFiles.Items.Clear();
            if (!Directory.Exists(_logSourcePath)) return;
            DirectoryInfo logFileDirectoryInfo = new DirectoryInfo(_logSourcePath);
            foreach (FileInfo log in logFileDirectoryInfo.GetFiles("*.log").OrderByDescending(a => a.Name))
            {
                listBoxViewLogFiles.Items.Add(log.Name);
            }
        }

        private void LogsViewerControl_Load(object sender, EventArgs e)
        {
            checkedListBoxLogFiles.Items.Add("Errors");

            comboBoxLogType.DataSource = new[] { "SnapRAID Scheduled Jobs", "Elucidate" };
            comboBoxLogType.SelectedIndex = 0;
        }

        private void DisplayLogInViewer()
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

            UpdateLogFileDisplayListBox();
        }

        private void comboBoxLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayLogInViewer();
        }

        private void listBoxViewLogFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(_logSourcePath)) return;
            if (listBoxViewLogFiles.SelectedItems.Count == 0) return;
            var data = File.ReadAllText($@"{_logSourcePath}\{listBoxViewLogFiles.SelectedItems[0]}");
            richTextBoxLogViewer.Text = data;
        }

        private void listBoxViewLogFiles_DoubleClick(object sender, EventArgs e)
        {
            UpdateLogFileDisplayListBox();
        }
    }
}
