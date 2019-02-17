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
            this.toolStripStatusLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.toolStripProgressBar1 = new Elucidate.Shared.TextOverProgressBar();
            this.runWithoutCaptureMenuItem = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.checkBoxDisplayOutput = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.comboBoxProcessStatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.rtbLiveLog = new System.Windows.Forms.ListBox();
            this.txtAddCommands = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tableLayoutPanelAdditionalCommands = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxCommandLineOptions = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxProcessStatus)).BeginInit();
            this.tableLayoutPanelAdditionalCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStripStatusLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStripProgressBar1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.runWithoutCaptureMenuItem, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxDisplayOutput, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxProcessStatus, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 286);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(858, 30);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripStatusLabel1.Location = new System.Drawing.Point(0, 4);
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.toolStripStatusLabel1.MinimumSize = new System.Drawing.Size(170, 22);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(170, 26);
            this.toolStripStatusLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.toolStripStatusLabel1.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.toolStripStatusLabel1.TabIndex = 7;
            this.toolStripStatusLabel1.Values.Text = "2000-01-01 00:00:00Z";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.ContainerControl = this;
            this.toolStripProgressBar1.DisplayText = "";
            this.toolStripProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripProgressBar1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.toolStripProgressBar1.Location = new System.Drawing.Point(602, 0);
            this.toolStripProgressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.ShowInTaskbar = true;
            this.toolStripProgressBar1.Size = new System.Drawing.Size(256, 30);
            this.toolStripProgressBar1.Step = 3;
            this.toolStripProgressBar1.TabIndex = 5;
            this.toolStripProgressBar1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // runWithoutCaptureMenuItem
            // 
            this.runWithoutCaptureMenuItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runWithoutCaptureMenuItem.Location = new System.Drawing.Point(435, 0);
            this.runWithoutCaptureMenuItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.runWithoutCaptureMenuItem.MinimumSize = new System.Drawing.Size(122, 22);
            this.runWithoutCaptureMenuItem.Name = "runWithoutCaptureMenuItem";
            this.runWithoutCaptureMenuItem.Size = new System.Drawing.Size(163, 30);
            this.runWithoutCaptureMenuItem.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runWithoutCaptureMenuItem.TabIndex = 4;
            this.runWithoutCaptureMenuItem.Values.Text = "Run without capture";
            this.runWithoutCaptureMenuItem.Visible = false;
            // 
            // checkBoxDisplayOutput
            // 
            this.checkBoxDisplayOutput.Checked = true;
            this.checkBoxDisplayOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisplayOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxDisplayOutput.Location = new System.Drawing.Point(302, 0);
            this.checkBoxDisplayOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.checkBoxDisplayOutput.MinimumSize = new System.Drawing.Size(86, 22);
            this.checkBoxDisplayOutput.Name = "checkBoxDisplayOutput";
            this.checkBoxDisplayOutput.Size = new System.Drawing.Size(125, 30);
            this.checkBoxDisplayOutput.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDisplayOutput.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.checkBoxDisplayOutput.TabIndex = 6;
            this.checkBoxDisplayOutput.Values.Text = "Display Output";
            this.checkBoxDisplayOutput.MouseLeave += new System.EventHandler(this.checkBoxDisplayOutput_MouseLeave);
            this.checkBoxDisplayOutput.MouseHover += new System.EventHandler(this.checkBoxDisplayOutput_MouseHover);
            // 
            // comboBoxProcessStatus
            // 
            this.comboBoxProcessStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxProcessStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProcessStatus.DropDownWidth = 120;
            this.comboBoxProcessStatus.FormattingEnabled = true;
            this.comboBoxProcessStatus.Items.AddRange(new object[] {
            "Stopped",
            "Running",
            "Abort"});
            this.comboBoxProcessStatus.Location = new System.Drawing.Point(174, 3);
            this.comboBoxProcessStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxProcessStatus.Name = "comboBoxProcessStatus";
            this.comboBoxProcessStatus.Size = new System.Drawing.Size(120, 24);
            this.comboBoxProcessStatus.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProcessStatus.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProcessStatus.TabIndex = 3;
            this.comboBoxProcessStatus.Text = "Stopped";
            this.comboBoxProcessStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxProcessStatus_SelectedIndexChanged);
            // 
            // rtbLiveLog
            // 
            this.rtbLiveLog.BackColor = System.Drawing.SystemColors.Control;
            this.rtbLiveLog.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtbLiveLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLiveLog.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.rtbLiveLog.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLiveLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLiveLog.Margin = new System.Windows.Forms.Padding(4);
            this.rtbLiveLog.Name = "rtbLiveLog";
            this.rtbLiveLog.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.rtbLiveLog.Size = new System.Drawing.Size(858, 254);
            this.rtbLiveLog.TabIndex = 3;
            this.toolTip1.SetToolTip(this.rtbLiveLog, "Ctrl+A - selects all text\r\nCtrl+C - Copy to clipboard\r\n");
            // 
            // txtAddCommands
            // 
            this.txtAddCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddCommands.Location = new System.Drawing.Point(350, 6);
            this.txtAddCommands.Margin = new System.Windows.Forms.Padding(2, 5, 5, 1);
            this.txtAddCommands.MaxLength = 128;
            this.txtAddCommands.Name = "txtAddCommands";
            this.txtAddCommands.Size = new System.Drawing.Size(502, 19);
            this.txtAddCommands.StateCommon.Content.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddCommands.TabIndex = 6;
            this.txtAddCommands.WordWrap = false;
            // 
            // tableLayoutPanelAdditionalCommands
            // 
            this.tableLayoutPanelAdditionalCommands.AutoSize = true;
            this.tableLayoutPanelAdditionalCommands.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelAdditionalCommands.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelAdditionalCommands.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelAdditionalCommands.ColumnCount = 2;
            this.tableLayoutPanelAdditionalCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 346F));
            this.tableLayoutPanelAdditionalCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAdditionalCommands.Controls.Add(this.txtAddCommands, 1, 0);
            this.tableLayoutPanelAdditionalCommands.Controls.Add(this.checkBoxCommandLineOptions, 0, 0);
            this.tableLayoutPanelAdditionalCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanelAdditionalCommands.Location = new System.Drawing.Point(0, 254);
            this.tableLayoutPanelAdditionalCommands.Margin = new System.Windows.Forms.Padding(18);
            this.tableLayoutPanelAdditionalCommands.MinimumSize = new System.Drawing.Size(75, 15);
            this.tableLayoutPanelAdditionalCommands.Name = "tableLayoutPanelAdditionalCommands";
            this.tableLayoutPanelAdditionalCommands.RowCount = 1;
            this.tableLayoutPanelAdditionalCommands.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelAdditionalCommands.Size = new System.Drawing.Size(858, 32);
            this.tableLayoutPanelAdditionalCommands.TabIndex = 1;
            // 
            // checkBoxCommandLineOptions
            // 
            this.checkBoxCommandLineOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxCommandLineOptions.Location = new System.Drawing.Point(5, 5);
            this.checkBoxCommandLineOptions.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCommandLineOptions.Name = "checkBoxCommandLineOptions";
            this.checkBoxCommandLineOptions.Size = new System.Drawing.Size(338, 22);
            this.checkBoxCommandLineOptions.StateCommon.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCommandLineOptions.TabIndex = 7;
            this.checkBoxCommandLineOptions.Values.Text = "Include Additional Command Line Options:";
            this.checkBoxCommandLineOptions.CheckedChanged += new System.EventHandler(this.checkBoxCommandLineOptions_CheckedChanged);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.rtbLiveLog);
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanelAdditionalCommands);
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(858, 316);
            this.kryptonPanel1.TabIndex = 4;
            // 
            // LiveRunLogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LiveRunLogControl";
            this.Size = new System.Drawing.Size(858, 316);
            this.Load += new System.EventHandler(this.LiveRunLogControl_Load);
            this.Resize += new System.EventHandler(this.LiveRunLogControl_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxProcessStatus)).EndInit();
            this.tableLayoutPanelAdditionalCommands.ResumeLayout(false);
            this.tableLayoutPanelAdditionalCommands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox comboBoxProcessStatus;
        private Shared.TextOverProgressBar toolStripProgressBar1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox runWithoutCaptureMenuItem;
        private ListBox rtbLiveLog;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel toolStripStatusLabel1;
        private TableLayoutPanel tableLayoutPanelAdditionalCommands;
        internal ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAddCommands;
        internal ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkBoxCommandLineOptions;
        internal ComponentFactory.Krypton.Toolkit.KryptonCheckBox checkBoxDisplayOutput;
        private ToolTip toolTip1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}
