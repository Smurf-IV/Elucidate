using System.ComponentModel;
using System.Windows.Forms;
using Elucidate.Controls;
using Elucidate.Shared;
using Elucidate.TabPages;

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
            this.tabCoveragePage = new System.Windows.Forms.TabPage();
            this.driveSpaceDisplay = new Elucidate.Controls.ProtectedDrivesDisplay();
            this.tabSchedulePage = new System.Windows.Forms.TabPage();
            this.SchedulePageScheduleControl = new Elucidate.Controls.Schedule();
            this.tabCommonOperations = new System.Windows.Forms.TabPage();
            this.logPanel = new System.Windows.Forms.Panel();
            this.commonTab = new Elucidate.TabPages.CommonTab();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.logsViewerControl = new Elucidate.Controls.LogsViewerControl();
            this.tabRecoverFiles = new System.Windows.Forms.TabPage();
            this.recover1 = new Elucidate.Controls.Recover();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dangerZoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.tabCoveragePage.SuspendLayout();
            this.tabSchedulePage.SuspendLayout();
            this.tabCommonOperations.SuspendLayout();
            this.logPanel.SuspendLayout();
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
            this.statusStrip1.Size = new System.Drawing.Size(945, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // spacer
            // 
            this.spacer.AutoSize = true;
            this.spacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.spacer.Location = new System.Drawing.Point(17, 3);
            this.spacer.Name = "spacer";
            this.spacer.Size = new System.Drawing.Size(14, 19);
            this.spacer.TabIndex = 3;
            this.spacer.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = " ";
            // 
            // tabCoveragePage
            // 
            this.tabCoveragePage.Controls.Add(this.driveSpaceDisplay);
            this.tabCoveragePage.Location = new System.Drawing.Point(4, 28);
            this.tabCoveragePage.Name = "tabCoveragePage";
            this.tabCoveragePage.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoveragePage.Size = new System.Drawing.Size(937, 476);
            this.tabCoveragePage.TabIndex = 4;
            this.tabCoveragePage.Text = "  Coverage  ";
            this.tabCoveragePage.UseVisualStyleBackColor = true;
            // 
            // driveSpaceDisplay
            // 
            this.driveSpaceDisplay.AllowDrop = true;
            this.driveSpaceDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.driveSpaceDisplay.Location = new System.Drawing.Point(3, 3);
            this.driveSpaceDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.driveSpaceDisplay.Name = "driveSpaceDisplay";
            this.driveSpaceDisplay.Size = new System.Drawing.Size(931, 470);
            this.driveSpaceDisplay.TabIndex = 0;
            // 
            // tabSchedulePage
            // 
            this.tabSchedulePage.Controls.Add(this.SchedulePageScheduleControl);
            this.tabSchedulePage.Location = new System.Drawing.Point(4, 28);
            this.tabSchedulePage.Name = "tabSchedulePage";
            this.tabSchedulePage.Padding = new System.Windows.Forms.Padding(3);
            this.tabSchedulePage.Size = new System.Drawing.Size(937, 476);
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
            this.SchedulePageScheduleControl.Size = new System.Drawing.Size(931, 470);
            this.SchedulePageScheduleControl.TabIndex = 0;
            // 
            // tabCommonOperations
            // 
            this.tabCommonOperations.BackColor = System.Drawing.SystemColors.Control;
            this.tabCommonOperations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabCommonOperations.Controls.Add(this.logPanel);
            this.tabCommonOperations.Location = new System.Drawing.Point(4, 28);
            this.tabCommonOperations.Margin = new System.Windows.Forms.Padding(0);
            this.tabCommonOperations.Name = "tabCommonOperations";
            this.tabCommonOperations.Size = new System.Drawing.Size(937, 476);
            this.tabCommonOperations.TabIndex = 0;
            this.tabCommonOperations.Text = "  Common SnapRaid  ";
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.commonTab);
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logPanel.Location = new System.Drawing.Point(0, 0);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(935, 474);
            this.logPanel.TabIndex = 11;
            // 
            // commonTab
            // 
            this.commonTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonTab.Location = new System.Drawing.Point(0, 0);
            this.commonTab.Name = "commonTab";
            this.commonTab.Size = new System.Drawing.Size(935, 474);
            this.commonTab.TabIndex = 0;
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
            this.tabControl.Location = new System.Drawing.Point(0, 27);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(0, 0);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(945, 508);
            this.tabControl.TabIndex = 4;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            this.tabControl.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Deselecting);
            // 
            // tabLogs
            // 
            this.tabLogs.BackColor = System.Drawing.Color.Transparent;
            this.tabLogs.Controls.Add(this.logsViewerControl);
            this.tabLogs.Location = new System.Drawing.Point(4, 28);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(937, 476);
            this.tabLogs.TabIndex = 6;
            this.tabLogs.Text = "Log History";
            // 
            // logsViewerControl
            // 
            this.logsViewerControl.AutoSize = true;
            this.logsViewerControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.logsViewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logsViewerControl.LexerToUse = Elucidate.Controls.LogsViewerControl.LexerNameEnum.ScanRaid;
            this.logsViewerControl.Location = new System.Drawing.Point(3, 3);
            this.logsViewerControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logsViewerControl.Name = "logsViewerControl";
            this.logsViewerControl.Size = new System.Drawing.Size(931, 470);
            this.logsViewerControl.TabIndex = 0;
            // 
            // tabRecoverFiles
            // 
            this.tabRecoverFiles.Controls.Add(this.recover1);
            this.tabRecoverFiles.Location = new System.Drawing.Point(4, 28);
            this.tabRecoverFiles.Name = "tabRecoverFiles";
            this.tabRecoverFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabRecoverFiles.Size = new System.Drawing.Size(937, 476);
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
            this.recover1.Size = new System.Drawing.Size(931, 470);
            this.recover1.TabIndex = 0;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.ToolTipText = "Goto the Help page.";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.dangerZoneToolStripMenuItem,
            this.changeLogToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(945, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(77, 23);
            this.fileToolStripMenuItem.Text = "&Settings";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.EditSnapRAIDConfigToolStripMenuItem_Click);
            // 
            // dangerZoneToolStripMenuItem
            // 
            this.dangerZoneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem});
            this.dangerZoneToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dangerZoneToolStripMenuItem.Name = "dangerZoneToolStripMenuItem";
            this.dangerZoneToolStripMenuItem.Size = new System.Drawing.Size(112, 23);
            this.dangerZoneToolStripMenuItem.Text = "Danger Zone";
            // 
            // deleteAllSnapRAIDRaidFilesToolStripMenuItem
            // 
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem.Name = "deleteAllSnapRAIDRaidFilesToolStripMenuItem";
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem.Text = "Delete all SnapRAID files";
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem.ToolTipText = "This will delete all parity and content files defined in the current configuratio" +
    "n file.";
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem.Click += new System.EventHandler(this.deleteAllSnapRAIDRaidFilesToolStripMenuItem_Click);
            // 
            // changeLogToolStripMenuItem
            // 
            this.changeLogToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.changeLogToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeLogToolStripMenuItem.Name = "changeLogToolStripMenuItem";
            this.changeLogToolStripMenuItem.Size = new System.Drawing.Size(100, 23);
            this.changeLogToolStripMenuItem.Text = "ChangeLog";
            this.changeLogToolStripMenuItem.Click += new System.EventHandler(this.changeLogToolStripMenuItem_Click);
            // 
            // ElucidateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(945, 561);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(748, 592);
            this.Name = "ElucidateForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Elucidate";
            this.UseDropShadow = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElucidateForm_FormClosing);
            this.Load += new System.EventHandler(this.ElucidateForm_Load);
            this.Shown += new System.EventHandler(this.ElucidateForm_Shown);
            this.ResizeEnd += new System.EventHandler(this.ElucidateForm_ResizeEnd);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabCoveragePage.ResumeLayout(false);
            this.tabSchedulePage.ResumeLayout(false);
            this.tabSchedulePage.PerformLayout();
            this.tabCommonOperations.ResumeLayout(false);
            this.logPanel.ResumeLayout(false);
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
        private Label spacer;
        private Label label3;
        private TabControl tabControl;
        private TabPage tabCommonOperations;
        private Panel logPanel;
        private TabPage tabSchedulePage;
        private Controls.Schedule SchedulePageScheduleControl;
        private TabPage tabCoveragePage;
        private TabPage tabLogs;
        private Controls.LogsViewerControl logsViewerControl;
        private TabPage tabRecoverFiles;
        private Recover recover1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem dangerZoneToolStripMenuItem;
        private ToolStripMenuItem deleteAllSnapRAIDRaidFilesToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ProtectedDrivesDisplay driveSpaceDisplay;
        private CommonTab commonTab;
        private ToolStripMenuItem changeLogToolStripMenuItem;
    }
}

