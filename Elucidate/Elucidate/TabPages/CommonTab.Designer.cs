namespace Elucidate.TabPages
{
    internal partial class CommonTab
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
            this.btnCheckForMissing = new ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton();
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
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1113, 403);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnCheckForMissing, 2, 2);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1113, 278);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCheckForMissing
            // 
            this.btnCheckForMissing.CommandLinkImageValue.Image = global::Elucidate.Properties.Resources.database_warning_48;
            this.btnCheckForMissing.CommandLinkTextValues.Description = "Check the snapshot for missing files\r\n(default --filter-mising)";
            this.btnCheckForMissing.CommandLinkTextValues.Heading = "Discover &Missing";
            this.btnCheckForMissing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheckForMissing.Enabled = false;
            this.btnCheckForMissing.Location = new System.Drawing.Point(745, 187);
            this.btnCheckForMissing.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnCheckForMissing.Name = "btnCheckForMissing";
            this.btnCheckForMissing.Size = new System.Drawing.Size(365, 88);
            this.btnCheckForMissing.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCheckForMissing.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnCheckForMissing.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnCheckForMissing.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnCheckForMissing.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCheckForMissing.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCheckForMissing.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnCheckForMissing.StateCommon.Border.Rounding = 6;
            this.btnCheckForMissing.StateCommon.Border.Width = 2;
            this.btnCheckForMissing.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckForMissing.StateCommon.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnCheckForMissing.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnCheckForMissing.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnCheckForMissing.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnCheckForMissing.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnCheckForMissing.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnCheckForMissing.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckForMissing.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnCheckForMissing.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnCheckForMissing.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnCheckForMissing.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btnCheckForMissing.TabIndex = 8;
            this.btnCheckForMissing.ToolTipValues.EnableToolTips = true;
            this.btnCheckForMissing.ToolTipValues.Heading = "Check Options:";
            this.btnCheckForMissing.ToolTipValues.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnCheckForMissing.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnCheckForMissing.ToolTipValues.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.btnCheckForMissing.Click += new System.EventHandler(this.btnCheckForMissing_Click);
            // 
            // btnSync
            // 
            this.btnSync.CommandLinkImageValue.Image = global::Elucidate.Properties.Resources.camera_add_48;
            this.btnSync.CommandLinkTextValues.Description = "Synchronise with any changes that may\r\nhave occurred since the last run.";
            this.btnSync.CommandLinkTextValues.Heading = "&Sync";
            this.btnSync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSync.Enabled = false;
            this.btnSync.Location = new System.Drawing.Point(3, 95);
            this.btnSync.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(365, 86);
            this.btnSync.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSync.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnSync.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnSync.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnSync.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSync.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSync.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnSync.StateCommon.Border.Rounding = 6;
            this.btnSync.StateCommon.Border.Width = 2;
            this.btnSync.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.StateCommon.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnSync.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnSync.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnSync.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnSync.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnSync.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnSync.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnSync.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnSync.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnSync.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btnSync.TabIndex = 1;
            this.btnSync.ToolTipValues.EnableToolTips = true;
            this.btnSync.ToolTipValues.Heading = "Sync Options:";
            this.btnSync.ToolTipValues.Image = global::Elucidate.Properties.Resources.camera_add_48;
            this.btnSync.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnSync.ToolTipValues.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.btnSync.Click += new System.EventHandler(this.Sync_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.CommandLinkImageValue.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnStatus.CommandLinkTextValues.Description = "A summary of the state of the disk\r\narray, upto the last sync time.";
            this.btnStatus.CommandLinkTextValues.Heading = "S&tatus";
            this.btnStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStatus.Enabled = false;
            this.btnStatus.Location = new System.Drawing.Point(745, 3);
            this.btnStatus.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(365, 86);
            this.btnStatus.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnStatus.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnStatus.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnStatus.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnStatus.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnStatus.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnStatus.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnStatus.StateCommon.Border.Rounding = 6;
            this.btnStatus.StateCommon.Border.Width = 2;
            this.btnStatus.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.StateCommon.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnStatus.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnStatus.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnStatus.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnStatus.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnStatus.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnStatus.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnStatus.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnStatus.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnStatus.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btnStatus.TabIndex = 6;
            this.btnStatus.ToolTipValues.EnableToolTips = true;
            this.btnStatus.ToolTipValues.Heading = "Status Options:";
            this.btnStatus.ToolTipValues.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnStatus.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnStatus.ToolTipValues.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
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
            this.btnDupFinder.Location = new System.Drawing.Point(3, 187);
            this.btnDupFinder.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnDupFinder.Name = "btnDupFinder";
            this.btnDupFinder.Size = new System.Drawing.Size(365, 88);
            this.btnDupFinder.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDupFinder.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnDupFinder.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnDupFinder.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnDupFinder.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDupFinder.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDupFinder.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnDupFinder.StateCommon.Border.Rounding = 6;
            this.btnDupFinder.StateCommon.Border.Width = 2;
            this.btnDupFinder.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDupFinder.StateCommon.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnDupFinder.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnDupFinder.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDupFinder.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDupFinder.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnDupFinder.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnDupFinder.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDupFinder.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnDupFinder.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDupFinder.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnDupFinder.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btnDupFinder.TabIndex = 2;
            this.btnDupFinder.ToolTipValues.EnableToolTips = true;
            this.btnDupFinder.ToolTipValues.Heading = "Duplicate Finder Options:";
            this.btnDupFinder.ToolTipValues.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnDupFinder.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Relative;
            this.btnDupFinder.ToolTipValues.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.btnDupFinder.Click += new System.EventHandler(this.DupFinder_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.CommandLinkImageValue.Image = global::Elucidate.Properties.Resources.database_warning_48;
            this.btnCheck.CommandLinkTextValues.Description = "Check the snapshot to confirm\r\nit\'s integrity. (default -a for hash only)";
            this.btnCheck.CommandLinkTextValues.Heading = "&Check";
            this.btnCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheck.Enabled = false;
            this.btnCheck.Location = new System.Drawing.Point(374, 95);
            this.btnCheck.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(365, 86);
            this.btnCheck.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCheck.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnCheck.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnCheck.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnCheck.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCheck.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCheck.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnCheck.StateCommon.Border.Rounding = 6;
            this.btnCheck.StateCommon.Border.Width = 2;
            this.btnCheck.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.StateCommon.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnCheck.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnCheck.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnCheck.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnCheck.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnCheck.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnCheck.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnCheck.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnCheck.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnCheck.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btnCheck.TabIndex = 4;
            this.btnCheck.ToolTipValues.EnableToolTips = true;
            this.btnCheck.ToolTipValues.Heading = "Check Options:";
            this.btnCheck.ToolTipValues.Image = global::Elucidate.Properties.Resources.camera_warning_48;
            this.btnCheck.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnCheck.ToolTipValues.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
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
            this.btnDiff.Size = new System.Drawing.Size(365, 86);
            this.btnDiff.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDiff.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnDiff.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnDiff.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnDiff.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnDiff.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnDiff.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnDiff.StateCommon.Border.Rounding = 6;
            this.btnDiff.StateCommon.Border.Width = 2;
            this.btnDiff.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiff.StateCommon.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnDiff.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnDiff.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDiff.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDiff.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnDiff.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnDiff.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiff.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnDiff.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnDiff.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnDiff.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btnDiff.TabIndex = 0;
            this.btnDiff.ToolTipValues.EnableToolTips = true;
            this.btnDiff.ToolTipValues.Heading = "Diff Options:";
            this.btnDiff.ToolTipValues.Image = global::Elucidate.Properties.Resources.cam_48;
            this.btnDiff.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnDiff.ToolTipValues.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.btnDiff.Click += new System.EventHandler(this.Diff_Click);
            // 
            // btnFix
            // 
            this.btnFix.CommandLinkImageValue.Image = global::Elucidate.Properties.Resources.camera_48;
            this.btnFix.CommandLinkTextValues.Description = "Fix errors set by the scrub command.\r\n(Default to using \"-e\") ";
            this.btnFix.CommandLinkTextValues.Heading = "Fi&x";
            this.btnFix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFix.Enabled = false;
            this.btnFix.Location = new System.Drawing.Point(745, 95);
            this.btnFix.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(365, 86);
            this.btnFix.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFix.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnFix.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnFix.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnFix.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnFix.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnFix.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnFix.StateCommon.Border.Rounding = 6;
            this.btnFix.StateCommon.Border.Width = 2;
            this.btnFix.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFix.StateCommon.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnFix.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnFix.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnFix.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnFix.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnFix.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnFix.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFix.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnFix.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnFix.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnFix.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btnFix.TabIndex = 7;
            this.btnFix.ToolTipValues.EnableToolTips = true;
            this.btnFix.ToolTipValues.Heading = "Fix Options:";
            this.btnFix.ToolTipValues.Image = global::Elucidate.Properties.Resources.camera_48;
            this.btnFix.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnFix.ToolTipValues.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
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
            this.btnForceFullSync.Location = new System.Drawing.Point(374, 187);
            this.btnForceFullSync.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnForceFullSync.Name = "btnForceFullSync";
            this.btnForceFullSync.Size = new System.Drawing.Size(365, 88);
            this.btnForceFullSync.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnForceFullSync.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnForceFullSync.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnForceFullSync.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnForceFullSync.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnForceFullSync.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnForceFullSync.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnForceFullSync.StateCommon.Border.Rounding = 6;
            this.btnForceFullSync.StateCommon.Border.Width = 2;
            this.btnForceFullSync.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForceFullSync.StateCommon.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnForceFullSync.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnForceFullSync.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnForceFullSync.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnForceFullSync.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnForceFullSync.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnForceFullSync.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForceFullSync.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnForceFullSync.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnForceFullSync.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnForceFullSync.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btnForceFullSync.TabIndex = 5;
            this.btnForceFullSync.ToolTipValues.EnableToolTips = true;
            this.btnForceFullSync.ToolTipValues.Heading = "Full Sync Options:";
            this.btnForceFullSync.ToolTipValues.Image = global::Elucidate.Properties.Resources.camera_add_48;
            this.btnForceFullSync.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnForceFullSync.ToolTipValues.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
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
            this.btnScrub.Location = new System.Drawing.Point(374, 3);
            this.btnScrub.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnScrub.Name = "btnScrub";
            this.btnScrub.Size = new System.Drawing.Size(365, 86);
            this.btnScrub.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnScrub.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnScrub.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.btnScrub.StateCommon.Border.Draw = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnScrub.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnScrub.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnScrub.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnScrub.StateCommon.Border.Rounding = 6;
            this.btnScrub.StateCommon.Border.Width = 2;
            this.btnScrub.StateCommon.Content.LongText.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrub.StateCommon.Content.LongText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnScrub.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnScrub.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnScrub.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnScrub.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnScrub.StateCommon.Content.LongText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnScrub.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScrub.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.btnScrub.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnScrub.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnScrub.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.btnScrub.TabIndex = 3;
            this.btnScrub.ToolTipValues.EnableToolTips = true;
            this.btnScrub.ToolTipValues.Heading = "Scrub Options:";
            this.btnScrub.ToolTipValues.Image = global::Elucidate.Properties.Resources.cam_48;
            this.btnScrub.ToolTipValues.ToolTipPosition.PlacementMode = ComponentFactory.Krypton.Toolkit.PlacementMode.Right;
            this.btnScrub.ToolTipValues.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.btnScrub.Click += new System.EventHandler(this.Scrub_Click);
            // 
            // CommonTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.kryptonPanel1);
            this.DoubleBuffered = true;
            this.Name = "CommonTab";
            this.Size = new System.Drawing.Size(1113, 403);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ExtendedControls.ExtendedToolkit.Controls.KryptonCommandLinkButton btnCheckForMissing;
    }
}
