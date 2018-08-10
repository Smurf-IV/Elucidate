using System.ComponentModel;
using System.Windows.Forms;
using Elucidate.Controls;
using Elucidate.Shared;

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
            this.statusStrip1 = new System.Windows.Forms.Panel();
            this.spacer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDiff = new Elucidate.Shared.CommandLinkButton();
            this.btnScrub = new Elucidate.Shared.CommandLinkButton();
            this.btnStatus = new Elucidate.Shared.CommandLinkButton();
            this.btnFix = new Elucidate.Shared.CommandLinkButton();
            this.btnDupFinder = new Elucidate.Shared.CommandLinkButton();
            this.driveSpace = new Elucidate.Controls.DriveSpaceDisplay();
            this.textBoxLogging = new Elucidate.Shared.FlickerFreeRichEditTextBox();
            this.tabCoveragePage = new System.Windows.Forms.TabPage();
            this.tabSchedulePage = new System.Windows.Forms.TabPage();
            this.SchedulePageScheduleControl = new Elucidate.Controls.Schedule();
            this.tabCommonOperations = new System.Windows.Forms.TabPage();
            this.logPanel = new System.Windows.Forms.Panel();
            this.liveRunLogControl1 = new Elucidate.Controls.LiveRunLogControl();
            this.commandPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSync = new Elucidate.Shared.CommandLinkButton();
            this.btnCheck = new Elucidate.Shared.CommandLinkButton();
            this.btnUndelete = new Elucidate.Shared.CommandLinkButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.logsViewerControl = new Elucidate.Controls.LogsViewerControl();
            this.tabRecoverFiles = new System.Windows.Forms.TabPage();
            this.recover1 = new Elucidate.Controls.Recover();
            this.snapRAIDConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logViewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLogLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VersionIndicator = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemChangelog = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNewVersionAvailable = new System.Windows.Forms.ToolStripMenuItem();
            this.installNewVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLogOfNewVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemNewVersionReadyForInstall = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.tabCoveragePage.SuspendLayout();
            this.tabSchedulePage.SuspendLayout();
            this.tabCommonOperations.SuspendLayout();
            this.logPanel.SuspendLayout();
            this.commandPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.tabRecoverFiles.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Controls.Add(this.spacer);
            this.statusStrip1.Controls.Add(this.label3);
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(3);
            this.statusStrip1.Size = new System.Drawing.Size(994, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // spacer
            // 
            this.spacer.AutoSize = true;
            this.spacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.spacer.Location = new System.Drawing.Point(14, 3);
            this.spacer.Name = "spacer";
            this.spacer.Size = new System.Drawing.Size(11, 14);
            this.spacer.TabIndex = 3;
            this.spacer.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = " ";
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
            this.btnScrub.Click += new System.EventHandler(this.btnScrub_Click);
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
            this.btnFix.Location = new System.Drawing.Point(615, 73);
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
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
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
            this.btnDupFinder.Location = new System.Drawing.Point(3, 143);
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
            this.btnDupFinder.Click += new System.EventHandler(this.btnDupFinder_Click);
            // 
            // driveSpace
            // 
            this.driveSpace.Cursor = System.Windows.Forms.Cursors.Default;
            this.driveSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.driveSpace.Location = new System.Drawing.Point(3, 3);
            this.driveSpace.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.driveSpace.Name = "driveSpace";
            this.driveSpace.Size = new System.Drawing.Size(980, 473);
            this.driveSpace.TabIndex = 0;
            this.toolTip1.SetToolTip(this.driveSpace, "Not real time, only updates when shown.");
            // 
            // textBoxLogging
            // 
            this.textBoxLogging.AutoWordSelection = true;
            this.textBoxLogging.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            // tabCoveragePage
            // 
            this.tabCoveragePage.Controls.Add(this.driveSpace);
            this.tabCoveragePage.Location = new System.Drawing.Point(4, 28);
            this.tabCoveragePage.Name = "tabCoveragePage";
            this.tabCoveragePage.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoveragePage.Size = new System.Drawing.Size(986, 479);
            this.tabCoveragePage.TabIndex = 4;
            this.tabCoveragePage.Text = "  Coverage  ";
            this.tabCoveragePage.UseVisualStyleBackColor = true;
            // 
            // tabSchedulePage
            // 
            this.tabSchedulePage.Controls.Add(this.SchedulePageScheduleControl);
            this.tabSchedulePage.Location = new System.Drawing.Point(4, 28);
            this.tabSchedulePage.Name = "tabSchedulePage";
            this.tabSchedulePage.Padding = new System.Windows.Forms.Padding(3);
            this.tabSchedulePage.Size = new System.Drawing.Size(986, 479);
            this.tabSchedulePage.TabIndex = 5;
            this.tabSchedulePage.Text = "Schedule";
            this.tabSchedulePage.UseVisualStyleBackColor = true;
            // 
            // SchedulePageScheduleControl
            // 
            this.SchedulePageScheduleControl.AutoSize = true;
            this.SchedulePageScheduleControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SchedulePageScheduleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SchedulePageScheduleControl.Location = new System.Drawing.Point(3, 3);
            this.SchedulePageScheduleControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SchedulePageScheduleControl.Name = "SchedulePageScheduleControl";
            this.SchedulePageScheduleControl.Size = new System.Drawing.Size(980, 473);
            this.SchedulePageScheduleControl.TabIndex = 0;
            // 
            // tabCommonOperations
            // 
            this.tabCommonOperations.BackColor = System.Drawing.SystemColors.Control;
            this.tabCommonOperations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabCommonOperations.Controls.Add(this.logPanel);
            this.tabCommonOperations.Controls.Add(this.commandPanel);
            this.tabCommonOperations.Location = new System.Drawing.Point(4, 28);
            this.tabCommonOperations.Margin = new System.Windows.Forms.Padding(0);
            this.tabCommonOperations.Name = "tabCommonOperations";
            this.tabCommonOperations.Size = new System.Drawing.Size(986, 479);
            this.tabCommonOperations.TabIndex = 0;
            this.tabCommonOperations.Text = "  Common SnapRaid  ";
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.liveRunLogControl1);
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logPanel.Location = new System.Drawing.Point(0, 210);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(984, 267);
            this.logPanel.TabIndex = 11;
            // 
            // liveRunLogControl1
            // 
            this.liveRunLogControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liveRunLogControl1.IsRunning = false;
            this.liveRunLogControl1.Location = new System.Drawing.Point(0, 0);
            this.liveRunLogControl1.Name = "liveRunLogControl1";
            this.liveRunLogControl1.Size = new System.Drawing.Size(984, 267);
            this.liveRunLogControl1.TabIndex = 0;
            // 
            // commandPanel
            // 
            this.commandPanel.AutoSize = true;
            this.commandPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
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
            this.commandPanel.Size = new System.Drawing.Size(984, 210);
            this.commandPanel.TabIndex = 9;
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
            this.btnSync.Location = new System.Drawing.Point(3, 73);
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
            this.btnCheck.Location = new System.Drawing.Point(309, 73);
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
            this.btnUndelete.Location = new System.Drawing.Point(309, 143);
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
            this.btnUndelete.Click += new System.EventHandler(this.btnUndelete_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCommonOperations);
            this.tabControl.Controls.Add(this.tabLogs);
            this.tabControl.Controls.Add(this.tabCoveragePage);
            this.tabControl.Controls.Add(this.tabSchedulePage);
            this.tabControl.Controls.Add(this.tabRecoverFiles);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.HotTrack = true;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(994, 511);
            this.tabControl.TabIndex = 4;
            this.tabControl.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Deselecting);
            // 
            // tabLogs
            // 
            this.tabLogs.BackColor = System.Drawing.Color.Transparent;
            this.tabLogs.Controls.Add(this.logsViewerControl);
            this.tabLogs.Location = new System.Drawing.Point(4, 28);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(986, 479);
            this.tabLogs.TabIndex = 6;
            this.tabLogs.Text = "Logs";
            // 
            // logsViewerControl
            // 
            this.logsViewerControl.AutoSize = true;
            this.logsViewerControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.logsViewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logsViewerControl.Location = new System.Drawing.Point(3, 3);
            this.logsViewerControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logsViewerControl.Name = "logsViewerControl";
            this.logsViewerControl.Size = new System.Drawing.Size(980, 473);
            this.logsViewerControl.TabIndex = 0;
            // 
            // tabRecoverFiles
            // 
            this.tabRecoverFiles.Controls.Add(this.recover1);
            this.tabRecoverFiles.Location = new System.Drawing.Point(4, 28);
            this.tabRecoverFiles.Name = "tabRecoverFiles";
            this.tabRecoverFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecoverFiles.Size = new System.Drawing.Size(986, 479);
            this.tabRecoverFiles.TabIndex = 7;
            this.tabRecoverFiles.Text = "Recover Files";
            this.tabRecoverFiles.UseVisualStyleBackColor = true;
            // 
            // recover1
            // 
            this.recover1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recover1.Location = new System.Drawing.Point(3, 3);
            this.recover1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.recover1.Name = "recover1";
            this.recover1.Size = new System.Drawing.Size(980, 473);
            this.recover1.TabIndex = 0;
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
            // MenuItemChangelog
            // 
            this.MenuItemChangelog.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuItemChangelog.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemChangelog.Name = "MenuItemChangelog";
            this.MenuItemChangelog.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.MenuItemChangelog.Size = new System.Drawing.Size(83, 20);
            this.MenuItemChangelog.Text = "C&hangeLog";
            this.MenuItemChangelog.Click += new System.EventHandler(this.changeToolStripMenuItem_Click);
            // 
            // MenuItemNewVersionAvailable
            // 
            this.MenuItemNewVersionAvailable.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuItemNewVersionAvailable.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installNewVersionToolStripMenuItem,
            this.changeLogOfNewVersionToolStripMenuItem});
            this.MenuItemNewVersionAvailable.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.MenuItemNewVersionAvailable.Name = "MenuItemNewVersionAvailable";
            this.MenuItemNewVersionAvailable.Size = new System.Drawing.Size(161, 20);
            this.MenuItemNewVersionAvailable.Text = "New Version Is Available";
            this.MenuItemNewVersionAvailable.Visible = false;
            // 
            // installNewVersionToolStripMenuItem
            // 
            this.installNewVersionToolStripMenuItem.Name = "installNewVersionToolStripMenuItem";
            this.installNewVersionToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.installNewVersionToolStripMenuItem.Text = "Install New Version";
            this.installNewVersionToolStripMenuItem.Click += new System.EventHandler(this.installNewVersionToolStripMenuItem_Click);
            // 
            // changeLogOfNewVersionToolStripMenuItem
            // 
            this.changeLogOfNewVersionToolStripMenuItem.Name = "changeLogOfNewVersionToolStripMenuItem";
            this.changeLogOfNewVersionToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.changeLogOfNewVersionToolStripMenuItem.Text = "ChangeLog of New Version";
            this.changeLogOfNewVersionToolStripMenuItem.Click += new System.EventHandler(this.changeLogOfNewVersionToolStripMenuItem_Click);
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
            this.MenuItemChangelog,
            this.MenuItemNewVersionAvailable,
            this.MenuItemNewVersionReadyForInstall});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(994, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemNewVersionReadyForInstall
            // 
            this.MenuItemNewVersionReadyForInstall.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MenuItemNewVersionReadyForInstall.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.MenuItemNewVersionReadyForInstall.Name = "MenuItemNewVersionReadyForInstall";
            this.MenuItemNewVersionReadyForInstall.Size = new System.Drawing.Size(192, 20);
            this.MenuItemNewVersionReadyForInstall.Text = "New Version Ready For Install";
            this.MenuItemNewVersionReadyForInstall.Visible = false;
            this.MenuItemNewVersionReadyForInstall.Click += new System.EventHandler(this.MenuItemNewVersionReadyForInstall_Click);
            // 
            // ElucidateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(994, 561);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(750, 598);
            this.Name = "ElucidateForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Elucidate: A SnapRAID Command Line Driver";
            this.Load += new System.EventHandler(this.ElucidateForm_Load);
            this.Shown += new System.EventHandler(this.ElucidateForm_Shown);
            this.ResizeEnd += new System.EventHandler(this.ElucidateForm_ResizeEnd);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabCoveragePage.ResumeLayout(false);
            this.tabSchedulePage.ResumeLayout(false);
            this.tabSchedulePage.PerformLayout();
            this.tabCommonOperations.ResumeLayout(false);
            this.tabCommonOperations.PerformLayout();
            this.logPanel.ResumeLayout(false);
            this.commandPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.tabLogs.PerformLayout();
            this.tabRecoverFiles.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel statusStrip1;
        private ToolTip toolTip1;
        private FlickerFreeRichEditTextBox textBoxLogging;
        private Label spacer;
        private Label label3;
        private TabControl tabControl;
        private TabPage tabCommonOperations;
        private Panel logPanel;
        private FlowLayoutPanel commandPanel;
        private CommandLinkButton btnDiff;
        private CommandLinkButton btnScrub;
        private CommandLinkButton btnStatus;
        private CommandLinkButton btnSync;
        private CommandLinkButton btnCheck;
        private CommandLinkButton btnFix;
        private CommandLinkButton btnDupFinder;
        private CommandLinkButton btnUndelete;
        private TabPage tabSchedulePage;
        private Controls.Schedule SchedulePageScheduleControl;
        private TabPage tabCoveragePage;
        private DriveSpaceDisplay driveSpace;
        private TabPage tabLogs;
        private Controls.LogsViewerControl logsViewerControl;
        private Controls.LiveRunLogControl liveRunLogControl1;
        private TabPage tabRecoverFiles;
        private Recover recover1;
        private ToolStripMenuItem snapRAIDConfigToolStripMenuItem;
        private ToolStripMenuItem logViewToolStripMenuItem;
        private ToolStripMenuItem logViewToolStripMenuItem1;
        private ToolStripMenuItem changeLogLocationToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem VersionIndicator;
        private ToolStripMenuItem MenuItemChangelog;
        private ToolStripMenuItem MenuItemNewVersionAvailable;
        private ToolStripMenuItem installNewVersionToolStripMenuItem;
        private ToolStripMenuItem changeLogOfNewVersionToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MenuItemNewVersionReadyForInstall;
    }
}

