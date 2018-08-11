namespace Elucidate.Controls
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
            this.checkedListBoxLogFiles = new System.Windows.Forms.CheckedListBox();
            this.comboBoxLogType = new System.Windows.Forms.ComboBox();
            this.listBoxViewLogFiles = new System.Windows.Forms.ListBox();
            this.richTextBoxLogViewer = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLogViewer
            // 
            this.panelLogViewer.AutoSize = true;
            this.panelLogViewer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLogViewer.Location = new System.Drawing.Point(0, 0);
            this.panelLogViewer.Name = "panelLogViewer";
            this.panelLogViewer.Size = new System.Drawing.Size(0, 0);
            this.panelLogViewer.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxLogViewer);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel2MinSize = 400;
            this.splitContainer1.Size = new System.Drawing.Size(1148, 615);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.checkedListBoxLogFiles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxLogType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxViewLogFiles, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 615);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkedListBoxLogFiles
            // 
            this.checkedListBoxLogFiles.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBoxLogFiles.FormattingEnabled = true;
            this.checkedListBoxLogFiles.Location = new System.Drawing.Point(3, 41);
            this.checkedListBoxLogFiles.Name = "checkedListBoxLogFiles";
            this.checkedListBoxLogFiles.Size = new System.Drawing.Size(223, 25);
            this.checkedListBoxLogFiles.TabIndex = 6;
            this.checkedListBoxLogFiles.Visible = false;
            // 
            // comboBoxLogType
            // 
            this.comboBoxLogType.FormattingEnabled = true;
            this.comboBoxLogType.Location = new System.Drawing.Point(4, 5);
            this.comboBoxLogType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxLogType.Name = "comboBoxLogType";
            this.comboBoxLogType.Size = new System.Drawing.Size(223, 28);
            this.comboBoxLogType.TabIndex = 1;
            this.comboBoxLogType.SelectedIndexChanged += new System.EventHandler(this.comboBoxLogType_SelectedIndexChanged);
            // 
            // listBoxViewLogFiles
            // 
            this.listBoxViewLogFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxViewLogFiles.FormattingEnabled = true;
            this.listBoxViewLogFiles.HorizontalScrollbar = true;
            this.listBoxViewLogFiles.ItemHeight = 20;
            this.listBoxViewLogFiles.Location = new System.Drawing.Point(3, 72);
            this.listBoxViewLogFiles.Name = "listBoxViewLogFiles";
            this.listBoxViewLogFiles.Size = new System.Drawing.Size(244, 540);
            this.listBoxViewLogFiles.TabIndex = 8;
            this.listBoxViewLogFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxViewLogFiles_SelectedIndexChanged);
            this.listBoxViewLogFiles.DoubleClick += new System.EventHandler(this.listBoxViewLogFiles_DoubleClick);
            // 
            // richTextBoxLogViewer
            // 
            this.richTextBoxLogViewer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBoxLogViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxLogViewer.CausesValidation = false;
            this.richTextBoxLogViewer.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBoxLogViewer.DetectUrls = false;
            this.richTextBoxLogViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLogViewer.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxLogViewer.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxLogViewer.Name = "richTextBoxLogViewer";
            this.richTextBoxLogViewer.ReadOnly = true;
            this.richTextBoxLogViewer.Size = new System.Drawing.Size(892, 615);
            this.richTextBoxLogViewer.TabIndex = 3;
            this.richTextBoxLogViewer.Text = "";
            this.richTextBoxLogViewer.WordWrap = false;
            // 
            // LogsViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelLogViewer);
            this.Name = "LogsViewerControl";
            this.Size = new System.Drawing.Size(1148, 615);
            this.Load += new System.EventHandler(this.LogsViewerControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLogViewer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBoxLogType;
        private System.Windows.Forms.CheckedListBox checkedListBoxLogFiles;
        private System.Windows.Forms.RichTextBox richTextBoxLogViewer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBoxViewLogFiles;
    }
}
