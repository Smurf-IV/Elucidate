namespace Elucidate.TabPages
{
    partial class LogsViewerControl
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
            this.panelLogViewer = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxLogType = new System.Windows.Forms.ComboBox();
            this.listBoxViewLogFiles = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkedFilesWithWarn = new System.Windows.Forms.CheckBox();
            this.checkedFilesWithError = new System.Windows.Forms.CheckBox();
            this.scintilla = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLogViewer
            // 
            this.panelLogViewer.AutoSize = true;
            this.panelLogViewer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLogViewer.Location = new System.Drawing.Point(0, 0);
            this.panelLogViewer.Margin = new System.Windows.Forms.Padding(2);
            this.panelLogViewer.Name = "panelLogViewer";
            this.panelLogViewer.Size = new System.Drawing.Size(0, 0);
            this.panelLogViewer.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.scintilla);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel2MinSize = 400;
            this.splitContainer1.Size = new System.Drawing.Size(765, 400);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.comboBoxLogType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxViewLogFiles, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 400);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // comboBoxLogType
            // 
            this.comboBoxLogType.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxLogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLogType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxLogType.FormattingEnabled = true;
            this.comboBoxLogType.Location = new System.Drawing.Point(3, 3);
            this.comboBoxLogType.Name = "comboBoxLogType";
            this.comboBoxLogType.Size = new System.Drawing.Size(150, 21);
            this.comboBoxLogType.TabIndex = 1;
            this.comboBoxLogType.SelectedIndexChanged += new System.EventHandler(this.comboBoxLogType_SelectedIndexChanged);
            // 
            // listBoxViewLogFiles
            // 
            this.listBoxViewLogFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxViewLogFiles.FormattingEnabled = true;
            this.listBoxViewLogFiles.HorizontalScrollbar = true;
            this.listBoxViewLogFiles.Location = new System.Drawing.Point(2, 65);
            this.listBoxViewLogFiles.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxViewLogFiles.Name = "listBoxViewLogFiles";
            this.listBoxViewLogFiles.Size = new System.Drawing.Size(247, 341);
            this.listBoxViewLogFiles.TabIndex = 8;
            this.listBoxViewLogFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxViewLogFiles_SelectedIndexChanged);
            this.listBoxViewLogFiles.DoubleClick += new System.EventHandler(this.listBoxViewLogFiles_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkedFilesWithWarn);
            this.panel1.Controls.Add(this.checkedFilesWithError);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 32);
            this.panel1.TabIndex = 9;
            // 
            // checkedFilesWithWarn
            // 
            this.checkedFilesWithWarn.AutoSize = true;
            this.checkedFilesWithWarn.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedFilesWithWarn.Location = new System.Drawing.Point(0, 17);
            this.checkedFilesWithWarn.Margin = new System.Windows.Forms.Padding(2);
            this.checkedFilesWithWarn.Name = "checkedFilesWithWarn";
            this.checkedFilesWithWarn.Size = new System.Drawing.Size(247, 17);
            this.checkedFilesWithWarn.TabIndex = 8;
            this.checkedFilesWithWarn.Text = "Logs with Warnings";
            this.checkedFilesWithWarn.UseVisualStyleBackColor = true;
            this.checkedFilesWithWarn.CheckedChanged += new System.EventHandler(this.checkedFilesWithWarn_CheckedChanged);
            // 
            // checkedFilesWithError
            // 
            this.checkedFilesWithError.AutoSize = true;
            this.checkedFilesWithError.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedFilesWithError.Location = new System.Drawing.Point(0, 0);
            this.checkedFilesWithError.Margin = new System.Windows.Forms.Padding(2);
            this.checkedFilesWithError.Name = "checkedFilesWithError";
            this.checkedFilesWithError.Size = new System.Drawing.Size(247, 17);
            this.checkedFilesWithError.TabIndex = 7;
            this.checkedFilesWithError.Text = "Logs with Errors";
            this.checkedFilesWithError.UseVisualStyleBackColor = true;
            this.checkedFilesWithError.CheckedChanged += new System.EventHandler(this.checkedFilesWithError_CheckedChanged);
            // 
            // scintilla
            // 
            this.scintilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla.Location = new System.Drawing.Point(0, 0);
            this.scintilla.Name = "scintilla";
            this.scintilla.Size = new System.Drawing.Size(511, 400);
            this.scintilla.TabIndex = 0;
            // 
            // LogsViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelLogViewer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LogsViewerControl";
            this.Size = new System.Drawing.Size(765, 400);
            this.Load += new System.EventHandler(this.LogsViewerControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLogViewer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBoxLogType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBoxViewLogFiles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkedFilesWithError;
        private System.Windows.Forms.CheckBox checkedFilesWithWarn;
        private System.Windows.Forms.RichTextBox scintilla;
    }
}
