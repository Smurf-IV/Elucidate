using System.ComponentModel;

namespace Elucidate
{
    partial class CalculateBlockSize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculateBlockSize));
            this.groupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.label2 = new Krypton.Toolkit.KryptonLabel();
            this.numericUpDown1 = new Krypton.Toolkit.KryptonNumericUpDown();
            this.label1 = new Krypton.Toolkit.KryptonLabel();
            this.groupBox2 = new Krypton.Toolkit.KryptonGroupBox();
            this.txtBlockSizeByCoverageMax = new Krypton.Toolkit.KryptonTextBox();
            this.label3 = new Krypton.Toolkit.KryptonLabel();
            this.txtBlockSizeByCoverageMin = new Krypton.Toolkit.KryptonTextBox();
            this.btnCoverage = new Krypton.Toolkit.KryptonButton();
            this.groupBox3 = new Krypton.Toolkit.KryptonGroupBox();
            this.txtBlockSizeByFileCountMax = new Krypton.Toolkit.KryptonTextBox();
            this.lblBadNews = new Krypton.Toolkit.KryptonWrapLabel();
            this.txtBlockSizeByFileCountMin = new Krypton.Toolkit.KryptonTextBox();
            this.btnFileCount = new Krypton.Toolkit.KryptonButton();
            this.richTextBox1 = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1.Panel)).BeginInit();
            this.groupBox1.Panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2.Panel)).BeginInit();
            this.groupBox2.Panel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3.Panel)).BeginInit();
            this.groupBox3.Panel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox1.Name = "groupBox1";
            // 
            // groupBox1.Panel
            // 
            this.groupBox1.Panel.Controls.Add(this.label2);
            this.groupBox1.Panel.Controls.Add(this.numericUpDown1);
            this.groupBox1.Panel.Controls.Add(this.label1);
            this.groupBox1.Size = new System.Drawing.Size(588, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Values.Heading = "Current OS figures:";
            // 
            // label2
            // 
            this.label2.LabelStyle = Krypton.Toolkit.LabelStyle.NormalPanel;
            this.label2.Location = new System.Drawing.Point(181, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(402, 84);
            this.label2.TabIndex = 2;
            this.label2.Values.Text = resources.GetString("label2.Values.Text");
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.AllowDecimals = true;
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(101, 12);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(74, 26);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 44);
            this.label1.StateCommon.ShortText.MultiLine = Krypton.Toolkit.InheritBool.True;
            this.label1.StateCommon.ShortText.MultiLineH = Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.label1.TabIndex = 0;
            this.label1.Values.Text = "&System Memory\r\n(GB):";
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 98);
            this.groupBox2.Name = "groupBox2";
            // 
            // groupBox2.Panel
            // 
            this.groupBox2.Panel.Controls.Add(this.txtBlockSizeByCoverageMax);
            this.groupBox2.Panel.Controls.Add(this.label3);
            this.groupBox2.Panel.Controls.Add(this.txtBlockSizeByCoverageMin);
            this.groupBox2.Panel.Controls.Add(this.btnCoverage);
            this.groupBox2.Size = new System.Drawing.Size(588, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.Values.Heading = "Calculate based on Coverage:";
            // 
            // txtBlockSizeByCoverageMax
            // 
            this.txtBlockSizeByCoverageMax.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBlockSizeByCoverageMax.Location = new System.Drawing.Point(101, 31);
            this.txtBlockSizeByCoverageMax.Name = "txtBlockSizeByCoverageMax";
            this.txtBlockSizeByCoverageMax.ReadOnly = true;
            this.txtBlockSizeByCoverageMax.Size = new System.Drawing.Size(74, 27);
            this.txtBlockSizeByCoverageMax.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.LabelStyle = Krypton.Toolkit.LabelStyle.NormalPanel;
            this.label3.Location = new System.Drawing.Point(181, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(464, 64);
            this.label3.TabIndex = 3;
            this.label3.Values.Text = "SnapRAID requires about TS*28 / BS bytes of RAM memory to run.\r\nWhere TS is the t" +
    "otal size in bytes of your disk array, \r\nand BS is the block size in bytes. ";
            // 
            // txtBlockSizeByCoverageMin
            // 
            this.txtBlockSizeByCoverageMin.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBlockSizeByCoverageMin.Location = new System.Drawing.Point(101, 4);
            this.txtBlockSizeByCoverageMin.Name = "txtBlockSizeByCoverageMin";
            this.txtBlockSizeByCoverageMin.ReadOnly = true;
            this.txtBlockSizeByCoverageMin.Size = new System.Drawing.Size(74, 27);
            this.txtBlockSizeByCoverageMin.TabIndex = 1;
            // 
            // btnCoverage
            // 
            this.btnCoverage.Location = new System.Drawing.Point(1, 3);
            this.btnCoverage.Name = "btnCoverage";
            this.btnCoverage.Size = new System.Drawing.Size(98, 48);
            this.btnCoverage.StateCommon.Content.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnCoverage.TabIndex = 0;
            this.btnCoverage.Values.ExtraText = "&Coverage";
            this.btnCoverage.Values.Text = "Calculate via";
            this.btnCoverage.Click += new System.EventHandler(this.btnCoverage_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 179);
            this.groupBox3.Name = "groupBox3";
            // 
            // groupBox3.Panel
            // 
            this.groupBox3.Panel.Controls.Add(this.txtBlockSizeByFileCountMax);
            this.groupBox3.Panel.Controls.Add(this.lblBadNews);
            this.groupBox3.Panel.Controls.Add(this.txtBlockSizeByFileCountMin);
            this.groupBox3.Panel.Controls.Add(this.btnFileCount);
            this.groupBox3.Size = new System.Drawing.Size(588, 90);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.Values.Heading = "Calculate based on Number Of Files:";
            // 
            // txtBlockSizeByFileCountMax
            // 
            this.txtBlockSizeByFileCountMax.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBlockSizeByFileCountMax.Location = new System.Drawing.Point(101, 30);
            this.txtBlockSizeByFileCountMax.Name = "txtBlockSizeByFileCountMax";
            this.txtBlockSizeByFileCountMax.ReadOnly = true;
            this.txtBlockSizeByFileCountMax.Size = new System.Drawing.Size(74, 27);
            this.txtBlockSizeByFileCountMax.TabIndex = 5;
            // 
            // lblBadNews
            // 
            this.lblBadNews.AutoSize = false;
            this.lblBadNews.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBadNews.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblBadNews.LabelStyle = Krypton.Toolkit.LabelStyle.NormalPanel;
            this.lblBadNews.Location = new System.Drawing.Point(181, 1);
            this.lblBadNews.Name = "lblBadNews";
            this.lblBadNews.Size = new System.Drawing.Size(400, 62);
            this.lblBadNews.Text = resources.GetString("lblBadNews.Text");
            // 
            // txtBlockSizeByFileCountMin
            // 
            this.txtBlockSizeByFileCountMin.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBlockSizeByFileCountMin.Location = new System.Drawing.Point(101, 3);
            this.txtBlockSizeByFileCountMin.Name = "txtBlockSizeByFileCountMin";
            this.txtBlockSizeByFileCountMin.ReadOnly = true;
            this.txtBlockSizeByFileCountMin.Size = new System.Drawing.Size(74, 27);
            this.txtBlockSizeByFileCountMin.TabIndex = 1;
            // 
            // btnFileCount
            // 
            this.btnFileCount.Location = new System.Drawing.Point(3, 2);
            this.btnFileCount.Name = "btnFileCount";
            this.btnFileCount.Size = new System.Drawing.Size(92, 48);
            this.btnFileCount.StateCommon.Content.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.btnFileCount.TabIndex = 0;
            this.btnFileCount.Values.ExtraText = "&File Count";
            this.btnFileCount.Values.Text = "Calculate via";
            this.btnFileCount.Click += new System.EventHandler(this.btnFileCount_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 269);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(588, 222);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.richTextBox1);
            this.kryptonPanel1.Controls.Add(this.groupBox3);
            this.kryptonPanel1.Controls.Add(this.groupBox2);
            this.kryptonPanel1.Controls.Add(this.groupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(588, 491);
            this.kryptonPanel1.TabIndex = 4;
            // 
            // CalculateBlockSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 491);
            this.Controls.Add(this.kryptonPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CalculateBlockSize";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Calculate Block Size";
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1.Panel)).EndInit();
            this.groupBox1.Panel.ResumeLayout(false);
            this.groupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2.Panel)).EndInit();
            this.groupBox2.Panel.ResumeLayout(false);
            this.groupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3.Panel)).EndInit();
            this.groupBox3.Panel.ResumeLayout(false);
            this.groupBox3.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

      }

      #endregion

      private Krypton.Toolkit.KryptonGroupBox groupBox1;
      private Krypton.Toolkit.KryptonNumericUpDown numericUpDown1;
      private Krypton.Toolkit.KryptonLabel label1;
      private Krypton.Toolkit.KryptonLabel label2;
      private Krypton.Toolkit.KryptonGroupBox groupBox2;
      private Krypton.Toolkit.KryptonLabel label3;
      private Krypton.Toolkit.KryptonTextBox txtBlockSizeByCoverageMin;
      private Krypton.Toolkit.KryptonButton btnCoverage;
      private Krypton.Toolkit.KryptonGroupBox groupBox3;
      private Krypton.Toolkit.KryptonTextBox txtBlockSizeByFileCountMin;
      private Krypton.Toolkit.KryptonButton btnFileCount;
      private Krypton.Toolkit.KryptonWrapLabel lblBadNews;
      private Krypton.Toolkit.KryptonRichTextBox richTextBox1;
      private Krypton.Toolkit.KryptonTextBox txtBlockSizeByCoverageMax;
      private Krypton.Toolkit.KryptonTextBox txtBlockSizeByFileCountMax;
        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}