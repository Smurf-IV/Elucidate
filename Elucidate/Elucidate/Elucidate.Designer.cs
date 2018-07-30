using System.ComponentModel;
using System.Windows.Forms;
using GUIUtils;
using Microsoft.Win32.TaskScheduler;
using Shared;

namespace Elucidate
{
   sealed partial class Elucidate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Elucidate));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.snapRAIDConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logViewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLogLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionIndicator = new System.Windows.Forms.ToolStripMenuItem();
            this.runWithoutCaptureMenuItem = new ToolStripCheckBoxMenuItem();
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.Panel();
            this.toolStripProgressBar1 = new Shared.TextOverProgressBar();
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddCommands = new System.Windows.Forms.TextBox();
            this.textBox1 = new Shared.FlickerFreeRichEditTextBox();
            this.menuRealTime = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteContentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driveSpace = new GUIUtils.DriveSpaceDisplay();
            this.btnDiff = new Shared.CommandLinkButton();
            this.btnStatus = new Shared.CommandLinkButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.StandardOperations = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCheck = new Shared.CommandLinkButton();
            this.btnSync = new Shared.CommandLinkButton();
            this.realTimeOutputTabPage = new System.Windows.Forms.TabPage();
            this.miscTabPage = new System.Windows.Forms.TabPage();
            this.miscTabCtrl = new GUIUtils.MiscTab();
            this.SchedulingPage = new System.Windows.Forms.TabPage();
            this.RecoveryOperations = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.coveragePage = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuRealTime.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.StandardOperations.SuspendLayout();
            this.panel1.SuspendLayout();
            this.realTimeOutputTabPage.SuspendLayout();
            this.miscTabPage.SuspendLayout();
            this.SchedulingPage.SuspendLayout();
            this.RecoveryOperations.SuspendLayout();
            this.coveragePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.menuStrip1.Size = new System.Drawing.Size(724, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // snapRAIDConfigToolStripMenuItem
            // 
            this.snapRAIDConfigToolStripMenuItem.Name = "snapRAIDConfigToolStripMenuItem";
            this.snapRAIDConfigToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
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
            this.logViewToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.logViewToolStripMenuItem.Text = "&Logging";
            this.logViewToolStripMenuItem.ToolTipText = "Open a View of Elucidates log file.";
            // 
            // logViewToolStripMenuItem1
            // 
            this.logViewToolStripMenuItem1.Name = "logViewToolStripMenuItem1";
            this.logViewToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.logViewToolStripMenuItem1.Text = "&View...";
            this.logViewToolStripMenuItem1.Click += new System.EventHandler(this.logViewToolStripMenuItem_Click);
            // 
            // changeLogLocationToolStripMenuItem
            // 
            this.changeLogLocationToolStripMenuItem.Name = "changeLogLocationToolStripMenuItem";
            this.changeLogLocationToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.changeLogLocationToolStripMenuItem.Text = "&Location...";
            this.changeLogLocationToolStripMenuItem.Click += new System.EventHandler(this.changeLogLocationToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
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
            this.VersionIndicator.Size = new System.Drawing.Size(107, 20);
            this.VersionIndicator.Text = "VersionIndicator";
            this.VersionIndicator.ToolTipText = "The build number of this application.";
            this.VersionIndicator.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // runWithoutCaptureMenuItem
            // 
            this.runWithoutCaptureMenuItem.CheckOnClick = true;
            this.runWithoutCaptureMenuItem.Name = "runWithoutCaptureMenuItem";
            this.runWithoutCaptureMenuItem.Size = new System.Drawing.Size(151, 20);
            this.runWithoutCaptureMenuItem.Text = "   Run &Without Capture";
            this.runWithoutCaptureMenuItem.ToolTipText = "Run SnapRaid and send logs to a file rather than capturing here.";
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.changeToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 485);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(3);
            this.statusStrip1.Size = new System.Drawing.Size(724, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.ContainerControl = this;
            this.toolStripProgressBar1.DisplayText = "";
            this.toolStripProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripProgressBar1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.toolStripProgressBar1.Location = new System.Drawing.Point(274, 3);
            this.toolStripProgressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.ShowInTaskbar = true;
            this.toolStripProgressBar1.Size = new System.Drawing.Size(447, 20);
            this.toolStripProgressBar1.Step = 3;
            this.toolStripProgressBar1.TabIndex = 1;
            this.toolStripProgressBar1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // spacer
            // 
            this.spacer.AutoSize = true;
            this.spacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.spacer.Location = new System.Drawing.Point(263, 3);
            this.spacer.Name = "spacer";
            this.spacer.Size = new System.Drawing.Size(11, 14);
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
            this.comboBox1.Location = new System.Drawing.Point(150, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(113, 22);
            this.comboBox1.TabIndex = 2;
            this.toolTip1.SetToolTip(this.comboBox1, "Change the state of the current running SnapRAID process.");
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(139, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 14);
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(136, 28);
            this.toolStripStatusLabel1.TabIndex = 0;
            this.toolStripStatusLabel1.Text = "2011-06-012T18:54:54";
            this.toolTip1.SetToolTip(this.toolStripStatusLabel1, "Last action started @");
            // 
            // btnGetSchedules
            // 
            this.btnGetSchedules.AutoSize = true;
            this.btnGetSchedules.Location = new System.Drawing.Point(9, 37);
            this.btnGetSchedules.Name = "btnGetSchedules";
            this.btnGetSchedules.Size = new System.Drawing.Size(96, 24);
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
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 412);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "&Additional Command line options:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.label2, "Example of commands:\r\n   -A, --audit-only option\r\n   -E, --force-empty\r\n   -d, --" +
        "filter-disk NAME");
            // 
            // txtAddCommands
            // 
            this.txtAddCommands.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddCommands.Location = new System.Drawing.Point(2, 2);
            this.txtAddCommands.Margin = new System.Windows.Forms.Padding(1);
            this.txtAddCommands.MaxLength = 128;
            this.txtAddCommands.Name = "txtAddCommands";
            this.txtAddCommands.Size = new System.Drawing.Size(501, 15);
            this.txtAddCommands.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtAddCommands, "Example of commands:\r\n   -a,   to only check file hashes\r\n   -E, --force-empty\r\n " +
        "  -d,  to filter by disk NAME (e.g. d0)");
            this.txtAddCommands.WordWrap = false;
            // 
            // textBox1
            // 
            this.textBox1.AutoWordSelection = true;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ContextMenuStrip = this.menuRealTime;
            this.textBox1.DetectUrls = false;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(714, 432);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "";
            this.toolTip1.SetToolTip(this.textBox1, "Current output going into the log file. \r\nSelect and use [Ctrl+C] or [Ctrl+Insert" +
        "] to copy.\r\nSelect and press Delete to clear contents.");
            this.textBox1.WordWrap = false;
            // 
            // menuRealTime
            // 
            this.menuRealTime.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteContentsToolStripMenuItem,
            this.copySelectedToolStripMenuItem});
            this.menuRealTime.Name = "menuRealTime";
            this.menuRealTime.Size = new System.Drawing.Size(191, 48);
            this.menuRealTime.Text = "menuStrip2";
            // 
            // deleteContentsToolStripMenuItem
            // 
            this.deleteContentsToolStripMenuItem.Name = "deleteContentsToolStripMenuItem";
            this.deleteContentsToolStripMenuItem.ShortcutKeyDisplayString = "Del";
            this.deleteContentsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteContentsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.deleteContentsToolStripMenuItem.Text = "&Delete contents";
            this.deleteContentsToolStripMenuItem.Click += new System.EventHandler(this.DeleteContentsToolStripMenuItem_Click);
            // 
            // copySelectedToolStripMenuItem
            // 
            this.copySelectedToolStripMenuItem.Name = "copySelectedToolStripMenuItem";
            this.copySelectedToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.copySelectedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copySelectedToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.copySelectedToolStripMenuItem.Text = "&Copy selected";
            this.copySelectedToolStripMenuItem.Click += new System.EventHandler(this.CopySelectedToolStripMenuItem_Click);
            // 
            // driveSpace
            // 
            this.driveSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.driveSpace.Location = new System.Drawing.Point(3, 3);
            this.driveSpace.Name = "driveSpace";
            this.driveSpace.Size = new System.Drawing.Size(710, 428);
            this.driveSpace.TabIndex = 0;
            this.toolTip1.SetToolTip(this.driveSpace, "Not real time, only updates when shown.");
            // 
            // btnDiff
            // 
            this.btnDiff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnDiff.Location = new System.Drawing.Point(7, 19);
            this.btnDiff.Name = "btnDiff";
            this.btnDiff.Rounding = 14F;
            this.btnDiff.Size = new System.Drawing.Size(700, 74);
            this.btnDiff.Subscript = "    Lists all the files have been modified since the last \"sync\" command.";
            this.btnDiff.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiff.TabIndex = 3;
            this.btnDiff.Text = "&Differences";
            this.btnDiff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnDiff, "Lists all the files modified since the last \"sync\" command that need to recompute" +
        " their redundancy data.");
            this.btnDiff.UseVisualStyleBackColor = true;
            this.btnDiff.Click += new System.EventHandler(this.btnDiff_Click);
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
            this.btnStatus.Location = new System.Drawing.Point(7, 284);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Rounding = 14F;
            this.btnStatus.Size = new System.Drawing.Size(700, 74);
            this.btnStatus.Subscript = "    A summary of the state of the disk array, upto the last sync time.";
            this.btnStatus.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.TabIndex = 7;
            this.btnStatus.Text = "S&tatus";
            this.btnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnStatus, resources.GetString("btnStatus.ToolTip"));
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.StandardOperations);
            this.tabControl1.Controls.Add(this.realTimeOutputTabPage);
            this.tabControl1.Controls.Add(this.miscTabPage);
            this.tabControl1.Controls.Add(this.SchedulingPage);
            this.tabControl1.Controls.Add(this.RecoveryOperations);
            this.tabControl1.Controls.Add(this.coveragePage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(724, 461);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            this.tabControl1.Deselected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Deselected);
            // 
            // StandardOperations
            // 
            this.StandardOperations.BackColor = System.Drawing.SystemColors.Control;
            this.StandardOperations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StandardOperations.Controls.Add(this.btnStatus);
            this.StandardOperations.Controls.Add(this.panel1);
            this.StandardOperations.Controls.Add(this.label2);
            this.StandardOperations.Controls.Add(this.btnDiff);
            this.StandardOperations.Controls.Add(this.btnCheck);
            this.StandardOperations.Controls.Add(this.btnSync);
            this.StandardOperations.Location = new System.Drawing.Point(4, 23);
            this.StandardOperations.Margin = new System.Windows.Forms.Padding(0);
            this.StandardOperations.Name = "StandardOperations";
            this.StandardOperations.Size = new System.Drawing.Size(716, 434);
            this.StandardOperations.TabIndex = 0;
            this.StandardOperations.Text = "  Common SnapRaid  ";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.txtAddCommands);
            this.panel1.Location = new System.Drawing.Point(207, 409);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(505, 19);
            this.panel1.TabIndex = 6;
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
            this.btnCheck.Location = new System.Drawing.Point(7, 197);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Rounding = 14F;
            this.btnCheck.Size = new System.Drawing.Size(700, 74);
            this.btnCheck.Subscript = "    Run a check over the whole snapshot to confirm it\'s integrity. (use -a for ha" +
    "sh only)";
            this.btnCheck.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "&Check";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
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
            this.btnSync.Location = new System.Drawing.Point(7, 108);
            this.btnSync.Name = "btnSync";
            this.btnSync.Rounding = 14F;
            this.btnSync.Size = new System.Drawing.Size(700, 74);
            this.btnSync.Subscript = "    Synchronise with any changes that may have occurred since the last run.";
            this.btnSync.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.TabIndex = 1;
            this.btnSync.Text = "&Sync";
            this.btnSync.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // realTimeOutputTabPage
            // 
            this.realTimeOutputTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.realTimeOutputTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.realTimeOutputTabPage.Controls.Add(this.textBox1);
            this.realTimeOutputTabPage.Location = new System.Drawing.Point(4, 23);
            this.realTimeOutputTabPage.Margin = new System.Windows.Forms.Padding(0);
            this.realTimeOutputTabPage.Name = "realTimeOutputTabPage";
            this.realTimeOutputTabPage.Size = new System.Drawing.Size(716, 434);
            this.realTimeOutputTabPage.TabIndex = 2;
            this.realTimeOutputTabPage.Text = "  Captured Logging  ";
            // 
            // miscTabPage
            // 
            this.miscTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.miscTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.miscTabPage.Controls.Add(this.miscTabCtrl);
            this.miscTabPage.Location = new System.Drawing.Point(4, 23);
            this.miscTabPage.Name = "miscTabPage";
            this.miscTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.miscTabPage.Size = new System.Drawing.Size(716, 434);
            this.miscTabPage.TabIndex = 5;
            this.miscTabPage.Text = "   Misc Commands   ";
            // 
            // miscTabCtrl
            // 
            this.miscTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscTabCtrl.Elucidate = null;
            this.miscTabCtrl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miscTabCtrl.Location = new System.Drawing.Point(3, 3);
            this.miscTabCtrl.Name = "miscTabCtrl";
            this.miscTabCtrl.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.miscTabCtrl.Size = new System.Drawing.Size(708, 426);
            this.miscTabCtrl.TabIndex = 0;
            // 
            // SchedulingPage
            // 
            this.SchedulingPage.Controls.Add(this.btnGetSchedules);
            this.SchedulingPage.Controls.Add(this.btnEdit);
            this.SchedulingPage.Controls.Add(this.btnNew);
            this.SchedulingPage.Controls.Add(this.btnDelete);
            this.SchedulingPage.Controls.Add(this.lstHistory);
            this.SchedulingPage.Location = new System.Drawing.Point(4, 23);
            this.SchedulingPage.Name = "SchedulingPage";
            this.SchedulingPage.Padding = new System.Windows.Forms.Padding(3);
            this.SchedulingPage.Size = new System.Drawing.Size(716, 434);
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
            this.RecoveryOperations.Location = new System.Drawing.Point(4, 23);
            this.RecoveryOperations.Margin = new System.Windows.Forms.Padding(0);
            this.RecoveryOperations.Name = "RecoveryOperations";
            this.RecoveryOperations.Size = new System.Drawing.Size(716, 434);
            this.RecoveryOperations.TabIndex = 1;
            this.RecoveryOperations.Text = "  Recovery Help  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Read section \"&9 Recovering\" carefully";
            // 
            // coveragePage
            // 
            this.coveragePage.Controls.Add(this.driveSpace);
            this.coveragePage.Location = new System.Drawing.Point(4, 23);
            this.coveragePage.Name = "coveragePage";
            this.coveragePage.Padding = new System.Windows.Forms.Padding(3);
            this.coveragePage.Size = new System.Drawing.Size(716, 434);
            this.coveragePage.TabIndex = 4;
            this.coveragePage.Text = "  Coverage  ";
            this.coveragePage.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Elucidate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 511);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(690, 550);
            this.Name = "Elucidate";
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
            this.StandardOperations.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.realTimeOutputTabPage.ResumeLayout(false);
            this.miscTabPage.ResumeLayout(false);
            this.SchedulingPage.ResumeLayout(false);
            this.SchedulingPage.PerformLayout();
            this.RecoveryOperations.ResumeLayout(false);
            this.RecoveryOperations.PerformLayout();
            this.coveragePage.ResumeLayout(false);
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
      private TabPage realTimeOutputTabPage;
      private FlickerFreeRichEditTextBox textBox1;
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
      private Panel panel1;
      private TextBox txtAddCommands;
      private Label label2;
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

   }
}

