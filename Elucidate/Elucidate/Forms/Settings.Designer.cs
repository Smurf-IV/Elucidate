﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Elucidate.Controls;
using Elucidate.Shared;

namespace Elucidate.Forms
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
            this.SnapShotsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DRUnit_NewNode = new System.Windows.Forms.ToolStripMenuItem();
            this.editNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivesAndDirectoriesMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListUnits = new System.Windows.Forms.ImageList(this.components);
            this.grpParityLocations = new Krypton.Toolkit.KryptonGroupBox();
            this.findParity6 = new Krypton.Toolkit.KryptonButton();
            this.findParity5 = new Krypton.Toolkit.KryptonButton();
            this.findParity4 = new Krypton.Toolkit.KryptonButton();
            this.parityLocation6 = new Krypton.Toolkit.KryptonTextBox();
            this.parityLocation5 = new Krypton.Toolkit.KryptonTextBox();
            this.parityLocation4 = new Krypton.Toolkit.KryptonTextBox();
            this.findParity3 = new Krypton.Toolkit.KryptonButton();
            this.labelParity6 = new Krypton.Toolkit.KryptonLabel();
            this.labelParity5 = new Krypton.Toolkit.KryptonLabel();
            this.labelParity4 = new Krypton.Toolkit.KryptonLabel();
            this.labelParity3 = new JCS.ToggleSwitch.SlideSwitch();
            this.parityLocation3 = new Krypton.Toolkit.KryptonTextBox();
            this.labelParity2 = new Krypton.Toolkit.KryptonLabel();
            this.parityLocation2 = new Krypton.Toolkit.KryptonTextBox();
            this.findParity2 = new Krypton.Toolkit.KryptonButton();
            this.labelParity1 = new Krypton.Toolkit.KryptonLabel();
            this.parityLocation1 = new Krypton.Toolkit.KryptonTextBox();
            this.findParity1 = new Krypton.Toolkit.KryptonButton();
            this.grpSnapShotSources = new Krypton.Toolkit.KryptonGroupBox();
            this.splitContainer1 = new Krypton.Toolkit.KryptonSplitContainer();
            this.driveAndDirTreeView = new Elucidate.Shared.BufferedTreeView();
            this.groupBox3 = new Krypton.Toolkit.KryptonGroupBox();
            this.btnGetRecommended = new Krypton.Toolkit.KryptonButton();
            this.checkedListBox1 = new Krypton.Toolkit.KryptonCheckedListBox();
            this.numAutoSaveGB = new Krypton.Toolkit.KryptonNumericUpDown();
            this.label6 = new Krypton.Toolkit.KryptonLabel();
            this.numBlockSizeKB = new Elucidate.Shared.NumericUpDownPowerOfTwo();
            this.label4 = new Krypton.Toolkit.KryptonLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.exludedFilesView = new Krypton.Toolkit.KryptonDataGridView();
            this.ExcludedFilesPatterns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSave = new Krypton.Toolkit.KryptonButton();
            this.btnReset = new Krypton.Toolkit.KryptonButton();
            this.configFileLocation = new Krypton.Toolkit.KryptonTextBox();
            this.snapRAIDFileLocation = new Krypton.Toolkit.KryptonTextBox();
            this.panel2 = new Krypton.Toolkit.KryptonPanel();
            this.label1 = new Krypton.Toolkit.KryptonLabel();
            this.findConfigFile = new Krypton.Toolkit.KryptonButton();
            this.label2 = new Krypton.Toolkit.KryptonLabel();
            this.findExeFile = new Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.SnapShotsMenu.SuspendLayout();
            this.drivesAndDirectoriesMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpParityLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpParityLocations.Panel)).BeginInit();
            this.grpParityLocations.Panel.SuspendLayout();
            this.grpParityLocations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSnapShotSources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSnapShotSources.Panel)).BeginInit();
            this.grpSnapShotSources.Panel.SuspendLayout();
            this.grpSnapShotSources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1.Panel1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1.Panel2)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3.Panel)).BeginInit();
            this.groupBox3.Panel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBlockSizeKB)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exludedFilesView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // snapShotSources
            // 
            this.snapShotSources.AllowDrop = true;
            this.snapShotSources.ContextMenuStrip = this.SnapShotsMenu;
            this.snapShotSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.snapShotSources.Location = new System.Drawing.Point(0, 0);
            this.snapShotSources.Margin = new System.Windows.Forms.Padding(4);
            this.snapShotSources.Name = "snapShotSources";
            this.snapShotSources.Size = new System.Drawing.Size(654, 320);
            this.snapShotSources.TabIndex = 0;
            this.snapShotSources.KeyUp += new System.Windows.Forms.KeyEventHandler(this.snapShotSourcesTreeView_KeyUp);
            // 
            // SnapShotsMenu
            // 
            this.SnapShotsMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SnapShotsMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.SnapShotsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.DRUnit_NewNode,
            this.editNameToolStripMenuItem});
            this.SnapShotsMenu.Name = "unitsMenu";
            this.SnapShotsMenu.Size = new System.Drawing.Size(177, 76);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.removeToolStripMenuItem.Text = "&Delete";
            this.removeToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // DRUnit_NewNode
            // 
            this.DRUnit_NewNode.Name = "DRUnit_NewNode";
            this.DRUnit_NewNode.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.DRUnit_NewNode.Size = new System.Drawing.Size(176, 24);
            this.DRUnit_NewNode.Text = "&New Node";
            this.DRUnit_NewNode.Click += new System.EventHandler(this.DRUnit_NewNode_MenuItem_Click);
            // 
            // editNameToolStripMenuItem
            // 
            this.editNameToolStripMenuItem.Name = "editNameToolStripMenuItem";
            this.editNameToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.editNameToolStripMenuItem.Text = "&Edit Name";
            this.editNameToolStripMenuItem.Click += new System.EventHandler(this.editName_Click);
            // 
            // drivesAndDirectoriesMenu
            // 
            this.drivesAndDirectoriesMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.drivesAndDirectoriesMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.drivesAndDirectoriesMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshStripMenuItem,
            this.toolStripMenuItem1});
            this.drivesAndDirectoriesMenu.Name = "unitsMenu";
            this.drivesAndDirectoriesMenu.Size = new System.Drawing.Size(223, 52);
            // 
            // refreshStripMenuItem
            // 
            this.refreshStripMenuItem.Name = "refreshStripMenuItem";
            this.refreshStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.refreshStripMenuItem.Text = "&Refresh";
            this.refreshStripMenuItem.Click += new System.EventHandler(this.refreshStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.toolStripMenuItem1.Size = new System.Drawing.Size(222, 24);
            this.toolStripMenuItem1.Text = "&Add To Snap shot";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
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
            // grpParityLocations
            // 
            this.grpParityLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpParityLocations.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grpParityLocations.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpParityLocations.Location = new System.Drawing.Point(3, 351);
            this.grpParityLocations.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.grpParityLocations.Name = "grpParityLocations";
            // 
            // grpParityLocations.Panel
            // 
            this.grpParityLocations.Panel.Controls.Add(this.parityLocation2);
            this.grpParityLocations.Panel.Controls.Add(this.parityLocation1);
            this.grpParityLocations.Panel.Controls.Add(this.findParity6);
            this.grpParityLocations.Panel.Controls.Add(this.findParity5);
            this.grpParityLocations.Panel.Controls.Add(this.findParity4);
            this.grpParityLocations.Panel.Controls.Add(this.parityLocation6);
            this.grpParityLocations.Panel.Controls.Add(this.parityLocation5);
            this.grpParityLocations.Panel.Controls.Add(this.parityLocation4);
            this.grpParityLocations.Panel.Controls.Add(this.findParity3);
            this.grpParityLocations.Panel.Controls.Add(this.labelParity6);
            this.grpParityLocations.Panel.Controls.Add(this.labelParity5);
            this.grpParityLocations.Panel.Controls.Add(this.labelParity4);
            this.grpParityLocations.Panel.Controls.Add(this.labelParity3);
            this.grpParityLocations.Panel.Controls.Add(this.parityLocation3);
            this.grpParityLocations.Panel.Controls.Add(this.labelParity2);
            this.grpParityLocations.Panel.Controls.Add(this.findParity2);
            this.grpParityLocations.Panel.Controls.Add(this.labelParity1);
            this.grpParityLocations.Panel.Controls.Add(this.findParity1);
            this.grpParityLocations.Size = new System.Drawing.Size(658, 200);
            this.grpParityLocations.TabIndex = 1;
            this.grpParityLocations.Values.Heading = "Parity file locations:";
            // 
            // findParity6
            // 
            this.findParity6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findParity6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findParity6.Location = new System.Drawing.Point(616, 142);
            this.findParity6.Name = "findParity6";
            this.findParity6.Size = new System.Drawing.Size(35, 25);
            this.findParity6.TabIndex = 17;
            this.findParity6.ToolTipValues.Description = "Optional root location for minimum protection";
            this.findParity6.ToolTipValues.EnableToolTips = true;
            this.findParity6.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.findParity6.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.findParity6.Values.Text = "...";
            this.findParity6.Click += new System.EventHandler(this.findParity6_Click);
            // 
            // findParity5
            // 
            this.findParity5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findParity5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findParity5.Location = new System.Drawing.Point(616, 114);
            this.findParity5.Name = "findParity5";
            this.findParity5.Size = new System.Drawing.Size(35, 25);
            this.findParity5.TabIndex = 14;
            this.findParity5.ToolTipValues.Description = "Optional root location for minimum protection";
            this.findParity5.ToolTipValues.EnableToolTips = true;
            this.findParity5.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.findParity5.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.findParity5.Values.Text = "...";
            this.findParity5.Click += new System.EventHandler(this.findParity5_Click);
            // 
            // findParity4
            // 
            this.findParity4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findParity4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findParity4.Location = new System.Drawing.Point(616, 86);
            this.findParity4.Name = "findParity4";
            this.findParity4.Size = new System.Drawing.Size(35, 25);
            this.findParity4.TabIndex = 11;
            this.findParity4.ToolTipValues.Description = "Optional root location for minimum protection";
            this.findParity4.ToolTipValues.EnableToolTips = true;
            this.findParity4.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.findParity4.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.findParity4.Values.Text = "...";
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
            this.parityLocation6.Location = new System.Drawing.Point(65, 144);
            this.parityLocation6.Name = "parityLocation6";
            this.helpProvider1.SetShowHelp(this.parityLocation6, true);
            this.parityLocation6.Size = new System.Drawing.Size(527, 27);
            this.parityLocation6.TabIndex = 16;
            this.parityLocation6.ToolTipValues.Description = "Optional root location for minimum protection";
            this.parityLocation6.ToolTipValues.EnableToolTips = true;
            this.parityLocation6.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.parityLocation6.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.parityLocation6.Leave += new System.EventHandler(this.parityLocation6_Leave);
            // 
            // parityLocation5
            // 
            this.parityLocation5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parityLocation5.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider1.SetError(this.parityLocation5, "Config File does not exist");
            this.helpProvider1.SetHelpKeyword(this.parityLocation5, "ParityLocs");
            this.helpProvider1.SetHelpNavigator(this.parityLocation5, System.Windows.Forms.HelpNavigator.Topic);
            this.parityLocation5.Location = new System.Drawing.Point(65, 116);
            this.parityLocation5.Name = "parityLocation5";
            this.helpProvider1.SetShowHelp(this.parityLocation5, true);
            this.parityLocation5.Size = new System.Drawing.Size(527, 27);
            this.parityLocation5.TabIndex = 13;
            this.parityLocation5.ToolTipValues.Description = "Optional root location for minimum protection";
            this.parityLocation5.ToolTipValues.EnableToolTips = true;
            this.parityLocation5.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.parityLocation5.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.parityLocation5.Leave += new System.EventHandler(this.parityLocation5_Leave);
            // 
            // parityLocation4
            // 
            this.parityLocation4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parityLocation4.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider1.SetError(this.parityLocation4, "Config File does not exist");
            this.helpProvider1.SetHelpKeyword(this.parityLocation4, "ParityLocs");
            this.helpProvider1.SetHelpNavigator(this.parityLocation4, System.Windows.Forms.HelpNavigator.Topic);
            this.parityLocation4.Location = new System.Drawing.Point(65, 88);
            this.parityLocation4.Name = "parityLocation4";
            this.helpProvider1.SetShowHelp(this.parityLocation4, true);
            this.parityLocation4.Size = new System.Drawing.Size(527, 27);
            this.parityLocation4.TabIndex = 10;
            this.parityLocation4.ToolTipValues.Description = "Optional root location for minimum protection";
            this.parityLocation4.ToolTipValues.EnableToolTips = true;
            this.parityLocation4.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.parityLocation4.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.parityLocation4.Leave += new System.EventHandler(this.parityLocation4_Leave);
            // 
            // findParity3
            // 
            this.findParity3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findParity3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findParity3.Location = new System.Drawing.Point(616, 58);
            this.findParity3.Name = "findParity3";
            this.findParity3.Size = new System.Drawing.Size(35, 25);
            this.findParity3.TabIndex = 8;
            this.findParity3.ToolTipValues.Description = "Optional root location for minimum protection";
            this.findParity3.ToolTipValues.EnableToolTips = true;
            this.findParity3.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.findParity3.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.findParity3.Values.Text = "...";
            this.findParity3.Click += new System.EventHandler(this.findParity3_Click);
            // 
            // labelParity6
            // 
            this.labelParity6.Location = new System.Drawing.Point(6, 144);
            this.labelParity6.Name = "labelParity6";
            this.labelParity6.Size = new System.Drawing.Size(66, 24);
            this.labelParity6.TabIndex = 15;
            this.labelParity6.TabStop = false;
            this.labelParity6.Target = this.parityLocation6;
            this.labelParity6.ToolTipValues.Description = "Optional root location for minimum protection";
            this.labelParity6.ToolTipValues.EnableToolTips = true;
            this.labelParity6.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.labelParity6.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.labelParity6.Values.Text = "Parity &6:";
            // 
            // labelParity5
            // 
            this.labelParity5.Location = new System.Drawing.Point(6, 116);
            this.labelParity5.Name = "labelParity5";
            this.labelParity5.Size = new System.Drawing.Size(66, 24);
            this.labelParity5.TabIndex = 12;
            this.labelParity5.TabStop = false;
            this.labelParity5.Target = this.parityLocation5;
            this.labelParity5.ToolTipValues.Description = "Optional root location for minimum protection";
            this.labelParity5.ToolTipValues.EnableToolTips = true;
            this.labelParity5.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.labelParity5.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.labelParity5.Values.Text = "Parity &5:";
            // 
            // labelParity4
            // 
            this.labelParity4.Location = new System.Drawing.Point(6, 88);
            this.labelParity4.Name = "labelParity4";
            this.labelParity4.Size = new System.Drawing.Size(66, 24);
            this.labelParity4.TabIndex = 9;
            this.labelParity4.TabStop = false;
            this.labelParity4.Target = this.parityLocation4;
            this.labelParity4.ToolTipValues.Description = "Optional root location for minimum protection";
            this.labelParity4.ToolTipValues.EnableToolTips = true;
            this.labelParity4.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.labelParity4.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.labelParity4.Values.Text = "Parity &4:";
            // 
            // labelParity3
            // 
            this.labelParity3.BackColor = System.Drawing.Color.Transparent;
            this.labelParity3.Checked = true;
            this.labelParity3.Location = new System.Drawing.Point(0, 61);
            this.labelParity3.Name = "labelParity3";
            this.labelParity3.OffFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParity3.OffSideAlignment = JCS.ToggleSwitch.SlideSwitch.ToggleSwitchAlignment.Far;
            this.labelParity3.OffText = "Parity 3";
            this.labelParity3.OnFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParity3.OnSideAlignment = JCS.ToggleSwitch.SlideSwitch.ToggleSwitchAlignment.Near;
            this.labelParity3.OnText = "Z-Parity";
            this.labelParity3.Size = new System.Drawing.Size(63, 19);
            this.labelParity3.Style = JCS.ToggleSwitch.SlideSwitch.ToggleSwitchStyle.IOS5;
            this.labelParity3.TabIndex = 6;
            this.toolTip1.SetToolTip(this.labelParity3, "Optional root location for 3 or Z parity protection");
            this.labelParity3.CheckedChanged += new JCS.ToggleSwitch.SlideSwitch.CheckedChangedDelegate(this.labelParity3_CheckedChanged);
            // 
            // parityLocation3
            // 
            this.parityLocation3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parityLocation3.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider1.SetError(this.parityLocation3, "Config File does not exist");
            this.helpProvider1.SetHelpKeyword(this.parityLocation3, "ParityLocs");
            this.helpProvider1.SetHelpNavigator(this.parityLocation3, System.Windows.Forms.HelpNavigator.Topic);
            this.parityLocation3.Location = new System.Drawing.Point(65, 60);
            this.parityLocation3.Name = "parityLocation3";
            this.helpProvider1.SetShowHelp(this.parityLocation3, true);
            this.parityLocation3.Size = new System.Drawing.Size(527, 27);
            this.parityLocation3.TabIndex = 7;
            this.parityLocation3.ToolTipValues.Description = "Optional root location for minimum protection";
            this.parityLocation3.ToolTipValues.EnableToolTips = true;
            this.parityLocation3.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.parityLocation3.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.parityLocation3.Leave += new System.EventHandler(this.parityLocation3_Leave);
            // 
            // labelParity2
            // 
            this.labelParity2.Location = new System.Drawing.Point(6, 33);
            this.labelParity2.Name = "labelParity2";
            this.labelParity2.Size = new System.Drawing.Size(66, 24);
            this.labelParity2.TabIndex = 3;
            this.labelParity2.TabStop = false;
            this.labelParity2.Target = this.parityLocation2;
            this.labelParity2.ToolTipValues.Description = "Optional root location for minimum protection";
            this.labelParity2.ToolTipValues.EnableToolTips = true;
            this.labelParity2.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.labelParity2.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.labelParity2.Values.Text = "Parity &2:";
            // 
            // parityLocation2
            // 
            this.parityLocation2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parityLocation2.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider1.SetError(this.parityLocation2, "Config File does not exist");
            this.helpProvider1.SetHelpKeyword(this.parityLocation2, "ParityLocs");
            this.helpProvider1.SetHelpNavigator(this.parityLocation2, System.Windows.Forms.HelpNavigator.Topic);
            this.parityLocation2.Location = new System.Drawing.Point(65, 33);
            this.parityLocation2.Name = "parityLocation2";
            this.helpProvider1.SetShowHelp(this.parityLocation2, true);
            this.parityLocation2.Size = new System.Drawing.Size(527, 27);
            this.parityLocation2.TabIndex = 4;
            this.parityLocation2.ToolTipValues.Description = "Optional root location for minimum protection";
            this.parityLocation2.ToolTipValues.EnableToolTips = true;
            this.parityLocation2.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.parityLocation2.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.parityLocation2.Leave += new System.EventHandler(this.parityLocation2_Leave);
            // 
            // findParity2
            // 
            this.findParity2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findParity2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findParity2.Location = new System.Drawing.Point(616, 31);
            this.findParity2.Name = "findParity2";
            this.findParity2.Size = new System.Drawing.Size(35, 25);
            this.findParity2.TabIndex = 5;
            this.findParity2.ToolTipValues.Description = "Optional root location for minimum protection";
            this.findParity2.ToolTipValues.EnableToolTips = true;
            this.findParity2.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.findParity2.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.findParity2.Values.Text = "...";
            this.findParity2.Click += new System.EventHandler(this.findParity2_Click);
            // 
            // labelParity1
            // 
            this.labelParity1.Location = new System.Drawing.Point(6, 5);
            this.labelParity1.Name = "labelParity1";
            this.labelParity1.Size = new System.Drawing.Size(66, 24);
            this.labelParity1.TabIndex = 0;
            this.labelParity1.TabStop = false;
            this.labelParity1.Target = this.parityLocation1;
            this.labelParity1.ToolTipValues.Description = "Optional root location for minimum protection";
            this.labelParity1.ToolTipValues.EnableToolTips = true;
            this.labelParity1.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.labelParity1.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.labelParity1.Values.Text = "Parity &1:";
            // 
            // parityLocation1
            // 
            this.parityLocation1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parityLocation1.BackColor = System.Drawing.SystemColors.Window;
            this.errorProvider1.SetError(this.parityLocation1, "Executeable Not found");
            this.helpProvider1.SetHelpKeyword(this.parityLocation1, "ParityLocs");
            this.helpProvider1.SetHelpNavigator(this.parityLocation1, System.Windows.Forms.HelpNavigator.Topic);
            this.parityLocation1.Location = new System.Drawing.Point(65, 5);
            this.parityLocation1.Name = "parityLocation1";
            this.helpProvider1.SetShowHelp(this.parityLocation1, true);
            this.parityLocation1.Size = new System.Drawing.Size(527, 27);
            this.parityLocation1.TabIndex = 1;
            this.parityLocation1.Text = "Z:\\";
            this.parityLocation1.ToolTipValues.Description = "Mandatory root location for minimum protection";
            this.parityLocation1.ToolTipValues.EnableToolTips = true;
            this.parityLocation1.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.parityLocation1.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.parityLocation1.Leave += new System.EventHandler(this.parityLocation1_Leave);
            // 
            // findParity1
            // 
            this.findParity1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findParity1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findParity1.Location = new System.Drawing.Point(616, 2);
            this.findParity1.Name = "findParity1";
            this.findParity1.Size = new System.Drawing.Size(35, 26);
            this.findParity1.TabIndex = 2;
            this.findParity1.ToolTipValues.Description = "Mandatory root location for minimum protection";
            this.findParity1.ToolTipValues.EnableToolTips = true;
            this.findParity1.ToolTipValues.Heading = "Specify multiple files for a single parity.\r\nAs soon a file cannot grow anymore, " +
    "the next one starts growing.\r\nJust put more files in the same \'parity\' line, sep" +
    "arated by , (comma).";
            this.findParity1.ToolTipValues.Image = global::Elucidate.Properties.Resources.database_add_48;
            this.findParity1.Values.Text = "...";
            this.findParity1.Click += new System.EventHandler(this.findParity1_Click);
            // 
            // grpSnapShotSources
            // 
            this.grpSnapShotSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSnapShotSources.Font = new System.Drawing.Font("Tahoma", 9F);
            this.grpSnapShotSources.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grpSnapShotSources.Location = new System.Drawing.Point(3, 0);
            this.grpSnapShotSources.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.grpSnapShotSources.Name = "grpSnapShotSources";
            // 
            // grpSnapShotSources.Panel
            // 
            this.grpSnapShotSources.Panel.Controls.Add(this.snapShotSources);
            this.grpSnapShotSources.Size = new System.Drawing.Size(658, 348);
            this.grpSnapShotSources.TabIndex = 0;
            this.grpSnapShotSources.Values.Heading = "S&nap Shot Sources";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 65);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.driveAndDirTreeView);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.splitContainer1.Panel1MinSize = 320;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2MinSize = 450;
            this.splitContainer1.SeparatorStyle = Krypton.Toolkit.SeparatorStyle.HighInternalProfile;
            this.splitContainer1.Size = new System.Drawing.Size(1016, 645);
            this.splitContainer1.SplitterDistance = 347;
            this.splitContainer1.TabIndex = 4;
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
            this.driveAndDirTreeView.Location = new System.Drawing.Point(0, 3);
            this.driveAndDirTreeView.Name = "driveAndDirTreeView";
            this.driveAndDirTreeView.SelectedImageIndex = 0;
            this.helpProvider1.SetShowHelp(this.driveAndDirTreeView, true);
            this.driveAndDirTreeView.Size = new System.Drawing.Size(347, 456);
            this.driveAndDirTreeView.TabIndex = 1;
            this.toolTip1.SetToolTip(this.driveAndDirTreeView, "Possible sources to be used for snap shot.");
            this.driveAndDirTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.driveAndDirTreeView_BeforeExpand);
            this.driveAndDirTreeView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.driveAndDirTreeView_MouseDoubleClick);
            this.driveAndDirTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.driveAndDirTreeView_MouseDown);
            this.driveAndDirTreeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.driveAndDirTreeView_MouseUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 459);
            this.groupBox3.Name = "groupBox3";
            // 
            // groupBox3.Panel
            // 
            this.groupBox3.Panel.Controls.Add(this.btnGetRecommended);
            this.groupBox3.Panel.Controls.Add(this.checkedListBox1);
            this.groupBox3.Panel.Controls.Add(this.numAutoSaveGB);
            this.groupBox3.Panel.Controls.Add(this.label6);
            this.groupBox3.Panel.Controls.Add(this.numBlockSizeKB);
            this.groupBox3.Panel.Controls.Add(this.label4);
            this.groupBox3.Size = new System.Drawing.Size(347, 186);
            this.groupBox3.TabIndex = 0;
            this.toolTip1.SetToolTip(this.groupBox3, "Unusual settings.");
            this.groupBox3.Values.Heading = "Advanced";
            // 
            // btnGetRecommended
            // 
            this.btnGetRecommended.Location = new System.Drawing.Point(190, 1);
            this.btnGetRecommended.Name = "btnGetRecommended";
            this.btnGetRecommended.Size = new System.Drawing.Size(137, 24);
            this.btnGetRecommended.TabIndex = 2;
            this.btnGetRecommended.Values.Text = "C&alculate ...";
            this.btnGetRecommended.Click += new System.EventHandler(this.btnGetRecommended_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox1.BackStyle = Krypton.Toolkit.PaletteBackStyle.PanelClient;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.helpProvider1.SetHelpString(this.checkedListBox1, "UseVerbose");
            this.checkedListBox1.Location = new System.Drawing.Point(5, 58);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.helpProvider1.SetShowHelp(this.checkedListBox1, true);
            this.checkedListBox1.Size = new System.Drawing.Size(334, 102);
            this.checkedListBox1.TabIndex = 5;
            this.toolTip1.SetToolTip(this.checkedListBox1, "Caution: You must know wat these settings are.");
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.checkedListBox1_MouseMove);
            // 
            // numAutoSaveGB
            // 
            this.numAutoSaveGB.AllowDecimals = true;
            this.numAutoSaveGB.DecimalPlaces = 99;
            this.numAutoSaveGB.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numAutoSaveGB.Location = new System.Drawing.Point(110, 30);
            this.numAutoSaveGB.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numAutoSaveGB.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numAutoSaveGB.Name = "numAutoSaveGB";
            this.numAutoSaveGB.Size = new System.Drawing.Size(74, 26);
            this.numAutoSaveGB.TabIndex = 4;
            this.toolTip1.SetToolTip(this.numAutoSaveGB, "You could increase this value if you do not have enough RAM memory to run SnapRAI" +
        "D\r\nAs a rule of thumb, with 4GB or more memory use the default 256, with 2GB use" +
        " 512, and with 1GB use 1024.");
            this.numAutoSaveGB.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numAutoSaveGB.ValueChanged += new System.EventHandler(this.numAutoSaveGB_ValueChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 24);
            this.label6.TabIndex = 3;
            this.label6.TabStop = false;
            this.label6.Target = this.numAutoSaveGB;
            this.toolTip1.SetToolTip(this.label6, "The number of processed GigaBytes before a save; 0 is off.");
            this.label6.Values.Text = "AutoSave &GB:";
            // 
            // numBlockSizeKB
            // 
            this.numBlockSizeKB.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numBlockSizeKB.Location = new System.Drawing.Point(110, 3);
            this.numBlockSizeKB.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.numBlockSizeKB.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numBlockSizeKB.Name = "numBlockSizeKB";
            this.numBlockSizeKB.Size = new System.Drawing.Size(74, 26);
            this.numBlockSizeKB.TabIndex = 1;
            this.toolTip1.SetToolTip(this.numBlockSizeKB, resources.GetString("numBlockSizeKB.ToolTip"));
            this.numBlockSizeKB.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numBlockSizeKB.ValueChanged += new System.EventHandler(this.numBlockSizeKB_ValueChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 24);
            this.label4.TabIndex = 0;
            this.label4.TabStop = false;
            this.label4.Target = this.numBlockSizeKB;
            this.toolTip1.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            this.label4.Values.Text = "&Block Size KB:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grpSnapShotSources, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpParityLocations, 0, 1);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(664, 645);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // exludedFilesView
            // 
            this.exludedFilesView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.exludedFilesView.ColumnHeadersHeight = 36;
            this.exludedFilesView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExcludedFilesPatterns});
            this.exludedFilesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exludedFilesView.Font = new System.Drawing.Font("Tahoma", 9F);
            this.helpProvider1.SetHelpKeyword(this.exludedFilesView, "FilterExclusions");
            this.helpProvider1.SetHelpNavigator(this.exludedFilesView, System.Windows.Forms.HelpNavigator.Topic);
            this.exludedFilesView.Location = new System.Drawing.Point(3, 557);
            this.exludedFilesView.Name = "exludedFilesView";
            this.exludedFilesView.RowHeadersWidth = 51;
            this.exludedFilesView.ShowCellToolTips = false;
            this.helpProvider1.SetShowHelp(this.exludedFilesView, true);
            this.exludedFilesView.Size = new System.Drawing.Size(658, 85);
            this.exludedFilesView.StateCommon.BackStyle = Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.exludedFilesView.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exludedFilesView.StateCommon.HeaderColumn.Content.Hint = Krypton.Toolkit.PaletteTextHint.AntiAlias;
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
            this.ExcludedFilesPatterns.MinimumWidth = 6;
            this.ExcludedFilesPatterns.Name = "ExcludedFilesPatterns";
            this.ExcludedFilesPatterns.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpProvider1.SetHelpKeyword(this.btnSave, "SaveSettings");
            this.helpProvider1.SetHelpNavigator(this.btnSave, System.Windows.Forms.HelpNavigator.Topic);
            this.errorProvider1.SetIconAlignment(this.btnSave, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.btnSave.Location = new System.Drawing.Point(872, 34);
            this.btnSave.Name = "btnSave";
            this.helpProvider1.SetShowHelp(this.btnSave, true);
            this.btnSave.Size = new System.Drawing.Size(136, 27);
            this.btnSave.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnSave, "Save these settings to the config file.");
            this.btnSave.Values.Text = "&Save settings";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpProvider1.SetHelpKeyword(this.btnReset, "ResetToLastConfig");
            this.helpProvider1.SetHelpNavigator(this.btnReset, System.Windows.Forms.HelpNavigator.Topic);
            this.btnReset.Location = new System.Drawing.Point(872, 2);
            this.btnReset.Name = "btnReset";
            this.helpProvider1.SetShowHelp(this.btnReset, true);
            this.btnReset.Size = new System.Drawing.Size(136, 27);
            this.btnReset.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnReset, "Reset the values to the config file.");
            this.btnReset.Values.Text = "Reset to &last config";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // configFileLocation
            // 
            this.configFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configFileLocation.BackColor = System.Drawing.SystemColors.ControlLight;
            this.errorProvider1.SetError(this.configFileLocation, "Config File does not exist");
            this.helpProvider1.SetHelpKeyword(this.configFileLocation, "SnapRAID.config");
            this.helpProvider1.SetHelpNavigator(this.configFileLocation, System.Windows.Forms.HelpNavigator.Topic);
            this.configFileLocation.Location = new System.Drawing.Point(135, 37);
            this.configFileLocation.Name = "configFileLocation";
            this.configFileLocation.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.configFileLocation, true);
            this.configFileLocation.Size = new System.Drawing.Size(677, 27);
            this.configFileLocation.TabIndex = 5;
            this.toolTip1.SetToolTip(this.configFileLocation, "Full path to the SnapRAID config file.");
            this.configFileLocation.WordWrap = false;
            this.configFileLocation.TextChanged += new System.EventHandler(this.configFileLocation_TextChanged);
            // 
            // snapRAIDFileLocation
            // 
            this.snapRAIDFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.snapRAIDFileLocation.BackColor = System.Drawing.SystemColors.ControlLight;
            this.errorProvider1.SetError(this.snapRAIDFileLocation, "Executeable Not found");
            this.helpProvider1.SetHelpKeyword(this.snapRAIDFileLocation, "SnapRAID.Exe");
            this.helpProvider1.SetHelpNavigator(this.snapRAIDFileLocation, System.Windows.Forms.HelpNavigator.Topic);
            this.helpProvider1.SetHelpString(this.snapRAIDFileLocation, "");
            this.snapRAIDFileLocation.Location = new System.Drawing.Point(135, 5);
            this.snapRAIDFileLocation.Name = "snapRAIDFileLocation";
            this.snapRAIDFileLocation.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.snapRAIDFileLocation, true);
            this.snapRAIDFileLocation.Size = new System.Drawing.Size(677, 27);
            this.snapRAIDFileLocation.TabIndex = 1;
            this.snapRAIDFileLocation.Text = "Stick some text in here";
            this.toolTip1.SetToolTip(this.snapRAIDFileLocation, "Full path to the SnapRAID application.");
            this.snapRAIDFileLocation.WordWrap = false;
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
            this.panel2.Size = new System.Drawing.Size(1016, 65);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 4;
            this.label1.TabStop = false;
            this.label1.Target = this.configFileLocation;
            this.label1.Values.Text = "SR &Config file:";
            // 
            // findConfigFile
            // 
            this.findConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findConfigFile.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findConfigFile.Location = new System.Drawing.Point(831, 35);
            this.findConfigFile.Name = "findConfigFile";
            this.findConfigFile.Size = new System.Drawing.Size(35, 25);
            this.findConfigFile.TabIndex = 6;
            this.findConfigFile.Values.Text = "...";
            this.findConfigFile.Click += new System.EventHandler(this.findConfigFile_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 24);
            this.label2.TabIndex = 0;
            this.label2.TabStop = false;
            this.label2.Target = this.snapRAIDFileLocation;
            this.label2.Values.Text = "Snap&RAID.exe:";
            // 
            // findExeFile
            // 
            this.findExeFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findExeFile.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findExeFile.Location = new System.Drawing.Point(831, 3);
            this.findExeFile.Name = "findExeFile";
            this.findExeFile.Size = new System.Drawing.Size(35, 25);
            this.findExeFile.TabIndex = 2;
            this.findExeFile.Values.Text = "...";
            this.findExeFile.Click += new System.EventHandler(this.findExeFile_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "https://github.com/Smurf-IV/Elucidate/blob/master/docs/Settings.md";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.splitContainer1);
            this.kryptonPanel1.Controls.Add(this.panel2);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1016, 710);
            this.kryptonPanel1.TabIndex = 8;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 710);
            this.Controls.Add(this.kryptonPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProvider1.SetHelpKeyword(this, "d");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Topic);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(951, 749);
            this.Name = "Settings";
            this.helpProvider1.SetShowHelp(this, true);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Settings to control SnapRAID";
            this.TextExtra = "Use F1 on fields for help";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.SnapShotsMenu.ResumeLayout(false);
            this.drivesAndDirectoriesMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpParityLocations.Panel)).EndInit();
            this.grpParityLocations.Panel.ResumeLayout(false);
            this.grpParityLocations.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpParityLocations)).EndInit();
            this.grpParityLocations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSnapShotSources.Panel)).EndInit();
            this.grpSnapShotSources.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSnapShotSources)).EndInit();
            this.grpSnapShotSources.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1.Panel1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1.Panel2)).EndInit();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3.Panel)).EndInit();
            this.groupBox3.Panel.ResumeLayout(false);
            this.groupBox3.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numBlockSizeKB)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exludedFilesView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolStripMenuItem DRUnit_NewNode;
        private BufferedTreeView driveAndDirTreeView;
        private ContextMenuStrip drivesAndDirectoriesMenu;
        private ToolStripMenuItem refreshStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ImageList imageListUnits;
        private ToolTip toolTip1;
        private Krypton.Toolkit.KryptonGroupBox grpParityLocations;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ContextMenuStrip SnapShotsMenu;
        private Krypton.Toolkit.KryptonGroupBox grpSnapShotSources;
        private Krypton.Toolkit.KryptonSplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Krypton.Toolkit.KryptonPanel panel2;
        private Krypton.Toolkit.KryptonDataGridView exludedFilesView;
        private Krypton.Toolkit.KryptonLabel label1;
        private Krypton.Toolkit.KryptonTextBox configFileLocation;
        private ErrorProvider errorProvider1;
        private Krypton.Toolkit.KryptonButton findConfigFile;
        private Krypton.Toolkit.KryptonLabel label2;
        private Krypton.Toolkit.KryptonTextBox snapRAIDFileLocation;
        private Krypton.Toolkit.KryptonButton findExeFile;
        private Krypton.Toolkit.KryptonTextBox parityLocation2;
        private Krypton.Toolkit.KryptonButton findParity2;
        private Krypton.Toolkit.KryptonLabel labelParity1;
        private Krypton.Toolkit.KryptonTextBox parityLocation1;
        private Krypton.Toolkit.KryptonButton findParity1;
        private DataGridViewTextBoxColumn ExcludedFilesPatterns;
        private Krypton.Toolkit.KryptonButton btnReset;
        private Krypton.Toolkit.KryptonButton btnSave;
        private HelpProvider helpProvider1;
        private Krypton.Toolkit.KryptonCheckedListBox checkedListBox1;
        private Krypton.Toolkit.KryptonGroupBox groupBox3;
        private NumericUpDownPowerOfTwo numBlockSizeKB;
        private Krypton.Toolkit.KryptonLabel label4;
        private Krypton.Toolkit.KryptonNumericUpDown numAutoSaveGB;
        private Krypton.Toolkit.KryptonLabel label6;
        private Krypton.Toolkit.KryptonButton btnGetRecommended;
        private Krypton.Toolkit.KryptonLabel labelParity2;
        private Krypton.Toolkit.KryptonLabel labelParity6;
        private Krypton.Toolkit.KryptonLabel labelParity5;
        private Krypton.Toolkit.KryptonLabel labelParity4;
        private JCS.ToggleSwitch.SlideSwitch labelParity3;
        private Krypton.Toolkit.KryptonTextBox parityLocation3;
        private Krypton.Toolkit.KryptonButton findParity3;
        private Krypton.Toolkit.KryptonTextBox parityLocation6;
        private Krypton.Toolkit.KryptonTextBox parityLocation5;
        private Krypton.Toolkit.KryptonTextBox parityLocation4;
        private Krypton.Toolkit.KryptonButton findParity6;
        private Krypton.Toolkit.KryptonButton findParity5;
        private Krypton.Toolkit.KryptonButton findParity4;
        private ProtectedDrivesDisplay snapShotSources;
        private ToolStripMenuItem editNameToolStripMenuItem;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;

        private List<string> IncludePatterns { get; set; }

    }
}