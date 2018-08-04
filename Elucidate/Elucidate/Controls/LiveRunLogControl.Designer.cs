using System.Windows.Forms;

namespace Elucidate.Controls
{
    partial class LiveRunLogControl
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.toolStripStatusLabel1 = new System.Windows.Forms.Label();
            this.runWithoutCaptureMenuItem = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtAddCommands = new System.Windows.Forms.TextBox();
            this.labelCommandLineOptions = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxLiveLog = new Elucidate.Shared.FlickerFreeRichEditTextBox();
            this.toolStripProgressBar1 = new Elucidate.Shared.TextOverProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.toolStripProgressBar1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStripStatusLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.runWithoutCaptureMenuItem, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 385);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(871, 27);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Items.AddRange(new object[] {
            "Stopped",
            "Running",
            "Abort",
            "Idle"});
            this.comboBox1.Location = new System.Drawing.Point(139, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(113, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = true;
            this.toolStripStatusLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Location = new System.Drawing.Point(0, 0);
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel1.MinimumSize = new System.Drawing.Size(132, 28);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(136, 28);
            this.toolStripStatusLabel1.TabIndex = 1;
            this.toolStripStatusLabel1.Text = "2011-06-012T18:54:54";
            // 
            // runWithoutCaptureMenuItem
            // 
            this.runWithoutCaptureMenuItem.AutoSize = true;
            this.runWithoutCaptureMenuItem.Location = new System.Drawing.Point(258, 3);
            this.runWithoutCaptureMenuItem.Name = "runWithoutCaptureMenuItem";
            this.runWithoutCaptureMenuItem.Size = new System.Drawing.Size(122, 17);
            this.runWithoutCaptureMenuItem.TabIndex = 4;
            this.runWithoutCaptureMenuItem.Text = "Run without capture";
            this.runWithoutCaptureMenuItem.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.txtAddCommands, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelCommandLineOptions, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 361);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(12);
            this.tableLayoutPanel2.MinimumSize = new System.Drawing.Size(50, 10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(871, 24);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // txtAddCommands
            // 
            this.txtAddCommands.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddCommands.Location = new System.Drawing.Point(200, 2);
            this.txtAddCommands.Margin = new System.Windows.Forms.Padding(1);
            this.txtAddCommands.MaxLength = 128;
            this.txtAddCommands.Name = "txtAddCommands";
            this.txtAddCommands.Size = new System.Drawing.Size(669, 13);
            this.txtAddCommands.TabIndex = 6;
            this.txtAddCommands.WordWrap = false;
            // 
            // labelCommandLineOptions
            // 
            this.labelCommandLineOptions.AutoSize = true;
            this.labelCommandLineOptions.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelCommandLineOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommandLineOptions.Location = new System.Drawing.Point(4, 1);
            this.labelCommandLineOptions.MinimumSize = new System.Drawing.Size(170, 10);
            this.labelCommandLineOptions.Name = "labelCommandLineOptions";
            this.labelCommandLineOptions.Size = new System.Drawing.Size(191, 22);
            this.labelCommandLineOptions.TabIndex = 5;
            this.labelCommandLineOptions.Text = "&Additional Command line options:";
            this.labelCommandLineOptions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // textBoxLiveLog
            // 
            this.textBoxLiveLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxLiveLog.CausesValidation = false;
            this.textBoxLiveLog.DetectUrls = false;
            this.textBoxLiveLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLiveLog.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLiveLog.Location = new System.Drawing.Point(0, 0);
            this.textBoxLiveLog.MaxLength = 10000000;
            this.textBoxLiveLog.Name = "textBoxLiveLog";
            this.textBoxLiveLog.ReadOnly = true;
            this.textBoxLiveLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.textBoxLiveLog.Size = new System.Drawing.Size(871, 361);
            this.textBoxLiveLog.TabIndex = 2;
            this.textBoxLiveLog.Text = "";
            this.textBoxLiveLog.WordWrap = false;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.ContainerControl = this;
            this.toolStripProgressBar1.DisplayText = "";
            this.toolStripProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripProgressBar1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.toolStripProgressBar1.Location = new System.Drawing.Point(383, 0);
            this.toolStripProgressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.ShowInTaskbar = true;
            this.toolStripProgressBar1.Size = new System.Drawing.Size(488, 27);
            this.toolStripProgressBar1.Step = 3;
            this.toolStripProgressBar1.TabIndex = 5;
            this.toolStripProgressBar1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // LiveRunLogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxLiveLog);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LiveRunLogControl";
            this.Size = new System.Drawing.Size(871, 412);
            this.Load += new System.EventHandler(this.LiveRunLogControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelCommandLineOptions;
        private System.Windows.Forms.TextBox txtAddCommands;
        private System.Windows.Forms.Label toolStripStatusLabel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private Shared.TextOverProgressBar toolStripProgressBar1;
        private System.Windows.Forms.CheckBox runWithoutCaptureMenuItem;
        private Shared.FlickerFreeRichEditTextBox textBoxLiveLog;
        private Timer timer1;
    }
}
