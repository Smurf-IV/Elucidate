using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Elucidate.Tabs;

namespace Elucidate
{
   partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.DRUnit_NewNode = new System.Windows.Forms.ToolStripMenuItem();
            this.driveAndDirTreeView = new System.Windows.Forms.TreeView();
            this.drivesAndDirectoriesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListUnits = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.findParity6 = new System.Windows.Forms.Button();
            this.findParity5 = new System.Windows.Forms.Button();
            this.findParity4 = new System.Windows.Forms.Button();
            this.parityLocation6 = new System.Windows.Forms.TextBox();
            this.parityLocation5 = new System.Windows.Forms.TextBox();
            this.parityLocation4 = new System.Windows.Forms.TextBox();
            this.findParity3 = new System.Windows.Forms.Button();
            this.labelParity6 = new System.Windows.Forms.Label();
            this.labelParity5 = new System.Windows.Forms.Label();
            this.labelParity4 = new System.Windows.Forms.Label();
            this.labelParity3 = new System.Windows.Forms.Label();
            this.parityLocation3 = new System.Windows.Forms.TextBox();
            this.labelParity2 = new System.Windows.Forms.Label();
            this.parityLocation2 = new System.Windows.Forms.TextBox();
            this.findParity2 = new System.Windows.Forms.Button();
            this.labelParity1 = new System.Windows.Forms.Label();
            this.parityLocation1 = new System.Windows.Forms.TextBox();
            this.findParity1 = new System.Windows.Forms.Button();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SnapShotsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.snapShotSourcesTreeView = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.driveSpace = new DriveSpaceDisplay();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGetRecommended = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.numAutoSaveGB = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numBlockSizeKB = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.exludedFilesView = new System.Windows.Forms.DataGridView();
            this.ExcludedFilesPatterns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.configFileLocation = new System.Windows.Forms.TextBox();
            this.snapRAIDFileLocation = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.findConfigFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.findExeFile = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.drivesAndDirectoriesMenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SnapShotsMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoSaveGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlockSizeKB)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exludedFilesView)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // DRUnit_NewNode
            // 
            this.DRUnit_NewNode.Name = "DRUnit_NewNode";
            this.DRUnit_NewNode.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.DRUnit_NewNode.Size = new System.Drawing.Size(196, 26);
            this.DRUnit_NewNode.Text = "&New Node";
            this.DRUnit_NewNode.Click += new System.EventHandler(this.DRUnit_NewNode_MenuItem_Click);
            // 
            // driveAndDirTreeView
            // 
            this.driveAndDirTreeView.ContextMenuStrip = this.drivesAndDirectoriesMenu;
            this.driveAndDirTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpProvider1.SetHelpKeyword(this.driveAndDirTreeView, "PossibleProtection");
            this.helpProvider1.SetHelpNavigator(this.driveAndDirTreeView, System.Windows.Forms.HelpNavigator.Topic);
            this.driveAndDirTreeView.ImageIndex = 0;
            this.driveAndDirTreeView.ImageList = this.imageListUnits;
            this.driveAndDirTreeView.LabelEdit = true;
            this.driveAndDirTreeView.Location = new System.Drawing.Point(0, 0);
            this.driveAndDirTreeView.Name = "driveAndDirTreeView";
            this.driveAndDirTreeView.SelectedImageIndex = 0;
            this.helpProvider1.SetShowHelp(this.driveAndDirTreeView, true);
            this.driveAndDirTreeView.Size = new System.Drawing.Size(322, 468);
            this.driveAndDirTreeView.TabIndex = 0;
            this.toolTip1.SetToolTip(this.driveAndDirTreeView, "Possible sources to be used for snap shot.");
            this.driveAndDirTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.driveAndDirTreeView_BeforeExpand);
            this.driveAndDirTreeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.driveAndDirTreeView_MouseDoubleClick);
            this.driveAndDirTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.driveAndDirTreeView_MouseDown);
            this.driveAndDirTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.driveAndDirTreeView_MouseUp);
            // 
            // drivesAndDirectoriesMenu
            // 
            this.drivesAndDirectoriesMenu.Font = new System.Drawing.Font("Tahoma", 9F);
            this.drivesAndDirectoriesMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.drivesAndDirectoriesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshStripMenuItem,
            this.toolStripMenuItem1,
            this.advancedSettingsToolStripMenuItem});
            this.drivesAndDirectoriesMenu.Name = "unitsMenu";
            this.drivesAndDirectoriesMenu.Size = new System.Drawing.Size(259, 82);
            // 
            // refreshStripMenuItem
            // 
            this.refreshStripMenuItem.Name = "refreshStripMenuItem";
            this.refreshStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.refreshStripMenuItem.Text = "&Refresh";
            this.refreshStripMenuItem.Click += new System.EventHandler(this.refreshStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.toolStripMenuItem1.Size = new System.Drawing.Size(258, 26);
            this.toolStripMenuItem1.Text = "&Add To Snap shot";
            // 
            // advancedSettingsToolStripMenuItem
            // 
            this.advancedSettingsToolStripMenuItem.Name = "advancedSettingsToolStripMenuItem";
            this.advancedSettingsToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.advancedSettingsToolStripMenuItem.Text = "Advanced &Settings...";
            // 
            // imageListUnits
            // 
            this.imageListUnits.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListUnits.ImageStream")));
            this.imageListUnits.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListUnits.Images.SetKeyName(0, "My Computer.ico");
            this.imageListUnits.Images.SetKeyName(1, "2.5 Floppy.ico");
            this.imageListUnits.Images.SetKeyName(2, "5.25 Floppy.ico");
            this.imageListUnits.Images.SetKeyName(3, "Hard Drive.ico");
            this.imageListUnits.Images.SetKeyName(4, "CD Rom Drive.ico");
            this.imageListUnits.Images.SetKeyName(5, "Network.ico");
            this.imageListUnits.Images.SetKeyName(6, "Misc Removeable.ico");
            this.imageListUnits.Images.SetKeyName(7, "Closed Folder.ico");
            this.imageListUnits.Images.SetKeyName(8, "Open Folder.ico");
            this.imageListUnits.Images.SetKeyName(9, "Network Folder.ico");
            this.imageListUnits.Images.SetKeyName(10, "Disconnected Network.ico");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.findParity6);
            this.groupBox2.Controls.Add(this.findParity5);
            this.groupBox2.Controls.Add(this.findParity4);
            this.groupBox2.Controls.Add(this.parityLocation6);
            this.groupBox2.Controls.Add(this.parityLocation5);
            this.groupBox2.Controls.Add(this.parityLocation4);
            this.groupBox2.Controls.Add(this.findParity3);
            this.groupBox2.Controls.Add(this.labelParity6);
            this.groupBox2.Controls.Add(this.labelParity5);
            this.groupBox2.Controls.Add(this.labelParity4);
            this.groupBox2.Controls.Add(this.labelParity3);
            this.groupBox2.Controls.Add(this.parityLocation3);
            this.groupBox2.Controls.Add(this.labelParity2);
            this.groupBox2.Controls.Add(this.parityLocation2);
            this.groupBox2.Controls.Add(this.findParity2);
            this.groupBox2.Controls.Add(this.labelParity1);
            this.groupBox2.Controls.Add(this.parityLocation1);
            this.groupBox2.Controls.Add(this.findParity1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox2.Location = new System.Drawing.Point(3, 352);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 200);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parity file locations:";
            // 
            // findParity6
            // 
            this.findParity6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findParity6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findParity6.Location = new System.Drawing.Point(496, 157);
            this.findParity6.Name = "findParity6";
            this.findParity6.Size = new System.Drawing.Size(35, 25);
            this.findParity6.TabIndex = 12;
            this.findParity6.Text = "...";
            this.toolTip1.SetToolTip(this.findParity6, "Browse root location for disk protection ");
            this.findParity6.UseVisualStyleBackColor = true;
            this.findParity6.Click += new System.EventHandler(this.findParity6_Click);
            // 
            // findParity5
            // 
            this.findParity5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findParity5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findParity5.Location = new System.Drawing.Point(496, 129);
            this.findParity5.Name = "findParity5";
            this.findParity5.Size = new System.Drawing.Size(35, 25);
            this.findParity5.TabIndex = 10;
            this.findParity5.Text = "...";
            this.toolTip1.SetToolTip(this.findParity5, "Browse root location for disk protection ");
            this.findParity5.UseVisualStyleBackColor = true;
            this.findParity5.Click += new System.EventHandler(this.findParity5_Click);
            // 
            // findParity4
            // 
            this.findParity4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findParity4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findParity4.Location = new System.Drawing.Point(496, 101);
            this.findParity4.Name = "findParity4";
            this.findParity4.Size = new System.Drawing.Size(35, 25);
            this.findParity4.TabIndex = 8;
            this.findParity4.Text = "...";
            this.toolTip1.SetToolTip(this.findParity4, "Browse root location for disk protection ");
            this.findParity4.UseVisualStyleBackColor = true;
            this.findParity4.Click += new System.EventHandler(this.findParity4_Click);
            // 
            // parityLocation6
            // 
            this.parityLocation6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parityLocation6.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider1.SetError(this.parityLocation6, "Config File does not exist");
            this.helpProvider1.SetHelpKeyword(this.parityLocation6, "ParityLocs");
            this.helpProvider1.SetHelpNavigator(this.parityLocation6, System.Windows.Forms.HelpNavigator.Topic);
            this.parityLocation6.Location = new System.Drawing.Point(65, 159);
            this.parityLocation6.Name = "parityLocation6";
            this.helpProvider1.SetShowHelp(this.parityLocation6, true);
            this.parityLocation6.Size = new System.Drawing.Size(406, 29);
            this.parityLocation6.TabIndex = 11;
            this.toolTip1.SetToolTip(this.parityLocation6, "Optional disk failure protection root location.");
            this.parityLocation6.TextChanged += new System.EventHandler(this.parityLocation6_TextChanged);
            // 
            // parityLocation5
            // 
            this.parityLocation5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parityLocation5.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider1.SetError(this.parityLocation5, "Config File does not exist");
            this.helpProvider1.SetHelpKeyword(this.parityLocation5, "ParityLocs");
            this.helpProvider1.SetHelpNavigator(this.parityLocation5, System.Windows.Forms.HelpNavigator.Topic);
            this.parityLocation5.Location = new System.Drawing.Point(65, 131);
            this.parityLocation5.Name = "parityLocation5";
            this.helpProvider1.SetShowHelp(this.parityLocation5, true);
            this.parityLocation5.Size = new System.Drawing.Size(406, 29);
            this.parityLocation5.TabIndex = 9;
            this.toolTip1.SetToolTip(this.parityLocation5, "Optional disk failure protection root location.");
            this.parityLocation5.TextChanged += new System.EventHandler(this.parityLocation5_TextChanged);
            // 
            // parityLocation4
            // 
            this.parityLocation4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parityLocation4.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider1.SetError(this.parityLocation4, "Config File does not exist");
            this.helpProvider1.SetHelpKeyword(this.parityLocation4, "ParityLocs");
            this.helpProvider1.SetHelpNavigator(this.parityLocation4, System.Windows.Forms.HelpNavigator.Topic);
            this.parityLocation4.Location = new System.Drawing.Point(65, 103);
            this.parityLocation4.Name = "parityLocation4";
            this.helpProvider1.SetShowHelp(this.parityLocation4, true);
            this.parityLocation4.Size = new System.Drawing.Size(406, 29);
            this.parityLocation4.TabIndex = 7;
            this.toolTip1.SetToolTip(this.parityLocation4, "Optional disk failure protection root location.");
            this.parityLocation4.TextChanged += new System.EventHandler(this.parityLocation4_TextChanged);
            // 
            // findParity3
            // 
            this.findParity3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findParity3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findParity3.Location = new System.Drawing.Point(496, 73);
            this.findParity3.Name = "findParity3";
            this.findParity3.Size = new System.Drawing.Size(35, 25);
            this.findParity3.TabIndex = 6;
            this.findParity3.Text = "...";
            this.toolTip1.SetToolTip(this.findParity3, "Browse root location for disk protection ");
            this.findParity3.UseVisualStyleBackColor = true;
            this.findParity3.Click += new System.EventHandler(this.findParity3_Click);
            // 
            // labelParity6
            // 
            this.labelParity6.Location = new System.Drawing.Point(6, 157);
            this.labelParity6.Name = "labelParity6";
            this.labelParity6.Size = new System.Drawing.Size(53, 25);
            this.labelParity6.TabIndex = 15;
            this.labelParity6.Text = "Parity &6:";
            this.labelParity6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.labelParity6, "Optional root location for parity protection");
            // 
            // labelParity5
            // 
            this.labelParity5.Location = new System.Drawing.Point(6, 129);
            this.labelParity5.Name = "labelParity5";
            this.labelParity5.Size = new System.Drawing.Size(53, 25);
            this.labelParity5.TabIndex = 14;
            this.labelParity5.Text = "Parity &5:";
            this.labelParity5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.labelParity5, "Optional root location for parity protection");
            // 
            // labelParity4
            // 
            this.labelParity4.Location = new System.Drawing.Point(6, 101);
            this.labelParity4.Name = "labelParity4";
            this.labelParity4.Size = new System.Drawing.Size(53, 25);
            this.labelParity4.TabIndex = 13;
            this.labelParity4.Text = "Parity &4:";
            this.labelParity4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.labelParity4, "Optional root location for parity protection");
            // 
            // labelParity3
            // 
            this.labelParity3.Location = new System.Drawing.Point(6, 73);
            this.labelParity3.Name = "labelParity3";
            this.labelParity3.Size = new System.Drawing.Size(53, 25);
            this.labelParity3.TabIndex = 12;
            this.labelParity3.Text = "Parity &3:";
            this.labelParity3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.labelParity3, "Optional root location for parity protection");
            // 
            // parityLocation3
            // 
            this.parityLocation3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parityLocation3.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider1.SetError(this.parityLocation3, "Config File does not exist");
            this.helpProvider1.SetHelpKeyword(this.parityLocation3, "ParityLocs");
            this.helpProvider1.SetHelpNavigator(this.parityLocation3, System.Windows.Forms.HelpNavigator.Topic);
            this.parityLocation3.Location = new System.Drawing.Point(65, 75);
            this.parityLocation3.Name = "parityLocation3";
            this.helpProvider1.SetShowHelp(this.parityLocation3, true);
            this.parityLocation3.Size = new System.Drawing.Size(406, 29);
            this.parityLocation3.TabIndex = 5;
            this.toolTip1.SetToolTip(this.parityLocation3, "Optional disk failure protection root location.");
            this.parityLocation3.TextChanged += new System.EventHandler(this.parityLocation3_TextChanged);
            // 
            // labelParity2
            // 
            this.labelParity2.Location = new System.Drawing.Point(6, 45);
            this.labelParity2.Name = "labelParity2";
            this.labelParity2.Size = new System.Drawing.Size(53, 25);
            this.labelParity2.TabIndex = 6;
            this.labelParity2.Text = "Parity &2:";
            this.labelParity2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.labelParity2, "Optional root location for parity protection");
            // 
            // parityLocation2
            // 
            this.parityLocation2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parityLocation2.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider1.SetError(this.parityLocation2, "Config File does not exist");
            this.helpProvider1.SetHelpKeyword(this.parityLocation2, "ParityLocs");
            this.helpProvider1.SetHelpNavigator(this.parityLocation2, System.Windows.Forms.HelpNavigator.Topic);
            this.parityLocation2.Location = new System.Drawing.Point(65, 47);
            this.parityLocation2.Name = "parityLocation2";
            this.helpProvider1.SetShowHelp(this.parityLocation2, true);
            this.parityLocation2.Size = new System.Drawing.Size(406, 29);
            this.parityLocation2.TabIndex = 3;
            this.toolTip1.SetToolTip(this.parityLocation2, "Optional disk failure protection root location.");
            this.parityLocation2.TextChanged += new System.EventHandler(this.parityLocation2_TextChanged);
            // 
            // findParity2
            // 
            this.findParity2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findParity2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findParity2.Location = new System.Drawing.Point(496, 45);
            this.findParity2.Name = "findParity2";
            this.findParity2.Size = new System.Drawing.Size(35, 25);
            this.findParity2.TabIndex = 4;
            this.findParity2.Text = "...";
            this.toolTip1.SetToolTip(this.findParity2, "Browse root location for disk protection ");
            this.findParity2.UseVisualStyleBackColor = true;
            this.findParity2.Click += new System.EventHandler(this.findParity2_Click);
            // 
            // labelParity1
            // 
            this.labelParity1.Location = new System.Drawing.Point(6, 17);
            this.labelParity1.Name = "labelParity1";
            this.labelParity1.Size = new System.Drawing.Size(53, 25);
            this.labelParity1.TabIndex = 0;
            this.labelParity1.Text = "Parity &1:";
            this.labelParity1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.labelParity1, "Mandatory root location for minimum parity protection");
            // 
            // parityLocation1
            // 
            this.parityLocation1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parityLocation1.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider1.SetError(this.parityLocation1, "Executeable Not found");
            this.helpProvider1.SetHelpKeyword(this.parityLocation1, "ParityLocs");
            this.helpProvider1.SetHelpNavigator(this.parityLocation1, System.Windows.Forms.HelpNavigator.Topic);
            this.parityLocation1.Location = new System.Drawing.Point(65, 19);
            this.parityLocation1.Name = "parityLocation1";
            this.helpProvider1.SetShowHelp(this.parityLocation1, true);
            this.parityLocation1.Size = new System.Drawing.Size(406, 29);
            this.parityLocation1.TabIndex = 1;
            this.parityLocation1.Text = "Z:\\";
            this.toolTip1.SetToolTip(this.parityLocation1, "Mandatory root location for minimum protection");
            this.parityLocation1.TextChanged += new System.EventHandler(this.parityLocation1_TextChanged);
            // 
            // findParity1
            // 
            this.findParity1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findParity1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findParity1.Location = new System.Drawing.Point(496, 16);
            this.findParity1.Name = "findParity1";
            this.findParity1.Size = new System.Drawing.Size(35, 26);
            this.findParity1.TabIndex = 2;
            this.findParity1.Text = "...";
            this.toolTip1.SetToolTip(this.findParity1, "Browse mandatory disk root location for minimum protection");
            this.findParity1.UseVisualStyleBackColor = true;
            this.findParity1.Click += new System.EventHandler(this.findParity1_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.removeToolStripMenuItem.Text = "&Delete";
            this.removeToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // SnapShotsMenu
            // 
            this.SnapShotsMenu.Font = new System.Drawing.Font("Tahoma", 9F);
            this.SnapShotsMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.SnapShotsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.DRUnit_NewNode});
            this.SnapShotsMenu.Name = "unitsMenu";
            this.SnapShotsMenu.Size = new System.Drawing.Size(197, 56);
            // 
            // snapShotSourcesTreeView
            // 
            this.snapShotSourcesTreeView.AllowDrop = true;
            this.snapShotSourcesTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.snapShotSourcesTreeView.ContextMenuStrip = this.SnapShotsMenu;
            this.snapShotSourcesTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.snapShotSourcesTreeView.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this.snapShotSourcesTreeView, "SnapShotSources");
            this.helpProvider1.SetHelpNavigator(this.snapShotSourcesTreeView, System.Windows.Forms.HelpNavigator.Topic);
            this.snapShotSourcesTreeView.ImageIndex = 0;
            this.snapShotSourcesTreeView.ImageList = this.imageListUnits;
            this.snapShotSourcesTreeView.Location = new System.Drawing.Point(3, 25);
            this.snapShotSourcesTreeView.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.snapShotSourcesTreeView.Name = "snapShotSourcesTreeView";
            this.snapShotSourcesTreeView.SelectedImageIndex = 0;
            this.helpProvider1.SetShowHelp(this.snapShotSourcesTreeView, true);
            this.snapShotSourcesTreeView.ShowLines = false;
            this.snapShotSourcesTreeView.ShowPlusMinus = false;
            this.snapShotSourcesTreeView.ShowRootLines = false;
            this.snapShotSourcesTreeView.Size = new System.Drawing.Size(228, 315);
            this.snapShotSourcesTreeView.TabIndex = 0;
            this.toolTip1.SetToolTip(this.snapShotSourcesTreeView, "The order is relevant for parity, do not change it!");
            this.snapShotSourcesTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.snapShotSourcesTreeView_DragDrop);
            this.snapShotSourcesTreeView.DragOver += new System.Windows.Forms.DragEventHandler(this.snapShotSourcesTreeView_DragOver);
            this.snapShotSourcesTreeView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.snapShotSourcesTreeView_KeyUp);
            this.snapShotSourcesTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.snapShotSourcesTreeView_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.driveSpace);
            this.groupBox1.Controls.Add(this.snapShotSourcesTreeView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 343);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "S&nap Shot Sources";
            // 
            // driveSpace
            // 
            this.driveSpace.Dock = System.Windows.Forms.DockStyle.Right;
            this.driveSpace.Location = new System.Drawing.Point(234, 25);
            this.driveSpace.Margin = new System.Windows.Forms.Padding(0);
            this.driveSpace.Name = "driveSpace";
            this.driveSpace.ShowXAxisText = false;
            this.driveSpace.ShowYAxisText = false;
            this.driveSpace.Size = new System.Drawing.Size(300, 315);
            this.driveSpace.TabIndex = 1;
            this.toolTip1.SetToolTip(this.driveSpace, "Shows the space in GBytes");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 65);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.driveAndDirTreeView);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(870, 645);
            this.splitContainer1.SplitterDistance = 322;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGetRecommended);
            this.groupBox3.Controls.Add(this.checkedListBox1);
            this.groupBox3.Controls.Add(this.numAutoSaveGB);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.numBlockSizeKB);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 468);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 177);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Advanced";
            this.toolTip1.SetToolTip(this.groupBox3, "Unusual settings.");
            // 
            // btnGetRecommended
            // 
            this.btnGetRecommended.Location = new System.Drawing.Point(175, 22);
            this.btnGetRecommended.Name = "btnGetRecommended";
            this.btnGetRecommended.Size = new System.Drawing.Size(137, 24);
            this.btnGetRecommended.TabIndex = 8;
            this.btnGetRecommended.Text = "C&alculate ..";
            this.btnGetRecommended.UseVisualStyleBackColor = true;
            this.btnGetRecommended.Click += new System.EventHandler(this.btnGetRecommended_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.helpProvider1.SetHelpString(this.checkedListBox1, "UseVerbose");
            this.checkedListBox1.IntegralHeight = false;
            this.checkedListBox1.Location = new System.Drawing.Point(10, 79);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.helpProvider1.SetShowHelp(this.checkedListBox1, true);
            this.checkedListBox1.Size = new System.Drawing.Size(306, 95);
            this.checkedListBox1.TabIndex = 7;
            this.checkedListBox1.ThreeDCheckBoxes = true;
            this.toolTip1.SetToolTip(this.checkedListBox1, "Caution: You must know wat these settings are.");
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.checkedListBox1_MouseMove);
            // 
            // numAutoSaveGB
            // 
            this.numAutoSaveGB.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numAutoSaveGB.Location = new System.Drawing.Point(95, 51);
            this.numAutoSaveGB.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numAutoSaveGB.Name = "numAutoSaveGB";
            this.numAutoSaveGB.Size = new System.Drawing.Size(74, 29);
            this.numAutoSaveGB.TabIndex = 4;
            this.toolTip1.SetToolTip(this.numAutoSaveGB, "You could increase this value if you do not have enough RAM memory to run SnapRAI" +
        "D\r\nAs a rule of thumb, with 4GB or more memory use the default 256, with 2GB use" +
        " 512, and with 1GB use 1024.");
            this.numAutoSaveGB.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 22);
            this.label6.TabIndex = 3;
            this.label6.Text = "AutoSave &GB:";
            this.toolTip1.SetToolTip(this.label6, "The number of processed GigaBytes before a save; 0 is off.");
            // 
            // numBlockSizeKB
            // 
            this.numBlockSizeKB.Increment = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numBlockSizeKB.Location = new System.Drawing.Point(95, 24);
            this.numBlockSizeKB.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numBlockSizeKB.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numBlockSizeKB.Name = "numBlockSizeKB";
            this.numBlockSizeKB.Size = new System.Drawing.Size(74, 29);
            this.numBlockSizeKB.TabIndex = 2;
            this.toolTip1.SetToolTip(this.numBlockSizeKB, "You could increase this value if you do not have enough RAM memory to run SnapRAI" +
        "D\r\nAs a rule of thumb, with 4GB or more memory use the default 256, with 2GB use" +
        " 512, and with 1GB use 1024.");
            this.numBlockSizeKB.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "&Block Size KB:";
            this.toolTip1.SetToolTip(this.label4, "You could increase this value if you do not have enough RAM memory to run SnapRAI" +
        "D\r\nAs a rule of thumb, with 4GB or more memory use the default 256, with 2GB use" +
        " 512, and with 1GB use 1024.");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.exludedFilesView, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.49886F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.50114F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(543, 645);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // exludedFilesView
            // 
            this.exludedFilesView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.exludedFilesView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exludedFilesView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExcludedFilesPatterns});
            this.exludedFilesView.Font = new System.Drawing.Font("Tahoma", 9F);
            this.helpProvider1.SetHelpKeyword(this.exludedFilesView, "FilterExclusions");
            this.helpProvider1.SetHelpNavigator(this.exludedFilesView, System.Windows.Forms.HelpNavigator.Topic);
            this.exludedFilesView.Location = new System.Drawing.Point(3, 558);
            this.exludedFilesView.Name = "exludedFilesView";
            this.exludedFilesView.ShowCellToolTips = false;
            this.helpProvider1.SetShowHelp(this.exludedFilesView, true);
            this.exludedFilesView.Size = new System.Drawing.Size(537, 84);
            this.exludedFilesView.TabIndex = 2;
            this.exludedFilesView.TabStop = false;
            this.exludedFilesView.Text = "&Exclude Patterns:";
            this.toolTip1.SetToolTip(this.exludedFilesView, "Add files and directories filter items here.");
            // 
            // ExcludedFilesPatterns
            // 
            this.ExcludedFilesPatterns.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ExcludedFilesPatterns.HeaderText = "Excluded File pattern(s)";
            this.ExcludedFilesPatterns.MaxInputLength = 256;
            this.ExcludedFilesPatterns.Name = "ExcludedFilesPatterns";
            this.ExcludedFilesPatterns.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // btnSave
            // 
            this.helpProvider1.SetHelpKeyword(this.btnSave, "SaveSettings");
            this.helpProvider1.SetHelpNavigator(this.btnSave, System.Windows.Forms.HelpNavigator.Topic);
            this.errorProvider1.SetIconAlignment(this.btnSave, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.btnSave.Location = new System.Drawing.Point(740, 31);
            this.btnSave.Name = "btnSave";
            this.helpProvider1.SetShowHelp(this.btnSave, true);
            this.btnSave.Size = new System.Drawing.Size(111, 27);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Save settings";
            this.toolTip1.SetToolTip(this.btnSave, "Save these settings to the config file.");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.helpProvider1.SetHelpKeyword(this.btnReset, "ResetToLastConfig");
            this.helpProvider1.SetHelpNavigator(this.btnReset, System.Windows.Forms.HelpNavigator.Topic);
            this.btnReset.Location = new System.Drawing.Point(737, 2);
            this.btnReset.Name = "btnReset";
            this.helpProvider1.SetShowHelp(this.btnReset, true);
            this.btnReset.Size = new System.Drawing.Size(127, 27);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset to &last config";
            this.toolTip1.SetToolTip(this.btnReset, "Reset the values to the config file.");
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // configFileLocation
            // 
            this.configFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configFileLocation.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider1.SetError(this.configFileLocation, "Config File does not exist");
            this.helpProvider1.SetHelpKeyword(this.configFileLocation, "SnapRAID.config");
            this.helpProvider1.SetHelpNavigator(this.configFileLocation, System.Windows.Forms.HelpNavigator.Topic);
            this.configFileLocation.Location = new System.Drawing.Point(135, 35);
            this.configFileLocation.Name = "configFileLocation";
            this.helpProvider1.SetShowHelp(this.configFileLocation, true);
            this.configFileLocation.Size = new System.Drawing.Size(544, 29);
            this.configFileLocation.TabIndex = 4;
            this.configFileLocation.Text = "Stick some text in here for config";
            this.toolTip1.SetToolTip(this.configFileLocation, "Full path to the SnapRAID config file.");
            this.configFileLocation.TextChanged += new System.EventHandler(this.configFileLocation_TextChanged);
            // 
            // snapRAIDFileLocation
            // 
            this.snapRAIDFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.snapRAIDFileLocation.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider1.SetError(this.snapRAIDFileLocation, "Executeable Not found");
            this.helpProvider1.SetHelpKeyword(this.snapRAIDFileLocation, "SnapRAID.Exe");
            this.helpProvider1.SetHelpNavigator(this.snapRAIDFileLocation, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetHelpString(this.snapRAIDFileLocation, "");
            this.snapRAIDFileLocation.Location = new System.Drawing.Point(135, 5);
            this.snapRAIDFileLocation.Name = "snapRAIDFileLocation";
            this.helpProvider1.SetShowHelp(this.snapRAIDFileLocation, true);
            this.snapRAIDFileLocation.Size = new System.Drawing.Size(544, 29);
            this.snapRAIDFileLocation.TabIndex = 1;
            this.snapRAIDFileLocation.Text = "Stick some text in here";
            this.toolTip1.SetToolTip(this.snapRAIDFileLocation, "Full path to the SnapRAID application.");
            this.snapRAIDFileLocation.TextChanged += new System.EventHandler(this.snapRAIDFileLocation_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.configFileLocation);
            this.panel2.Controls.Add(this.findConfigFile);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.snapRAIDFileLocation);
            this.panel2.Controls.Add(this.findExeFile);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(870, 65);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "SnapRAID &Config file:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // findConfigFile
            // 
            this.findConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findConfigFile.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findConfigFile.Location = new System.Drawing.Point(700, 32);
            this.findConfigFile.Name = "findConfigFile";
            this.findConfigFile.Size = new System.Drawing.Size(35, 25);
            this.findConfigFile.TabIndex = 5;
            this.findConfigFile.Text = "...";
            this.findConfigFile.UseVisualStyleBackColor = true;
            this.findConfigFile.Click += new System.EventHandler(this.findConfigFile_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Snap&RAID.exe:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // findExeFile
            // 
            this.findExeFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findExeFile.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findExeFile.Location = new System.Drawing.Point(700, 3);
            this.findExeFile.Name = "findExeFile";
            this.findExeFile.Size = new System.Drawing.Size(35, 25);
            this.findExeFile.TabIndex = 2;
            this.findExeFile.Text = "...";
            this.findExeFile.UseVisualStyleBackColor = true;
            this.findExeFile.Click += new System.EventHandler(this.findExeFile_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "https://github.com/Smurf-IV/Elucidatewikipage?title=Settings";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 710);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.helpProvider1.SetHelpKeyword(this, "d");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.helpProvider1.SetShowHelp(this, true);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings to control SnapRAID";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.drivesAndDirectoriesMenu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.SnapShotsMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAutoSaveGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlockSizeKB)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exludedFilesView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

      }

      #endregion

      private ToolStripMenuItem DRUnit_NewNode;
      private TreeView driveAndDirTreeView;
      private ContextMenuStrip drivesAndDirectoriesMenu;
      private ToolStripMenuItem refreshStripMenuItem;
      private ToolStripMenuItem toolStripMenuItem1;
      private ToolStripMenuItem advancedSettingsToolStripMenuItem;
      private ImageList imageListUnits;
      private ToolTip toolTip1;
      private GroupBox groupBox2;
      private ToolStripMenuItem removeToolStripMenuItem;
      private ContextMenuStrip SnapShotsMenu;
      private TreeView snapShotSourcesTreeView;
      private GroupBox groupBox1;
      private SplitContainer splitContainer1;
      private TableLayoutPanel tableLayoutPanel1;
      private Panel panel2;
      private DataGridView exludedFilesView;
      private Label label1;
      private TextBox configFileLocation;
      private ErrorProvider errorProvider1;
      private Button findConfigFile;
      private Label label2;
      private TextBox snapRAIDFileLocation;
      private Button findExeFile;
      private TextBox parityLocation2;
      private Button findParity2;
      private Label labelParity1;
      private TextBox parityLocation1;
      private Button findParity1;
      private DataGridViewTextBoxColumn ExcludedFilesPatterns;
      private Button btnReset;
      private Button btnSave;
      private HelpProvider helpProvider1;
      private FolderBrowserDialog folderBrowserDialog1;
      private CheckedListBox checkedListBox1;
      private GroupBox groupBox3;
      private NumericUpDown numBlockSizeKB;
      private Label label4;
      private NumericUpDown numAutoSaveGB;
      private Label label6;
      private DriveSpaceDisplay driveSpace;
      private Button btnGetRecommended;
        private Label labelParity2;
        private Label labelParity6;
        private Label labelParity5;
        private Label labelParity4;
        private Label labelParity3;
        private TextBox parityLocation3;
        private Button findParity3;
        private TextBox parityLocation6;
        private TextBox parityLocation5;
        private TextBox parityLocation4;
        private Button findParity6;
        private Button findParity5;
        private Button findParity4;

        private List<string> IncludePatterns { get; set; }

   }
}