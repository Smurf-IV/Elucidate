using System.ComponentModel;
using System.Windows.Forms;
using Elucidate.AppTabs;
using Elucidate.Shared;
using Microsoft.Win32.TaskScheduler;

namespace Elucidate
{
    sealed partial class ElucidateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElucidateForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.snapRAIDConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logViewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLogLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionIndicator = new System.Windows.Forms.ToolStripMenuItem();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.Panel();
            this.spacer = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStripStatusLabel1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnGetSchedules = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstHistory = new Microsoft.Win32.TaskScheduler.TaskListView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnRemoveOutput = new System.Windows.Forms.Button();
            this.labelCommandLineOptions = new System.Windows.Forms.Label();
            this.txtAddCommands = new System.Windows.Forms.TextBox();
            this.menuRealTime = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteContentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.StandardOperations = new System.Windows.Forms.TabPage();
            this.addCommandPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.commandPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SchedulingPage = new System.Windows.Forms.TabPage();
            this.RecoveryOperations = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.coveragePage = new System.Windows.Forms.TabPage();
            this.miscTabPage = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnDiff = new Elucidate.Shared.CommandLinkButton();
            this.btnScrub = new Elucidate.Shared.CommandLinkButton();
            this.btnStatus = new Elucidate.Shared.CommandLinkButton();
            this.btnSync = new Elucidate.Shared.CommandLinkButton();
            this.btnCheck = new Elucidate.Shared.CommandLinkButton();
            this.btnFix = new Elucidate.Shared.CommandLinkButton();
            this.btnDupFinder = new Elucidate.Shared.CommandLinkButton();
            this.btnUndelete = new Elucidate.Shared.CommandLinkButton();
            this.textBoxLogging = new Elucidate.Shared.FlickerFreeRichEditTextBox();
            this.driveSpace = new Elucidate.AppTabs.DriveSpaceDisplay();
            this.toolStripProgressBar1 = new Elucidate.Shared.TextOverProgressBar();
            this.runWithoutCaptureMenuItem = new ToolStripCheckBoxMenuItem();
            this.miscTabCtrl = new Elucidate.AppTabs.MiscTab();
            this.logPanel = new System.Windows.Forms.Panel();
            this.textBoxLogging1 = new Elucidate.Shared.FlickerFreeRichEditTextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuRealTime.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.StandardOperations.SuspendLayout();
            this.addCommandPanel.SuspendLayout();
            this.commandPanel.SuspendLayout();
            this.SchedulingPage.SuspendLayout();
            this.RecoveryOperations.SuspendLayout();
            this.coveragePage.SuspendLayout();
            this.miscTabPage.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.snapRAIDConfigToolStripMenuItem,
            this.logViewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.VersionIndicator,
            this.runWithoutCaptureMenuItem,
            this.changeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1513, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // snapRAIDConfigToolStripMenuItem
            // 
            this.snapRAIDConfigToolStripMenuItem.Name = "snapRAIDConfigToolStripMenuItem";
            this.snapRAIDConfigToolStripMenuItem.Size = new System.Drawing.Size(191, 28);
            this.snapRAIDConfigToolStripMenuItem.Text = "Snap&RAID Config...";
            this.snapRAIDConfigToolStripMenuItem.ToolTipText = "Change the location of SnapRAID and config it\'s settings.";
            this.snapRAIDConfigToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // logViewToolStripMenuItem
            // 
            this.logViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logViewToolStripMenuItem1,
            this.changeLogLocationToolStripMenuItem});
            this.logViewToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logViewToolStripMenuItem.Name = "logViewToolStripMenuItem";
            this.logViewToolStripMenuItem.Size = new System.Drawing.Size(92, 28);
            this.logViewToolStripMenuItem.Text = "&Logging";
            this.logViewToolStripMenuItem.ToolTipText = "Open a View of Elucidates log file.";
            // 
            // logViewToolStripMenuItem1
            // 
            this.logViewToolStripMenuItem1.Name = "logViewToolStripMenuItem1";
            this.logViewToolStripMenuItem1.Size = new System.Drawing.Size(185, 30);
            this.logViewToolStripMenuItem1.Text = "&View...";
            this.logViewToolStripMenuItem1.Click += new System.EventHandler(this.logViewToolStripMenuItem_Click);
            // 
            // changeLogLocationToolStripMenuItem
            // 
            this.changeLogLocationToolStripMenuItem.Name = "changeLogLocationToolStripMenuItem";
            this.changeLogLocationToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.changeLogLocationToolStripMenuItem.Text = "&Location...";
            this.changeLogLocationToolStripMenuItem.Click += new System.EventHandler(this.changeLogLocationToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(63, 28);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.ToolTipText = "Goto the Help page.";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // VersionIndicator
            // 
            this.VersionIndicator.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.VersionIndicator.Enabled = false;
            this.VersionIndicator.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionIndicator.Name = "VersionIndicator";
            this.VersionIndicator.ShowShortcutKeys = false;
            this.VersionIndicator.Size = new System.Drawing.Size(150, 28);
            this.VersionIndicator.Text = "VersionIndicator";
            this.VersionIndicator.ToolTipText = "The build number of this application.";
            this.VersionIndicator.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.changeToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(121, 28);
            this.changeToolStripMenuItem.Text = "C&hangeLog";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.changeToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Controls.Add(this.toolStripProgressBar1);
            this.statusStrip1.Controls.Add(this.spacer);
            this.statusStrip1.Controls.Add(this.comboBox1);
            this.statusStrip1.Controls.Add(this.label3);
            this.statusStrip1.Controls.Add(this.toolStripStatusLabel1);
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusStrip1.Location = new System.Drawing.Point(0, 845);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(3);
            this.statusStrip1.Size = new System.Drawing.Size(1513, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // spacer
            // 
            this.spacer.AutoSize = true;
            this.spacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.spacer.Location = new System.Drawing.Point(329, 3);
            this.spacer.Name = "spacer";
            this.spacer.Size = new System.Drawing.Size(16, 22);
            this.spacer.TabIndex = 3;
            this.spacer.Text = " ";
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Items.AddRange(new object[] {
            "Stopped",
            "Running",
            "Abort",
            "Idle"});
            this.comboBox1.Location = new System.Drawing.Point(216, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(113, 30);
            this.comboBox1.TabIndex = 2;
            this.toolTip1.SetToolTip(this.comboBox1, "Change the state of the current running SnapRAID process.");
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(200, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = " ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = true;
            this.toolStripStatusLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Location = new System.Drawing.Point(3, 3);
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel1.MinimumSize = new System.Drawing.Size(132, 28);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(197, 28);
            this.toolStripStatusLabel1.TabIndex = 0;
            this.toolStripStatusLabel1.Text = "2011-06-012T18:54:54";
            this.toolTip1.SetToolTip(this.toolStripStatusLabel1, "Last action started @");
            // 
            // btnGetSchedules
            // 
            this.btnGetSchedules.AutoSize = true;
            this.btnGetSchedules.Location = new System.Drawing.Point(9, 37);
            this.btnGetSchedules.Name = "btnGetSchedules";
            this.btnGetSchedules.Size = new System.Drawing.Size(131, 32);
            this.btnGetSchedules.TabIndex = 5;
            this.btnGetSchedules.Text = "Get &Schedules";
            this.toolTip1.SetToolTip(this.btnGetSchedules, "Get the schedules that have been created by Elucidate.\r\nThis takes a while to ini" +
        "tialise, please be patient.");
            this.btnGetSchedules.UseVisualStyleBackColor = true;
            this.btnGetSchedules.Click += new System.EventHandler(this.btnGetSchedules_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(9, 96);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(96, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "&Edit";
            this.toolTip1.SetToolTip(this.btnEdit, "Allow the Sync Command to have edits via the task creation of this OS.\r\nThis take" +
        "s a while to initialise, please be patient.");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(9, 67);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(96, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "&New / Replace";
            this.toolTip1.SetToolTip(this.btnNew, "Fast Create a of a New Sync command");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(9, 125);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.toolTip1.SetToolTip(this.btnDelete, "Delete the named Sync task.");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstHistory
            // 
            this.lstHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstHistory.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstHistory.Location = new System.Drawing.Point(111, 7);
            this.lstHistory.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.SelectedIndex = -1;
            this.lstHistory.Size = new System.Drawing.Size(439, 274);
            this.lstHistory.TabIndex = 1;
            this.toolTip1.SetToolTip(this.lstHistory, "Shows the schedules that are in the root of \"Task Scheduler\" only.");
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowNavigation = false;
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(2, 19);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(659, 263);
            this.webBrowser1.TabIndex = 3;
            this.toolTip1.SetToolTip(this.webBrowser1, "Read section \"9 Recovering\" carefully");
            // 
            // btnRemoveOutput
            // 
            this.btnRemoveOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveOutput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveOutput.Location = new System.Drawing.Point(486, -1);
            this.btnRemoveOutput.Margin = new System.Windows.Forms.Padding(0);
            this.btnRemoveOutput.Name = "btnRemoveOutput";
            this.btnRemoveOutput.Size = new System.Drawing.Size(176, 22);
            this.btnRemoveOutput.TabIndex = 4;
            this.btnRemoveOutput.Text = "Remove Output Files";
            this.btnRemoveOutput.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.btnRemoveOutput, "This will remove all the files that SnapRAID creates.");
            this.btnRemoveOutput.UseVisualStyleBackColor = true;
            this.btnRemoveOutput.Click += new System.EventHandler(this.btnRemoveOutput_Click);
            // 
            // labelCommandLineOptions
            // 
            this.labelCommandLineOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCommandLineOptions.Location = new System.Drawing.Point(3, 4);
            this.labelCommandLineOptions.MinimumSize = new System.Drawing.Size(210, 20);
            this.labelCommandLineOptions.Name = "labelCommandLineOptions";
            this.labelCommandLineOptions.Size = new System.Drawing.Size(210, 20);
            this.labelCommandLineOptions.TabIndex = 4;
            this.labelCommandLineOptions.Text = "&Additional Command line options:";
            this.labelCommandLineOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.labelCommandLineOptions, "Example of commands:\r\n   -A, --audit-only option\r\n   -E, --force-empty\r\n   -d, --" +
        "filter-disk NAME");
            // 
            // txtAddCommands
            // 
            this.txtAddCommands.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAddCommands.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddCommands.Location = new System.Drawing.Point(217, 1);
            this.txtAddCommands.Margin = new System.Windows.Forms.Padding(1);
            this.txtAddCommands.MaxLength = 128;
            this.txtAddCommands.Name = "txtAddCommands";
            this.txtAddCommands.Size = new System.Drawing.Size(100, 22);
            this.txtAddCommands.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtAddCommands, "Example of commands:\r\n   -a,   to only check file hashes\r\n   -E, --force-empty\r\n " +
        "  -d,  to filter by disk NAME (e.g. d0)");
            this.txtAddCommands.WordWrap = false;
            // 
            // menuRealTime
            // 
            this.menuRealTime.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuRealTime.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteContentsToolStripMenuItem,
            this.copySelectedToolStripMenuItem});
            this.menuRealTime.Name = "menuRealTime";
            this.menuRealTime.Size = new System.Drawing.Size(258, 64);
            this.menuRealTime.Text = "menuStrip2";
            // 
            // deleteContentsToolStripMenuItem
            // 
            this.deleteContentsToolStripMenuItem.Name = "deleteContentsToolStripMenuItem";
            this.deleteContentsToolStripMenuItem.ShortcutKeyDisplayString = "Del";
            this.deleteContentsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteContentsToolStripMenuItem.Size = new System.Drawing.Size(257, 30);
            this.deleteContentsToolStripMenuItem.Text = "&Delete contents";
            this.deleteContentsToolStripMenuItem.Click += new System.EventHandler(this.DeleteContentsToolStripMenuItem_Click);
            // 
            // copySelectedToolStripMenuItem
            // 
            this.copySelectedToolStripMenuItem.Name = "copySelectedToolStripMenuItem";
            this.copySelectedToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.copySelectedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copySelectedToolStripMenuItem.Size = new System.Drawing.Size(257, 30);
            this.copySelectedToolStripMenuItem.Text = "&Copy selected";
            this.copySelectedToolStripMenuItem.Click += new System.EventHandler(this.CopySelectedToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.StandardOperations);
            this.tabControl1.Controls.Add(this.SchedulingPage);
            this.tabControl1.Controls.Add(this.RecoveryOperations);
            this.tabControl1.Controls.Add(this.coveragePage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1513, 813);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            this.tabControl1.Deselected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Deselected);
            // 
            // StandardOperations
            // 
            this.StandardOperations.BackColor = System.Drawing.SystemColors.Control;
            this.StandardOperations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StandardOperations.Controls.Add(this.logPanel);
            this.StandardOperations.Controls.Add(this.addCommandPanel);
            this.StandardOperations.Controls.Add(this.commandPanel);
            this.StandardOperations.Location = new System.Drawing.Point(4, 31);
            this.StandardOperations.Margin = new System.Windows.Forms.Padding(0);
            this.StandardOperations.Name = "StandardOperations";
            this.StandardOperations.Size = new System.Drawing.Size(1505, 778);
            this.StandardOperations.TabIndex = 0;
            this.StandardOperations.Text = "  Common SnapRaid  ";
            // 
            // addCommandPanel
            // 
            this.addCommandPanel.Controls.Add(this.labelCommandLineOptions);
            this.addCommandPanel.Controls.Add(this.txtAddCommands);
            this.addCommandPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.addCommandPanel.Location = new System.Drawing.Point(0, 745);
            this.addCommandPanel.MinimumSize = new System.Drawing.Size(200, 31);
            this.addCommandPanel.Name = "addCommandPanel";
            this.addCommandPanel.Size = new System.Drawing.Size(1503, 31);
            this.addCommandPanel.TabIndex = 10;
            this.addCommandPanel.WrapContents = false;
            // 
            // commandPanel
            // 
            this.commandPanel.Controls.Add(this.btnDiff);
            this.commandPanel.Controls.Add(this.btnScrub);
            this.commandPanel.Controls.Add(this.btnStatus);
            this.commandPanel.Controls.Add(this.btnSync);
            this.commandPanel.Controls.Add(this.btnCheck);
            this.commandPanel.Controls.Add(this.btnFix);
            this.commandPanel.Controls.Add(this.btnDupFinder);
            this.commandPanel.Controls.Add(this.btnUndelete);
            this.commandPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.commandPanel.Location = new System.Drawing.Point(0, 0);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(1503, 269);
            this.commandPanel.TabIndex = 9;
            // 
            // SchedulingPage
            // 
            this.SchedulingPage.Controls.Add(this.btnGetSchedules);
            this.SchedulingPage.Controls.Add(this.btnEdit);
            this.SchedulingPage.Controls.Add(this.btnNew);
            this.SchedulingPage.Controls.Add(this.btnDelete);
            this.SchedulingPage.Controls.Add(this.lstHistory);
            this.SchedulingPage.Location = new System.Drawing.Point(4, 31);
            this.SchedulingPage.Name = "SchedulingPage";
            this.SchedulingPage.Padding = new System.Windows.Forms.Padding(3);
            this.SchedulingPage.Size = new System.Drawing.Size(870, 451);
            this.SchedulingPage.TabIndex = 3;
            this.SchedulingPage.Text = "  Simple Scheduling  ";
            this.SchedulingPage.UseVisualStyleBackColor = true;
            // 
            // RecoveryOperations
            // 
            this.RecoveryOperations.BackColor = System.Drawing.SystemColors.Control;
            this.RecoveryOperations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RecoveryOperations.Controls.Add(this.btnRemoveOutput);
            this.RecoveryOperations.Controls.Add(this.webBrowser1);
            this.RecoveryOperations.Controls.Add(this.label1);
            this.RecoveryOperations.ForeColor = System.Drawing.Color.DarkRed;
            this.RecoveryOperations.Location = new System.Drawing.Point(4, 31);
            this.RecoveryOperations.Margin = new System.Windows.Forms.Padding(0);
            this.RecoveryOperations.Name = "RecoveryOperations";
            this.RecoveryOperations.Size = new System.Drawing.Size(870, 451);
            this.RecoveryOperations.TabIndex = 1;
            this.RecoveryOperations.Text = "  Recovery Help  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Read section \"&9 Recovering\" carefully";
            // 
            // coveragePage
            // 
            this.coveragePage.Controls.Add(this.driveSpace);
            this.coveragePage.Location = new System.Drawing.Point(4, 31);
            this.coveragePage.Name = "coveragePage";
            this.coveragePage.Padding = new System.Windows.Forms.Padding(3);
            this.coveragePage.Size = new System.Drawing.Size(870, 451);
            this.coveragePage.TabIndex = 4;
            this.coveragePage.Text = "  Coverage  ";
            this.coveragePage.UseVisualStyleBackColor = true;
            // 
            // miscTabPage
            // 
            this.miscTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.miscTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.miscTabPage.Controls.Add(this.miscTabCtrl);
            this.miscTabPage.Location = new System.Drawing.Point(4, 31);
            this.miscTabPage.Name = "miscTabPage";
            this.miscTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.miscTabPage.Size = new System.Drawing.Size(870, 451);
            this.miscTabPage.TabIndex = 5;
            this.miscTabPage.Text = "   Misc Commands   ";
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // btnDiff
            // 
            this.btnDiff.ButtonDepress = ((sbyte)(2));
            this.btnDiff.Enabled = false;
            this.btnDiff.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDiff.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.btnDiff.HighlightFillAlpha = ((byte)(200));
            this.btnDiff.HighlightFillAlphaMouse = ((byte)(100));
            this.btnDiff.HighlightFillAlphaNormal = ((byte)(50));
            this.btnDiff.HighlightWidth = 2F;
            this.btnDiff.Image = global::Elucidate.Properties.Resources.cam_48;
            this.btnDiff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiff.ImageMargin = 8F;
            this.btnDiff.Location = new System.Drawing.Point(3, 3);
            this.btnDiff.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnDiff.Name = "btnDiff";
            this.btnDiff.Rounding = 14F;
            this.btnDiff.Size = new System.Drawing.Size(300, 64);
            this.btnDiff.Subscript = "    Lists all the files have been modified\r\n    since the last \"sync\" command.";
            this.btnDiff.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiff.TabIndex = 3;
            this.btnDiff.Text = "&Differences";
            this.btnDiff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnDiff, "Lists all the files modified since the last \"sync\" command that need to recompute" +
        " their redundancy data.");
            this.btnDiff.UseVisualStyleBackColor = true;
            this.btnDiff.Click += new System.EventHandler(this.btnDiff_Click);
            // 
            // btnScrub
            // 
            this.btnScrub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScrub.ButtonDepress = ((sbyte)(2));
            this.btnScrub.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnScrub.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.btnScrub.HighlightFillAlpha = ((byte)(200));
            this.btnScrub.HighlightFillAlphaMouse = ((byte)(100));
            this.btnScrub.HighlightFillAlphaNormal = ((byte)(50));
            this.btnScrub.HighlightWidth = 2F;
            this.btnScrub.Image = global::Elucidate.Properties.Resources.cam_48;
            this.btnScrub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScrub.ImageMargin = 8F;
            this.btnScrub.Location = new System.Drawing.Point(309, 3);
            this.btnScrub.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnScrub.Name = "btnScrub";
            this.btnScrub.Rounding = 14F;
            this.btnScrub.Size = new System.Drawing.Size(300, 64);
            this.btnScrub.Subscript = "Scrubs the array, checking for silent\r\nand input/output errors";
            this.btnScrub.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrub.TabIndex = 8;
            this.btnScrub.Text = "&Scrub";
            this.btnScrub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnScrub, "Defaults to 100% (-p100) of all of blocks (older than 0 days = -o0).\r\nBlocks alre" +
        "ady marked as bad are always checked.\r\nUse \"Additional Command\" to override the " +
        "default of 100% of 0 days");
            this.btnScrub.UseVisualStyleBackColor = true;
            this.btnScrub.Click += new System.EventHandler(this.btnScrub2_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatus.ButtonDepress = ((sbyte)(2));
            this.btnStatus.Enabled = false;
            this.btnStatus.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.btnStatus.HighlightFillAlpha = ((byte)(200));
            this.btnStatus.HighlightFillAlphaMouse = ((byte)(100));
            this.btnStatus.HighlightFillAlphaNormal = ((byte)(50));
            this.btnStatus.HighlightWidth = 2F;
            this.btnStatus.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatus.ImageMargin = 8F;
            this.btnStatus.Location = new System.Drawing.Point(615, 3);
            this.btnStatus.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Rounding = 14F;
            this.btnStatus.Size = new System.Drawing.Size(300, 64);
            this.btnStatus.Subscript = "    A summary of the state of the disk\r\n    array, upto the last sync time.";
            this.btnStatus.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.TabIndex = 7;
            this.btnStatus.Text = "S&tatus";
            this.btnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnStatus, resources.GetString("btnStatus.ToolTip"));
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnSync
            // 
            this.btnSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSync.ButtonDepress = ((sbyte)(2));
            this.btnSync.Enabled = false;
            this.btnSync.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSync.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.btnSync.HighlightFillAlpha = ((byte)(200));
            this.btnSync.HighlightFillAlphaMouse = ((byte)(100));
            this.btnSync.HighlightFillAlphaNormal = ((byte)(50));
            this.btnSync.HighlightWidth = 2F;
            this.btnSync.Image = global::Elucidate.Properties.Resources.camera_add_48;
            this.btnSync.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSync.ImageMargin = 8F;
            this.btnSync.Location = new System.Drawing.Point(921, 3);
            this.btnSync.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnSync.Name = "btnSync";
            this.btnSync.Rounding = 14F;
            this.btnSync.Size = new System.Drawing.Size(300, 64);
            this.btnSync.Subscript = "Synchronise with any changes that may\r\nhave occurred since the last run.";
            this.btnSync.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.TabIndex = 1;
            this.btnSync.Text = "&Sync";
            this.btnSync.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.ButtonDepress = ((sbyte)(2));
            this.btnCheck.Enabled = false;
            this.btnCheck.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.btnCheck.HighlightFillAlpha = ((byte)(200));
            this.btnCheck.HighlightFillAlphaMouse = ((byte)(100));
            this.btnCheck.HighlightFillAlphaNormal = ((byte)(50));
            this.btnCheck.HighlightWidth = 2F;
            this.btnCheck.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.ImageMargin = 8F;
            this.btnCheck.Location = new System.Drawing.Point(3, 73);
            this.btnCheck.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Rounding = 14F;
            this.btnCheck.Size = new System.Drawing.Size(300, 64);
            this.btnCheck.Subscript = "Check the snapshot to confirm\r\nit\'s integrity. (use -a for hash only)";
            this.btnCheck.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "&Check";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnFix
            // 
            this.btnFix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFix.ButtonDepress = ((sbyte)(2));
            this.btnFix.Enabled = false;
            this.btnFix.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.btnFix.HighlightFillAlpha = ((byte)(200));
            this.btnFix.HighlightFillAlphaMouse = ((byte)(100));
            this.btnFix.HighlightFillAlphaNormal = ((byte)(50));
            this.btnFix.HighlightWidth = 2F;
            this.btnFix.Image = global::Elucidate.Properties.Resources.camera_add_48;
            this.btnFix.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFix.ImageMargin = 8F;
            this.btnFix.Location = new System.Drawing.Point(309, 73);
            this.btnFix.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnFix.Name = "btnFix";
            this.btnFix.Rounding = 14F;
            this.btnFix.Size = new System.Drawing.Size(300, 64);
            this.btnFix.Subscript = "Will default to using \"-e\",\r\nfix errors set by the scrub command. ";
            this.btnFix.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFix.TabIndex = 9;
            this.btnFix.Text = "&Fix";
            this.btnFix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnFix, "Override with the \"Additional Command\" options, e.g.\r\nRecover all the deleted fil" +
        "es in all drives with \"-m\" \r\n");
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnCmdFix_Click);
            // 
            // btnDupFinder
            // 
            this.btnDupFinder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDupFinder.ButtonDepress = ((sbyte)(2));
            this.btnDupFinder.Enabled = false;
            this.btnDupFinder.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.btnDupFinder.HighlightFillAlpha = ((byte)(200));
            this.btnDupFinder.HighlightFillAlphaMouse = ((byte)(100));
            this.btnDupFinder.HighlightFillAlphaNormal = ((byte)(50));
            this.btnDupFinder.HighlightWidth = 2F;
            this.btnDupFinder.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnDupFinder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDupFinder.ImageMargin = 8F;
            this.btnDupFinder.Location = new System.Drawing.Point(615, 73);
            this.btnDupFinder.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnDupFinder.Name = "btnDupFinder";
            this.btnDupFinder.Rounding = 14F;
            this.btnDupFinder.Size = new System.Drawing.Size(300, 64);
            this.btnDupFinder.Subscript = "Lists all the duplicate files. Two files are\r\nassumed equal if their hashes are m" +
    "atching. ";
            this.btnDupFinder.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDupFinder.TabIndex = 10;
            this.btnDupFinder.Text = "&Duplicate Finder";
            this.btnDupFinder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnDupFinder, "The file data is not read, but only the precomputed hashes are used.\r\nNothing is " +
        "modified\r\n");
            this.btnDupFinder.UseVisualStyleBackColor = true;
            this.btnDupFinder.Click += new System.EventHandler(this.btnCmdDupFinder_Click);
            // 
            // btnUndelete
            // 
            this.btnUndelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUndelete.ButtonDepress = ((sbyte)(2));
            this.btnUndelete.Enabled = false;
            this.btnUndelete.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.btnUndelete.HighlightFillAlpha = ((byte)(200));
            this.btnUndelete.HighlightFillAlphaMouse = ((byte)(100));
            this.btnUndelete.HighlightFillAlphaNormal = ((byte)(50));
            this.btnUndelete.HighlightWidth = 2F;
            this.btnUndelete.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnUndelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUndelete.ImageMargin = 8F;
            this.btnUndelete.Location = new System.Drawing.Point(921, 73);
            this.btnUndelete.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnUndelete.Name = "btnUndelete";
            this.btnUndelete.Rounding = 14F;
            this.btnUndelete.Size = new System.Drawing.Size(300, 64);
            this.btnUndelete.Subscript = "Recover all the deleted files in\r\nall the drives since last \"Sync\"";
            this.btnUndelete.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndelete.TabIndex = 11;
            this.btnUndelete.Text = "&Undelete";
            this.btnUndelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUndelete.UseVisualStyleBackColor = true;
            this.btnUndelete.Click += new System.EventHandler(this.btnCmdUndelete_Click);
            // 
            // textBoxLogging
            // 
            this.textBoxLogging.AutoWordSelection = true;
            this.textBoxLogging.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLogging.ContextMenuStrip = this.menuRealTime;
            this.textBoxLogging.DetectUrls = false;
            this.textBoxLogging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLogging.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLogging.Location = new System.Drawing.Point(0, 0);
            this.textBoxLogging.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxLogging.MaxLength = 20;
            this.textBoxLogging.Name = "textBoxLogging";
            this.textBoxLogging.ReadOnly = true;
            this.textBoxLogging.ShortcutsEnabled = false;
            this.textBoxLogging.Size = new System.Drawing.Size(1503, 776);
            this.textBoxLogging.TabIndex = 0;
            this.textBoxLogging.Text = "";
            this.toolTip1.SetToolTip(this.textBoxLogging, "Current output going into the log file. \r\nSelect and use [Ctrl+C] or [Ctrl+Insert" +
        "] to copy.\r\nSelect and press Delete to clear contents.");
            this.textBoxLogging.WordWrap = false;
            // 
            // driveSpace
            // 
            this.driveSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.driveSpace.Location = new System.Drawing.Point(3, 3);
            this.driveSpace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.driveSpace.Name = "driveSpace";
            this.driveSpace.Size = new System.Drawing.Size(864, 445);
            this.driveSpace.TabIndex = 0;
            this.toolTip1.SetToolTip(this.driveSpace, "Not real time, only updates when shown.");
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.ContainerControl = this;
            this.toolStripProgressBar1.DisplayText = "";
            this.toolStripProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripProgressBar1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.toolStripProgressBar1.Location = new System.Drawing.Point(345, 3);
            this.toolStripProgressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.ShowInTaskbar = true;
            this.toolStripProgressBar1.Size = new System.Drawing.Size(1165, 20);
            this.toolStripProgressBar1.Step = 3;
            this.toolStripProgressBar1.TabIndex = 1;
            this.toolStripProgressBar1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // runWithoutCaptureMenuItem
            // 
            this.runWithoutCaptureMenuItem.CheckOnClick = true;
            this.runWithoutCaptureMenuItem.Name = "runWithoutCaptureMenuItem";
            this.runWithoutCaptureMenuItem.Size = new System.Drawing.Size(226, 28);
            this.runWithoutCaptureMenuItem.Text = "   Run &Without Capture";
            this.runWithoutCaptureMenuItem.ToolTipText = "Run SnapRaid and send logs to a file rather than capturing here.";
            // 
            // miscTabCtrl
            // 
            this.miscTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscTabCtrl.Elucidate = null;
            this.miscTabCtrl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miscTabCtrl.Location = new System.Drawing.Point(3, 3);
            this.miscTabCtrl.Name = "miscTabCtrl";
            this.miscTabCtrl.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.miscTabCtrl.Size = new System.Drawing.Size(862, 443);
            this.miscTabCtrl.TabIndex = 0;
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.textBoxLogging1);
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logPanel.Location = new System.Drawing.Point(0, 269);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(1503, 476);
            this.logPanel.TabIndex = 11;
            // 
            // textBoxLogging1
            // 
            this.textBoxLogging1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLogging1.CausesValidation = false;
            this.textBoxLogging1.DetectUrls = false;
            this.textBoxLogging1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLogging1.Location = new System.Drawing.Point(0, 0);
            this.textBoxLogging1.MaxLength = 1000000;
            this.textBoxLogging1.Name = "textBoxLogging1";
            this.textBoxLogging1.ReadOnly = true;
            this.textBoxLogging1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.textBoxLogging1.Size = new System.Drawing.Size(1503, 476);
            this.textBoxLogging1.TabIndex = 0;
            this.textBoxLogging1.Text = "";
            this.toolTip1.SetToolTip(this.textBoxLogging1, "Current output going into the log file. ");
            // 
            // ElucidateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 871);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(675, 600);
            this.Name = "ElucidateForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Elucidate: A SnapRAID Command Line Driver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Elucidate_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuRealTime.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.StandardOperations.ResumeLayout(false);
            this.addCommandPanel.ResumeLayout(false);
            this.addCommandPanel.PerformLayout();
            this.commandPanel.ResumeLayout(false);
            this.SchedulingPage.ResumeLayout(false);
            this.SchedulingPage.PerformLayout();
            this.RecoveryOperations.ResumeLayout(false);
            this.RecoveryOperations.PerformLayout();
            this.coveragePage.ResumeLayout(false);
            this.miscTabPage.ResumeLayout(false);
            this.logPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem snapRAIDConfigToolStripMenuItem;
        private ToolStripMenuItem logViewToolStripMenuItem;
        private ToolStripMenuItem VersionIndicator;
        private Panel statusStrip1;
        private Label toolStripStatusLabel1;
        private TextOverProgressBar toolStripProgressBar1;
        private ToolTip toolTip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem logViewToolStripMenuItem1;
        private ToolStripMenuItem changeLogLocationToolStripMenuItem;
        private FlickerFreeRichEditTextBox textBoxLogging;
        private TabPage RecoveryOperations;
        private WebBrowser webBrowser1;
        private Label label1;
        private TabPage StandardOperations;
        private CommandLinkButton btnDiff;
        private CommandLinkButton btnCheck;
        private CommandLinkButton btnSync;
        private TabControl tabControl1;
        private TabPage SchedulingPage;
        private TaskListView lstHistory;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnNew;
        private Button btnGetSchedules;
        private ContextMenuStrip menuRealTime;
        private ToolStripMenuItem deleteContentsToolStripMenuItem;
        private ComboBox comboBox1;
        private Button btnRemoveOutput;
        private Timer timer1;
        private Label labelCommandLineOptions;
        private TabPage coveragePage;
        private DriveSpaceDisplay driveSpace;
        private ToolStripCheckBoxMenuItem runWithoutCaptureMenuItem;
        private ToolStripMenuItem copySelectedToolStripMenuItem;
        private ToolStripMenuItem changeToolStripMenuItem;
        private CommandLinkButton btnStatus;
        private TabPage miscTabPage;
        private Label spacer;
        private Label label3;
        private MiscTab miscTabCtrl;
        private CommandLinkButton btnScrub;
        private FlowLayoutPanel commandPanel;
        private FlowLayoutPanel addCommandPanel;
        private TextBox txtAddCommands;
        private CommandLinkButton btnFix;
        private CommandLinkButton btnDupFinder;
        private CommandLinkButton btnUndelete;
        private Panel logPanel;
        private FlickerFreeRichEditTextBox textBoxLogging1;
    }
}

