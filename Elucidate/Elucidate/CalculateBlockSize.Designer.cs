using System.ComponentModel;
using System.Windows.Forms;

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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label2 = new System.Windows.Forms.Label();
         this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.label3 = new System.Windows.Forms.Label();
         this.txtCoverageMin = new System.Windows.Forms.TextBox();
         this.btnCoverage = new System.Windows.Forms.Button();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.lblBadNews = new System.Windows.Forms.Label();
         this.txtFileCountMin = new System.Windows.Forms.TextBox();
         this.btnFileCount = new System.Windows.Forms.Button();
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.txtCoverageMax = new System.Windows.Forms.TextBox();
         this.txtFileCountMax = new System.Windows.Forms.TextBox();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.numericUpDown1);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(13, 13);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(563, 81);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Current OS figures:";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(181, 16);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(376, 62);
         this.label2.TabIndex = 2;
         this.label2.Text = resources.GetString("label2.Text");
         // 
         // numericUpDown1
         // 
         this.numericUpDown1.DecimalPlaces = 1;
         this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
         this.numericUpDown1.Location = new System.Drawing.Point(121, 18);
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
         this.numericUpDown1.Size = new System.Drawing.Size(54, 21);
         this.numericUpDown1.TabIndex = 1;
         this.numericUpDown1.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(7, 20);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(111, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "&System Memory (GB):";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.txtCoverageMax);
         this.groupBox2.Controls.Add(this.label3);
         this.groupBox2.Controls.Add(this.txtCoverageMin);
         this.groupBox2.Controls.Add(this.btnCoverage);
         this.groupBox2.Location = new System.Drawing.Point(13, 105);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(563, 81);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Calculate based on Coverage:";
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(181, 13);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(376, 65);
         this.label3.TabIndex = 3;
         this.label3.Text = "SnapRAID requires about TS*28 / BS bytes of RAM memory to run.\r\nWhere TS is the t" +
    "otal size in bytes of your disk array, \r\nand BS is the block size in bytes. ";
         // 
         // txtCoverageMin
         // 
         this.txtCoverageMin.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.txtCoverageMin.Location = new System.Drawing.Point(101, 22);
         this.txtCoverageMin.Name = "txtCoverageMin";
         this.txtCoverageMin.ReadOnly = true;
         this.txtCoverageMin.Size = new System.Drawing.Size(74, 21);
         this.txtCoverageMin.TabIndex = 1;
         // 
         // btnCoverage
         // 
         this.btnCoverage.Location = new System.Drawing.Point(10, 21);
         this.btnCoverage.Name = "btnCoverage";
         this.btnCoverage.Size = new System.Drawing.Size(75, 23);
         this.btnCoverage.TabIndex = 0;
         this.btnCoverage.Text = "&Coverage";
         this.btnCoverage.UseVisualStyleBackColor = true;
         this.btnCoverage.Click += new System.EventHandler(this.btnCoverage_Click);
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.txtFileCountMax);
         this.groupBox3.Controls.Add(this.lblBadNews);
         this.groupBox3.Controls.Add(this.txtFileCountMin);
         this.groupBox3.Controls.Add(this.btnFileCount);
         this.groupBox3.Location = new System.Drawing.Point(13, 197);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(563, 81);
         this.groupBox3.TabIndex = 2;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Calculate based on Number Of Files:";
         // 
         // lblBadNews
         // 
         this.lblBadNews.Location = new System.Drawing.Point(181, 16);
         this.lblBadNews.Name = "lblBadNews";
         this.lblBadNews.Size = new System.Drawing.Size(376, 62);
         this.lblBadNews.TabIndex = 4;
         this.lblBadNews.Text = resources.GetString("lblBadNews.Text");
         // 
         // txtFileCountMin
         // 
         this.txtFileCountMin.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.txtFileCountMin.Location = new System.Drawing.Point(101, 22);
         this.txtFileCountMin.Name = "txtFileCountMin";
         this.txtFileCountMin.ReadOnly = true;
         this.txtFileCountMin.Size = new System.Drawing.Size(74, 21);
         this.txtFileCountMin.TabIndex = 1;
         // 
         // btnFileCount
         // 
         this.btnFileCount.Location = new System.Drawing.Point(10, 21);
         this.btnFileCount.Name = "btnFileCount";
         this.btnFileCount.Size = new System.Drawing.Size(75, 23);
         this.btnFileCount.TabIndex = 0;
         this.btnFileCount.Text = "&File Count";
         this.btnFileCount.UseVisualStyleBackColor = true;
         this.btnFileCount.Click += new System.EventHandler(this.btnFileCount_Click);
         // 
         // richTextBox1
         // 
         this.richTextBox1.Location = new System.Drawing.Point(12, 284);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.ReadOnly = true;
         this.richTextBox1.Size = new System.Drawing.Size(564, 148);
         this.richTextBox1.TabIndex = 3;
         this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
         // 
         // txtCoverageMax
         // 
         this.txtCoverageMax.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.txtCoverageMax.Location = new System.Drawing.Point(101, 49);
         this.txtCoverageMax.Name = "txtCoverageMax";
         this.txtCoverageMax.ReadOnly = true;
         this.txtCoverageMax.Size = new System.Drawing.Size(74, 21);
         this.txtCoverageMax.TabIndex = 4;
         // 
         // txtFileCountMax
         // 
         this.txtFileCountMax.BackColor = System.Drawing.SystemColors.ControlLightLight;
         this.txtFileCountMax.Location = new System.Drawing.Point(101, 49);
         this.txtFileCountMax.Name = "txtFileCountMax";
         this.txtFileCountMax.ReadOnly = true;
         this.txtFileCountMax.Size = new System.Drawing.Size(74, 21);
         this.txtFileCountMax.TabIndex = 5;
         // 
         // CalculateBlockSize
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(588, 444);
         this.Controls.Add(this.richTextBox1);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Name = "CalculateBlockSize";
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.Text = "Calculate Block Size";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private GroupBox groupBox1;
      private NumericUpDown numericUpDown1;
      private Label label1;
      private Label label2;
      private GroupBox groupBox2;
      private Label label3;
      private TextBox txtCoverageMin;
      private Button btnCoverage;
      private GroupBox groupBox3;
      private TextBox txtFileCountMin;
      private Button btnFileCount;
      private Label lblBadNews;
      private RichTextBox richTextBox1;
      private TextBox txtCoverageMax;
      private TextBox txtFileCountMax;
   }
}