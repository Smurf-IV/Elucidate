using System.ComponentModel;
using System.Windows.Forms;
using Elucidate.Controls;
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
        /// <remarks>
        /// for some reason the following is removed each time the desgner is saved !!!
        ///             this.tpCoverage = new Elucidate.Controls.ProtectedDrivesDisplay();
        /// </remarks>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElucidateForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabCoveragePage = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tpCoverage = new Elucidate.Controls.ProtectedDrivesDisplay();
            this.tabSchedulePage = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tpSchedule = new Elucidate.TabPages.Schedule();
            this.tabCommonOperations = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.logPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.commonTab = new Elucidate.TabPages.CommonTab();
            this.tabControl = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabLogs = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.logsViewerControl = new Elucidate.Controls.LogsViewerControl();
            this.tabRecoverFiles = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.recover1 = new Elucidate.TabPages.Recover();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dangerZoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editConfigDirectlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMeTheLatestReleaseStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeTheThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.changeLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.liveRunLogControl1 = new Elucidate.Controls.RunControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabCoveragePage)).BeginInit();
            this.tabCoveragePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabSchedulePage)).BeginInit();
            this.tabSchedulePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCommonOperations)).BeginInit();
            this.tabCommonOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logPanel)).BeginInit();
            this.logPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabLogs)).BeginInit();
            this.tabLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabRecoverFiles)).BeginInit();
            this.tabRecoverFiles.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCoveragePage
            // 
            this.tabCoveragePage.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabCoveragePage.Controls.Add(this.tpCoverage);
            this.tabCoveragePage.Flags = 65534;
            this.tabCoveragePage.LastVisibleSet = true;
            this.tabCoveragePage.Margin = new System.Windows.Forms.Padding(4);
            this.tabCoveragePage.MinimumSize = new System.Drawing.Size(62, 62);
            this.tabCoveragePage.Name = "tabCoveragePage";
            this.tabCoveragePage.Padding = new System.Windows.Forms.Padding(4);
            this.tabCoveragePage.Size = new System.Drawing.Size(1179, 631);
            this.tabCoveragePage.Text = "  Coverage  ";
            this.tabCoveragePage.ToolTipTitle = "Page ToolTip";
            this.tabCoveragePage.UniqueName = "83F1AC53801E4FDCCBA828F2D020A11A";
            // 
            // tpCoverage
            // 
            this.tpCoverage.AllowDrop = true;
            this.tpCoverage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpCoverage.Location = new System.Drawing.Point(4, 4);
            this.tpCoverage.Margin = new System.Windows.Forms.Padding(5);
            this.tpCoverage.Name = "tpCoverage";
            this.tpCoverage.Size = new System.Drawing.Size(1171, 623);
            this.tpCoverage.TabIndex = 0;
            // 
            // tabSchedulePage
            // 
            this.tabSchedulePage.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabSchedulePage.Controls.Add(this.tpSchedule);
            this.tabSchedulePage.Flags = 65534;
            this.tabSchedulePage.LastVisibleSet = true;
            this.tabSchedulePage.Margin = new System.Windows.Forms.Padding(4);
            this.tabSchedulePage.MinimumSize = new System.Drawing.Size(62, 62);
            this.tabSchedulePage.Name = "tabSchedulePage";
            this.tabSchedulePage.Padding = new System.Windows.Forms.Padding(4);
            this.tabSchedulePage.Size = new System.Drawing.Size(1179, 558);
            this.tabSchedulePage.Text = "Schedule";
            this.tabSchedulePage.ToolTipTitle = "Page ToolTip";
            this.tabSchedulePage.UniqueName = "D08ABA17CB8242C412B34C6B2FB9731D";
            // 
            // tpSchedule
            // 
            this.tpSchedule.AutoSize = true;
            this.tpSchedule.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tpSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpSchedule.Location = new System.Drawing.Point(4, 4);
            this.tpSchedule.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tpSchedule.Name = "tpSchedule";
            this.tpSchedule.Size = new System.Drawing.Size(1171, 550);
            this.tpSchedule.TabIndex = 0;
            // 
            // tabCommonOperations
            // 
            this.tabCommonOperations.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabCommonOperations.Controls.Add(this.logPanel);
            this.tabCommonOperations.Flags = 65534;
            this.tabCommonOperations.LastVisibleSet = true;
            this.tabCommonOperations.Margin = new System.Windows.Forms.Padding(0);
            this.tabCommonOperations.MinimumSize = new System.Drawing.Size(62, 62);
            this.tabCommonOperations.Name = "tabCommonOperations";
            this.tabCommonOperations.Size = new System.Drawing.Size(1179, 310);
            this.tabCommonOperations.Text = "  Common SnapRaid  ";
            this.tabCommonOperations.ToolTipTitle = "Page ToolTip";
            this.tabCommonOperations.UniqueName = "C7A4A748B4E3458CC28B53AD5B684A5E";
            // 
            // logPanel
            // 
            this.logPanel.Controls.Add(this.commonTab);
            this.logPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logPanel.Location = new System.Drawing.Point(0, 0);
            this.logPanel.Margin = new System.Windows.Forms.Padding(4);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(1179, 310);
            this.logPanel.TabIndex = 11;
            // 
            // commonTab
            // 
            this.commonTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonTab.Location = new System.Drawing.Point(0, 0);
            this.commonTab.Margin = new System.Windows.Forms.Padding(4);
            this.commonTab.Name = "commonTab";
            this.commonTab.Size = new System.Drawing.Size(1179, 310);
            this.commonTab.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.None;
            this.tabControl.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.tabControl.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Group.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelClient;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.PageBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelClient;
            this.tabControl.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabCommonOperations,
            this.tabLogs,
            this.tabCoveragePage,
            this.tabSchedulePage,
            this.tabRecoverFiles});
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1181, 346);
            this.tabControl.StateCommon.Tab.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.TabIndex = 4;
            this.tabControl.SelectedPageChanged += new System.EventHandler(this.tabControl_SelectedPageChanged);
            // 
            // tabLogs
            // 
            this.tabLogs.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabLogs.Controls.Add(this.logsViewerControl);
            this.tabLogs.Flags = 65534;
            this.tabLogs.LastVisibleSet = true;
            this.tabLogs.Margin = new System.Windows.Forms.Padding(4);
            this.tabLogs.MinimumSize = new System.Drawing.Size(62, 62);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(4);
            this.tabLogs.Size = new System.Drawing.Size(1179, 631);
            this.tabLogs.Text = "Log History";
            this.tabLogs.ToolTipTitle = "Page ToolTip";
            this.tabLogs.UniqueName = "2D998176807546A076BCA98AEA36EF48";
            // 
            // logsViewerControl
            // 
            this.logsViewerControl.AutoSize = true;
            this.logsViewerControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.logsViewerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logsViewerControl.LexerToUse = Elucidate.Controls.LogsViewerControl.LexerNameEnum.ScanRaid;
            this.logsViewerControl.Location = new System.Drawing.Point(4, 4);
            this.logsViewerControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.logsViewerControl.Name = "logsViewerControl";
            this.logsViewerControl.Size = new System.Drawing.Size(1171, 623);
            this.logsViewerControl.TabIndex = 0;
            // 
            // tabRecoverFiles
            // 
            this.tabRecoverFiles.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabRecoverFiles.Controls.Add(this.recover1);
            this.tabRecoverFiles.Flags = 65534;
            this.tabRecoverFiles.LastVisibleSet = true;
            this.tabRecoverFiles.Margin = new System.Windows.Forms.Padding(4);
            this.tabRecoverFiles.MinimumSize = new System.Drawing.Size(62, 62);
            this.tabRecoverFiles.Name = "tabRecoverFiles";
            this.tabRecoverFiles.Padding = new System.Windows.Forms.Padding(4);
            this.tabRecoverFiles.Size = new System.Drawing.Size(1179, 310);
            this.tabRecoverFiles.Text = "Recover Files";
            this.tabRecoverFiles.ToolTipTitle = "Page ToolTip";
            this.tabRecoverFiles.UniqueName = "B4F3B50AB11048A05B80EE8A2A5EDC3A";
            // 
            // recover1
            // 
            this.recover1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recover1.Location = new System.Drawing.Point(4, 4);
            this.recover1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.recover1.Name = "recover1";
            this.recover1.Size = new System.Drawing.Size(1171, 302);
            this.recover1.TabIndex = 0;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 28);
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1181, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(96, 28);
            this.fileToolStripMenuItem.Text = "Settings";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.EditSnapRAIDConfigToolStripMenuItem_Click);
            // 
            // dangerZoneToolStripMenuItem
            // 
            this.dangerZoneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem,
            this.editConfigDirectlyToolStripMenuItem,
            this.showMeTheLatestReleaseStatsToolStripMenuItem,
            this.changeTheThemeToolStripMenuItem});
            this.dangerZoneToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dangerZoneToolStripMenuItem.Name = "dangerZoneToolStripMenuItem";
            this.dangerZoneToolStripMenuItem.Size = new System.Drawing.Size(139, 28);
            this.dangerZoneToolStripMenuItem.Text = "Danger Zone";
            // 
            // deleteAllSnapRAIDRaidFilesToolStripMenuItem
            // 
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem.Name = "deleteAllSnapRAIDRaidFilesToolStripMenuItem";
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem.Size = new System.Drawing.Size(400, 28);
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem.Text = "&Delete SnapRAID Generated Files";
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem.ToolTipText = "This will delete all parity and content files defined in the current configuratio" +
    "n file.";
            this.deleteAllSnapRAIDRaidFilesToolStripMenuItem.Click += new System.EventHandler(this.deleteAllSnapRAIDRaidFilesToolStripMenuItem_Click);
            // 
            // editConfigDirectlyToolStripMenuItem
            // 
            this.editConfigDirectlyToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editConfigDirectlyToolStripMenuItem.Name = "editConfigDirectlyToolStripMenuItem";
            this.editConfigDirectlyToolStripMenuItem.Size = new System.Drawing.Size(400, 28);
            this.editConfigDirectlyToolStripMenuItem.Text = "&Edit SnapRAID.Config Directly ...";
            this.editConfigDirectlyToolStripMenuItem.Click += new System.EventHandler(this.editConfigDirectlyToolStripMenuItem_Click);
            // 
            // showMeTheLatestReleaseStatsToolStripMenuItem
            // 
            this.showMeTheLatestReleaseStatsToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showMeTheLatestReleaseStatsToolStripMenuItem.Name = "showMeTheLatestReleaseStatsToolStripMenuItem";
            this.showMeTheLatestReleaseStatsToolStripMenuItem.Size = new System.Drawing.Size(400, 28);
            this.showMeTheLatestReleaseStatsToolStripMenuItem.Text = "&Show Me the Latest Release Stats ...";
            this.showMeTheLatestReleaseStatsToolStripMenuItem.Click += new System.EventHandler(this.showMeTheLatestReleaseStatsToolStripMenuItem_Click);
            // 
            // changeTheThemeToolStripMenuItem
            // 
            this.changeTheThemeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themeComboBox});
            this.changeTheThemeToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeTheThemeToolStripMenuItem.Name = "changeTheThemeToolStripMenuItem";
            this.changeTheThemeToolStripMenuItem.Size = new System.Drawing.Size(400, 28);
            this.changeTheThemeToolStripMenuItem.Text = "&Change the Theme";
            // 
            // themeComboBox
            // 
            this.themeComboBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themeComboBox.Name = "themeComboBox";
            this.themeComboBox.Size = new System.Drawing.Size(221, 31);
            this.themeComboBox.SelectedIndexChanged += new System.EventHandler(this.themeComboBox_SelectedIndexChanged);
            // 
            // changeLogToolStripMenuItem
            // 
            this.changeLogToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.changeLogToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeLogToolStripMenuItem.Name = "changeLogToolStripMenuItem";
            this.changeLogToolStripMenuItem.Size = new System.Drawing.Size(134, 28);
            this.changeLogToolStripMenuItem.Text = "Change_Log";
            this.changeLogToolStripMenuItem.Click += new System.EventHandler(this.changeLogToolStripMenuItem_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tabControl);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 32);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1181, 346);
            this.kryptonPanel1.TabIndex = 5;
            // 
            // liveRunLogControl1
            // 
            this.liveRunLogControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.liveRunLogControl1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liveRunLogControl1.Location = new System.Drawing.Point(0, 378);
            this.liveRunLogControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.liveRunLogControl1.Name = "liveRunLogControl1";
            this.liveRunLogControl1.Size = new System.Drawing.Size(1181, 75);
            this.liveRunLogControl1.TabIndex = 6;
            // 
            // ElucidateForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1181, 453);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.liveRunLogControl1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(930, 500);
            this.Name = "ElucidateForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Elucidate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElucidateForm_FormClosing);
            this.Load += new System.EventHandler(this.ElucidateForm_Load);
            this.Shown += new System.EventHandler(this.ElucidateForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tabCoveragePage)).EndInit();
            this.tabCoveragePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabSchedulePage)).EndInit();
            this.tabSchedulePage.ResumeLayout(false);
            this.tabSchedulePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCommonOperations)).EndInit();
            this.tabCommonOperations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logPanel)).EndInit();
            this.logPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabLogs)).EndInit();
            this.tabLogs.ResumeLayout(false);
            this.tabLogs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabRecoverFiles)).EndInit();
            this.tabRecoverFiles.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolTip toolTip1;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator tabControl;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabCommonOperations;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel logPanel;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabSchedulePage;
        private Schedule tpSchedule;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabCoveragePage;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabLogs;
        private LogsViewerControl logsViewerControl;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabRecoverFiles;
        private Recover recover1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem dangerZoneToolStripMenuItem;
        private ToolStripMenuItem deleteAllSnapRAIDRaidFilesToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ProtectedDrivesDisplay tpCoverage;
        private CommonTab commonTab;
        private ToolStripMenuItem changeLogToolStripMenuItem;
        private ToolStripMenuItem editConfigDirectlyToolStripMenuItem;
        private ToolStripMenuItem showMeTheLatestReleaseStatsToolStripMenuItem;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private ToolStripMenuItem changeTheThemeToolStripMenuItem;
        private ToolStripComboBox themeComboBox;
        internal RunControl liveRunLogControl1;
    }
}

