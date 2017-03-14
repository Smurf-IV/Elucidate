using System.ComponentModel;
using System.Windows.Forms;
using Shared;

namespace Elucidate
{
   partial class MiscTab
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.panel1 = new System.Windows.Forms.Panel();
         this.txtAddCommands = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.btnScrub = new Shared.CommandLinkButton();
         this.btnDupFinder = new Shared.CommandLinkButton();
         this.btnFix = new Shared.CommandLinkButton();
         this.btnUndelete = new Shared.CommandLinkButton();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
         this.panel1.Controls.Add(this.txtAddCommands);
         this.panel1.Location = new System.Drawing.Point(206, 397);
         this.panel1.Name = "panel1";
         this.panel1.Padding = new System.Windows.Forms.Padding(2);
         this.panel1.Size = new System.Drawing.Size(455, 19);
         this.panel1.TabIndex = 12;
         // 
         // txtAddCommands
         // 
         this.txtAddCommands.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.txtAddCommands.Dock = System.Windows.Forms.DockStyle.Fill;
         this.txtAddCommands.Location = new System.Drawing.Point(2, 2);
         this.txtAddCommands.Margin = new System.Windows.Forms.Padding(1);
         this.txtAddCommands.MaxLength = 128;
         this.txtAddCommands.Name = "txtAddCommands";
         this.txtAddCommands.Size = new System.Drawing.Size(451, 14);
         this.txtAddCommands.TabIndex = 5;
         this.txtAddCommands.WordWrap = false;
         // 
         // label2
         // 
         this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(17, 400);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(165, 13);
         this.label2.TabIndex = 11;
         this.label2.Text = "&Additional Command line options:";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // btnScrub
         // 
         this.btnScrub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
         this.btnScrub.Location = new System.Drawing.Point(6, 11);
         this.btnScrub.Name = "btnScrub";
         this.btnScrub.Rounding = 14F;
         this.btnScrub.Size = new System.Drawing.Size(650, 74);
         this.btnScrub.Subscript = "    Oldest first block check. Defaults to 100% (-p100) of all of blocks ( older t" +
    "han 0 days = -o0)";
         this.btnScrub.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnScrub.TabIndex = 10;
         this.btnScrub.Text = "&Scrub";
         this.btnScrub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.toolTip1.SetToolTip(this.btnScrub, "Blocks already marked as bad are always checked.\r\nUse \"Additional Command\" to ove" +
        "rride the default of 100% of 0 days");
         this.btnScrub.UseVisualStyleBackColor = true;
         this.btnScrub.Click += new System.EventHandler(this.btnScrub_Click);
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
         this.btnDupFinder.Location = new System.Drawing.Point(6, 189);
         this.btnDupFinder.Name = "btnDupFinder";
         this.btnDupFinder.Rounding = 14F;
         this.btnDupFinder.Size = new System.Drawing.Size(650, 74);
         this.btnDupFinder.Subscript = "    Lists all the duplicate files. Two files are assumed equal if their hashes ar" +
    "e matching. ";
         this.btnDupFinder.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnDupFinder.TabIndex = 9;
         this.btnDupFinder.Text = "&Duplicate Finder";
         this.btnDupFinder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.toolTip1.SetToolTip(this.btnDupFinder, "The file data is not read, but only the precomputed hashes are used.\r\nNothing is " +
        "modified\r\n");
         this.btnDupFinder.UseVisualStyleBackColor = true;
         this.btnDupFinder.Click += new System.EventHandler(this.btnDupFinder_Click);
         // 
         // btnFix
         // 
         this.btnFix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.btnFix.ButtonDepress = ((sbyte)(2));
         this.btnFix.Enabled = false;
         this.btnFix.ForeColor = System.Drawing.SystemColors.ControlText;
         this.btnFix.HighlightColor = System.Drawing.SystemColors.Highlight;
         this.btnFix.HighlightFillAlpha = ((byte)(200));
         this.btnFix.HighlightFillAlphaMouse = ((byte)(100));
         this.btnFix.HighlightFillAlphaNormal = ((byte)(50));
         this.btnFix.HighlightWidth = 2F;
         this.btnFix.Image = global::Elucidate.Properties.Resources.camera_add_48;
         this.btnFix.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnFix.ImageMargin = 8F;
         this.btnFix.Location = new System.Drawing.Point(6, 100);
         this.btnFix.Name = "btnFix";
         this.btnFix.Rounding = 14F;
         this.btnFix.Size = new System.Drawing.Size(650, 74);
         this.btnFix.Subscript = "    Will default to using \"-e\", fix errors set by the scrub command. ";
         this.btnFix.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnFix.TabIndex = 8;
         this.btnFix.Text = "&Fix";
         this.btnFix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.toolTip1.SetToolTip(this.btnFix, "Override with the \"Additional Command\" options, e.g.\r\nRecover all the deleted fil" +
        "es in all drives with \"-m\" \r\n");
         this.btnFix.UseVisualStyleBackColor = true;
         this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
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
         this.btnUndelete.Location = new System.Drawing.Point(6, 276);
         this.btnUndelete.Name = "btnUndelete";
         this.btnUndelete.Rounding = 14F;
         this.btnUndelete.Size = new System.Drawing.Size(650, 74);
         this.btnUndelete.Subscript = "    Recover all the deleted files in all the drives since last \"Sync\"";
         this.btnUndelete.SubscriptFont = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnUndelete.TabIndex = 13;
         this.btnUndelete.Text = "&Undelete";
         this.btnUndelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.btnUndelete.UseVisualStyleBackColor = true;
         this.btnUndelete.Click += new System.EventHandler(this.btnUndelete_Click);
         // 
         // MiscTab
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.btnUndelete);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.btnScrub);
         this.Controls.Add(this.btnDupFinder);
         this.Controls.Add(this.btnFix);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "MiscTab";
         this.Size = new System.Drawing.Size(666, 428);
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private CommandLinkButton btnUndelete;
      private Panel panel1;
      private TextBox txtAddCommands;
      private Label label2;
      private CommandLinkButton btnScrub;
      private CommandLinkButton btnDupFinder;
      private CommandLinkButton btnFix;
      private ToolTip toolTip1;
   }
}
