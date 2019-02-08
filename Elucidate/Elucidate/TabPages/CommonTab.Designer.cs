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
            this.liveRunLogControl1 = new Elucidate.Controls.LiveRunLogControl();
            this.commandPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDiff = new Elucidate.Shared.CommandLinkButton();
            this.btnScrub = new Elucidate.Shared.CommandLinkButton();
            this.btnStatus = new Elucidate.Shared.CommandLinkButton();
            this.btnSync = new Elucidate.Shared.CommandLinkButton();
            this.btnCheck = new Elucidate.Shared.CommandLinkButton();
            this.btnFix = new Elucidate.Shared.CommandLinkButton();
            this.btnDupFinder = new Elucidate.Shared.CommandLinkButton();
            this.btnForceFullSync = new Elucidate.Shared.CommandLinkButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.commandPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.liveRunLogControl1);
            this.kryptonPanel1.Controls.Add(this.commandPanel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(919, 499);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // liveRunLogControl1
            // 
            this.liveRunLogControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liveRunLogControl1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liveRunLogControl1.IsRunning = false;
            this.liveRunLogControl1.Location = new System.Drawing.Point(0, 210);
            this.liveRunLogControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.liveRunLogControl1.Name = "liveRunLogControl1";
            this.liveRunLogControl1.Size = new System.Drawing.Size(919, 289);
            this.liveRunLogControl1.TabIndex = 11;
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
            this.commandPanel.Controls.Add(this.btnForceFullSync);
            this.commandPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.commandPanel.Location = new System.Drawing.Point(0, 0);
            this.commandPanel.Name = "commandPanel";
            this.commandPanel.Size = new System.Drawing.Size(919, 210);
            this.commandPanel.TabIndex = 10;
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
            this.btnDiff.Subscript = "Lists all the files have been modified\r\nsince the last \"sync\" command.";
            this.btnDiff.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiff.TabIndex = 3;
            this.btnDiff.Text = "Differences";
            this.btnDiff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiff.UseVisualStyleBackColor = true;
            this.btnDiff.Click += new System.EventHandler(this.Diff_Click);
            // 
            // btnScrub
            // 
            this.btnScrub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScrub.ButtonDepress = ((sbyte)(2));
            this.btnScrub.Enabled = false;
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
            this.btnScrub.Text = "Scrub";
            this.btnScrub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnScrub.UseVisualStyleBackColor = true;
            this.btnScrub.Click += new System.EventHandler(this.Scrub_Click);
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
            this.btnStatus.Subscript = "A summary of the state of the disk\r\narray, upto the last sync time.";
            this.btnStatus.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.TabIndex = 7;
            this.btnStatus.Text = "Status";
            this.btnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnSync.Location = new System.Drawing.Point(3, 73);
            this.btnSync.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnSync.Name = "btnSync";
            this.btnSync.Rounding = 14F;
            this.btnSync.Size = new System.Drawing.Size(300, 64);
            this.btnSync.Subscript = "Synchronise with any changes that may\r\nhave occurred since the last run.";
            this.btnSync.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync.TabIndex = 1;
            this.btnSync.Text = "Sync";
            this.btnSync.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.Sync_Click);
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
            this.btnCheck.Text = "Check";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.Check_Click);
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
            this.btnFix.Text = "Fix";
            this.btnFix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.Fix_Click);
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
            this.btnDupFinder.Subscript = "Lists all the duplicate files. Two files are\r\nassumed equal if their hashes match" +
    ". ";
            this.btnDupFinder.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDupFinder.TabIndex = 10;
            this.btnDupFinder.Text = "Duplicate Finder";
            this.btnDupFinder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDupFinder.UseVisualStyleBackColor = true;
            this.btnDupFinder.Click += new System.EventHandler(this.DupFinder_Click);
            // 
            // btnForceFullSync
            // 
            this.btnForceFullSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForceFullSync.ButtonDepress = ((sbyte)(2));
            this.btnForceFullSync.Enabled = false;
            this.btnForceFullSync.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnForceFullSync.HighlightColor = System.Drawing.SystemColors.Highlight;
            this.btnForceFullSync.HighlightFillAlpha = ((byte)(200));
            this.btnForceFullSync.HighlightFillAlphaMouse = ((byte)(100));
            this.btnForceFullSync.HighlightFillAlphaNormal = ((byte)(50));
            this.btnForceFullSync.HighlightWidth = 2F;
            this.btnForceFullSync.Image = global::Elucidate.Properties.Resources.camera_add_48;
            this.btnForceFullSync.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnForceFullSync.ImageMargin = 8F;
            this.btnForceFullSync.Location = new System.Drawing.Point(309, 143);
            this.btnForceFullSync.MinimumSize = new System.Drawing.Size(300, 64);
            this.btnForceFullSync.Name = "btnForceFullSync";
            this.btnForceFullSync.Rounding = 14F;
            this.btnForceFullSync.Size = new System.Drawing.Size(300, 64);
            this.btnForceFullSync.Subscript = "sync with \"-F\" option";
            this.btnForceFullSync.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForceFullSync.TabIndex = 12;
            this.btnForceFullSync.Text = "Force Full Sync";
            this.btnForceFullSync.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnForceFullSync.UseVisualStyleBackColor = true;
            this.btnForceFullSync.Click += new System.EventHandler(this.ForceFullSync_Click);
            // 
            // CommonTab
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "CommonTab";
            this.Size = new System.Drawing.Size(919, 499);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.commandPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.FlowLayoutPanel commandPanel;
        private Shared.CommandLinkButton btnDiff;
        private Shared.CommandLinkButton btnScrub;
        private Shared.CommandLinkButton btnStatus;
        private Shared.CommandLinkButton btnSync;
        private Shared.CommandLinkButton btnCheck;
        private Shared.CommandLinkButton btnFix;
        private Shared.CommandLinkButton btnDupFinder;
        private Shared.CommandLinkButton btnForceFullSync;
        internal Controls.LiveRunLogControl liveRunLogControl1;
    }
}
