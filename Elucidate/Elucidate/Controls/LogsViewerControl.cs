using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
            listViewLogFiles.Clear();
            if (!Directory.Exists(_logSourcePath)) return;
            DirectoryInfo logFileDirectoryInfo = new DirectoryInfo(_logSourcePath);
            foreach (FileInfo log in logFileDirectoryInfo.GetFiles("*.log").OrderByDescending(a => a.Name))
            {
                listViewLogFiles.Items.Add(log.Name);
            }
        }

        private void LogsViewerControl_Load(object sender, EventArgs e)
        {
            checkedListBoxLogFiles.Items.Add("Errors");

            comboBoxLogType.DataSource = new[] { "SnapRAID Scheduled Jobs", "Elucidate" };
            comboBoxLogType.SelectedIndex = 0;
        }
        
        private void listViewLogFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(_logSourcePath)) return;
            // TODO: improve performance of large files by using stream
            if (listViewLogFiles.SelectedItems.Count == 0) return;
            var data = File.ReadAllText(_logSourcePath + listViewLogFiles.SelectedItems[0].Text);
            richTextBoxLogViewer.Text = data;
        }

        private void checkedListBoxLogFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBoxLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxLogType.SelectedIndex)
            {
                case 0:
                    // SnapRAID
                    _logSourcePath = $@"{Path.GetDirectoryName(Properties.Settings.Default.ConfigFileLocation)}\{Properties.Settings.Default.LogFileDirectory}\";
                    break;
                case 1:
                    // Elucidate
                    //_logSourcePath = $@"{AppDomain.CurrentDomain.BaseDirectory}\{Properties.Settings.Default.LogFileDirectory}\";
                    _logSourcePath = $@"{Properties.Settings.Default.NlogFileLocation}\";
                    _logSourcePath = Environment.ExpandEnvironmentVariables(_logSourcePath);
                    
                    break;
                default:
                    break;
            }

            UpdateLogFileDisplayListBox();
        }
    }
}
