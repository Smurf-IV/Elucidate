namespace Elucidate.TabPages
{
    partial class CommonTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.liveRunLogControl1 = new Elucidate.Controls.LiveRunLogControl();
            this.btnSync = new ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton();
            this.btnStatus = new ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton();
            this.btnDupFinder = new ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton();
            this.btnCheck = new ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton();
            this.btnDiff = new ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton();
            this.btnFix = new ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton();
            this.btnForceFullSync = new ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton();
            this.btnScrub = new ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.liveRunLogControl1);
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(919, 499);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnSync, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnStatus, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDupFinder, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCheck, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDiff, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFix, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnForceFullSync, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnScrub, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(919, 240);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(919, 240);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // liveRunLogControl1
            // 
            this.liveRunLogControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liveRunLogControl1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liveRunLogControl1.IsRunning = false;
            this.liveRunLogControl1.Location = new System.Drawing.Point(0, 240);
            this.liveRunLogControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.liveRunLogControl1.Name = "liveRunLogControl1";
            this.liveRunLogControl1.Size = new System.Drawing.Size(919, 259);
            this.liveRunLogControl1.TabIndex = 0;
            // 
            // btnSync
            // 
            this.btnSync.CommandLinkImageValue.Image = global::Elucidate.Properties.Resources.camera_add_48;
            this.btnSync.CommandLinkTextValues.Description = "Synchronise with any changes that may\r\nhave occurred since the last run.";
            this.btnSync.CommandLinkTextValues.Heading = "&Sync";
            this.btnSync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSync.Enabled = false;
            this.btnSync.Location = new System.Drawing.Point(3, 83);
            this.btnSync.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(300, 74);
            this.btnSync.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSync.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnSync.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnSync.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSync.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSync.StateCommon.Border.Rounding = 6;
            this.btnSync.StateCommon.Border.Width = 2;
            this.btnSync.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnSync.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnSync.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnSync.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnSync.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnSync.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnSync.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnSync.TabIndex = 1;
            this.btnSync.ToolTipValues.EnableToolTips = true;
            this.btnSync.ToolTipValues.Heading = "Sync Options:";
            this.btnSync.ToolTipValues.Image = global::Elucidate.Properties.Resources.camera_add_48;
            this.btnSync.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnSync.Click += new System.EventHandler(this.Sync_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.CommandLinkImageValue.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnStatus.CommandLinkTextValues.Description = "A summary of the state of the disk\r\narray, upto the last sync time.";
            this.btnStatus.CommandLinkTextValues.Heading = "S&tatus";
            this.btnStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStatus.Enabled = false;
            this.btnStatus.Location = new System.Drawing.Point(615, 3);
            this.btnStatus.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(301, 74);
            this.btnStatus.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnStatus.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnStatus.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnStatus.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnStatus.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnStatus.StateCommon.Border.Rounding = 6;
            this.btnStatus.StateCommon.Border.Width = 2;
            this.btnStatus.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnStatus.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnStatus.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnStatus.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnStatus.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnStatus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnStatus.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnStatus.TabIndex = 6;
            this.btnStatus.ToolTipValues.EnableToolTips = true;
            this.btnStatus.ToolTipValues.Heading = "Status Options:";
            this.btnStatus.ToolTipValues.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnStatus.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnDupFinder
            // 
            this.btnDupFinder.CommandLinkImageValue.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnDupFinder.CommandLinkTextValues.Description = "Lists all the duplicate files. Two files are\r\nassumed equal if their hashes match" +
    ". ";
            this.btnDupFinder.CommandLinkTextValues.Heading = "Duplicate &Finder";
            this.btnDupFinder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDupFinder.Enabled = false;
            this.btnDupFinder.Location = new System.Drawing.Point(3, 163);
            this.btnDupFinder.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnDupFinder.Name = "btnDupFinder";
            this.btnDupFinder.Size = new System.Drawing.Size(300, 74);
            this.btnDupFinder.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDupFinder.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnDupFinder.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnDupFinder.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDupFinder.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDupFinder.StateCommon.Border.Rounding = 6;
            this.btnDupFinder.StateCommon.Border.Width = 2;
            this.btnDupFinder.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDupFinder.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnDupFinder.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDupFinder.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDupFinder.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnDupFinder.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnDupFinder.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDupFinder.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDupFinder.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnDupFinder.TabIndex = 2;
            this.btnDupFinder.ToolTipValues.EnableToolTips = true;
            this.btnDupFinder.ToolTipValues.Heading = "Duplicate Finder Options:";
            this.btnDupFinder.ToolTipValues.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnDupFinder.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Relative;
            this.btnDupFinder.Click += new System.EventHandler(this.DupFinder_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.CommandLinkImageValue.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnCheck.CommandLinkTextValues.Description = "Check the snapshot to confirm\r\nit\'s integrity. (default -a for hash only)";
            this.btnCheck.CommandLinkTextValues.Heading = "&Check";
            this.btnCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheck.Enabled = false;
            this.btnCheck.Location = new System.Drawing.Point(309, 83);
            this.btnCheck.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(300, 74);
            this.btnCheck.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCheck.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnCheck.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnCheck.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCheck.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCheck.StateCommon.Border.Rounding = 6;
            this.btnCheck.StateCommon.Border.Width = 2;
            this.btnCheck.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnCheck.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnCheck.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnCheck.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnCheck.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnCheck.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnCheck.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnCheck.TabIndex = 4;
            this.btnCheck.ToolTipValues.EnableToolTips = true;
            this.btnCheck.ToolTipValues.Heading = "Check Options:";
            this.btnCheck.ToolTipValues.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnCheck.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnCheck.Click += new System.EventHandler(this.Check_Click);
            // 
            // btnDiff
            // 
            this.btnDiff.CommandLinkImageValue.Image = global::Elucidate.Properties.Resources.cam_48;
            this.btnDiff.CommandLinkTextValues.Description = "Lists all the files have been modified\r\nsince the last \"sync\" command.";
            this.btnDiff.CommandLinkTextValues.Heading = "&Differences";
            this.btnDiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDiff.Enabled = false;
            this.btnDiff.Location = new System.Drawing.Point(3, 3);
            this.btnDiff.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnDiff.Name = "btnDiff";
            this.btnDiff.Size = new System.Drawing.Size(300, 74);
            this.btnDiff.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDiff.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnDiff.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnDiff.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDiff.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDiff.StateCommon.Border.Rounding = 6;
            this.btnDiff.StateCommon.Border.Width = 2;
            this.btnDiff.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiff.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnDiff.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDiff.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDiff.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnDiff.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnDiff.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiff.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDiff.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnDiff.TabIndex = 0;
            this.btnDiff.ToolTipValues.EnableToolTips = true;
            this.btnDiff.ToolTipValues.Heading = "Diff Options:";
            this.btnDiff.ToolTipValues.Image = global::Elucidate.Properties.Resources.cam_48;
            this.btnDiff.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnDiff.Click += new System.EventHandler(this.Diff_Click);
            // 
            // btnFix
            // 
            this.btnFix.CommandLinkImageValue.Image = global::Elucidate.Properties.Resources.camera_48;
            this.btnFix.CommandLinkTextValues.Description = "Fix errors set by the scrub command.\r\n(Default to using \"-e\") ";
            this.btnFix.CommandLinkTextValues.Heading = "Fi&x";
            this.btnFix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFix.Enabled = false;
            this.btnFix.Location = new System.Drawing.Point(615, 83);
            this.btnFix.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(301, 74);
            this.btnFix.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFix.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnFix.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnFix.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFix.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFix.StateCommon.Border.Rounding = 6;
            this.btnFix.StateCommon.Border.Width = 2;
            this.btnFix.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFix.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnFix.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnFix.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnFix.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnFix.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnFix.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFix.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnFix.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnFix.TabIndex = 7;
            this.btnFix.ToolTipValues.EnableToolTips = true;
            this.btnFix.ToolTipValues.Heading = "Fix Options:";
            this.btnFix.ToolTipValues.Image = global::Elucidate.Properties.Resources.camera_48;
            this.btnFix.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnFix.Click += new System.EventHandler(this.Fix_Click);
            // 
            // btnForceFullSync
            // 
            this.btnForceFullSync.CommandLinkImageValue.Image = global::Elucidate.Properties.Resources.camera_add_48;
            this.btnForceFullSync.CommandLinkTextValues.Description = "Sync with \"-F\" option,\r\nto recompute the full parity";
            this.btnForceFullSync.CommandLinkTextValues.Heading = "Force Full S&ync";
            this.btnForceFullSync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnForceFullSync.Enabled = false;
            this.btnForceFullSync.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnForceFullSync.Location = new System.Drawing.Point(309, 163);
            this.btnForceFullSync.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnForceFullSync.Name = "btnForceFullSync";
            this.btnForceFullSync.Size = new System.Drawing.Size(300, 74);
            this.btnForceFullSync.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnForceFullSync.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnForceFullSync.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnForceFullSync.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnForceFullSync.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnForceFullSync.StateCommon.Border.Rounding = 6;
            this.btnForceFullSync.StateCommon.Border.Width = 2;
            this.btnForceFullSync.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForceFullSync.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnForceFullSync.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnForceFullSync.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnForceFullSync.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnForceFullSync.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnForceFullSync.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForceFullSync.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnForceFullSync.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnForceFullSync.TabIndex = 5;
            this.btnForceFullSync.ToolTipValues.EnableToolTips = true;
            this.btnForceFullSync.ToolTipValues.Heading = "Full Sync Options:";
            this.btnForceFullSync.ToolTipValues.Image = global::Elucidate.Properties.Resources.camera_add_48;
            this.btnForceFullSync.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnForceFullSync.Click += new System.EventHandler(this.ForceFullSync_Click);
            // 
            // btnScrub
            // 
            this.btnScrub.CommandLinkImageValue.Image = global::Elucidate.Properties.Resources.cam_48;
            this.btnScrub.CommandLinkTextValues.Description = "Scrubs the array, checking for silent\r\nand IO errors (default -p100 -o0)";
            this.btnScrub.CommandLinkTextValues.Heading = "Scr&ub";
            this.btnScrub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnScrub.Enabled = false;
            this.btnScrub.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnScrub.Location = new System.Drawing.Point(309, 3);
            this.btnScrub.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnScrub.Name = "btnScrub";
            this.btnScrub.Size = new System.Drawing.Size(300, 74);
            this.btnScrub.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnScrub.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnScrub.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnScrub.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnScrub.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnScrub.StateCommon.Border.Rounding = 6;
            this.btnScrub.StateCommon.Border.Width = 2;
            this.btnScrub.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrub.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnScrub.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnScrub.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnScrub.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnScrub.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnScrub.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrub.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnScrub.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnScrub.TabIndex = 3;
            this.btnScrub.ToolTipValues.EnableToolTips = true;
            this.btnScrub.ToolTipValues.Heading = "Scrub Options:";
            this.btnScrub.ToolTipValues.Image = global::Elucidate.Properties.Resources.cam_48;
            this.btnScrub.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnScrub.Click += new System.EventHandler(this.Scrub_Click);
            // 
            // CommonTab
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "CommonTab";
            this.Size = new System.Drawing.Size(919, 499);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton btnDiff;
        private ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton btnScrub;
        private ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton btnStatus;
        private ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton btnSync;
        private ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton btnCheck;
        private ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton btnFix;
        private ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton btnDupFinder;
        private ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton btnForceFullSync;
        internal Controls.LiveRunLogControl liveRunLogControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
