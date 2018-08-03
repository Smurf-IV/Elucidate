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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.richTextBoxLogViewer = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxLogType = new System.Windows.Forms.ComboBox();
            this.checkedListBoxLogFiles = new System.Windows.Forms.CheckedListBox();
            this.listViewLogFiles = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panelRight, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(765, 400);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.richTextBoxLogViewer);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(162, 2);
            this.panelRight.Margin = new System.Windows.Forms.Padding(2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(601, 396);
            this.panelRight.TabIndex = 9;
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
            this.richTextBoxLogViewer.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxLogViewer.MinimumSize = new System.Drawing.Size(151, 163);
            this.richTextBoxLogViewer.Name = "richTextBoxLogViewer";
            this.richTextBoxLogViewer.ReadOnly = true;
            this.richTextBoxLogViewer.Size = new System.Drawing.Size(599, 394);
            this.richTextBoxLogViewer.TabIndex = 3;
            this.richTextBoxLogViewer.Text = "";
            this.richTextBoxLogViewer.WordWrap = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.comboBoxLogType);
            this.flowLayoutPanel1.Controls.Add(this.checkedListBoxLogFiles);
            this.flowLayoutPanel1.Controls.Add(this.listViewLogFiles);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(154, 394);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // comboBoxLogType
            // 
            this.comboBoxLogType.FormattingEnabled = true;
            this.comboBoxLogType.Location = new System.Drawing.Point(3, 3);
            this.comboBoxLogType.Name = "comboBoxLogType";
            this.comboBoxLogType.Size = new System.Drawing.Size(150, 21);
            this.comboBoxLogType.TabIndex = 1;
            this.comboBoxLogType.SelectedIndexChanged += new System.EventHandler(this.comboBoxLogType_SelectedIndexChanged);
            // 
            // checkedListBoxLogFiles
            // 
            this.checkedListBoxLogFiles.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBoxLogFiles.FormattingEnabled = true;
            this.checkedListBoxLogFiles.Location = new System.Drawing.Point(2, 29);
            this.checkedListBoxLogFiles.Margin = new System.Windows.Forms.Padding(2);
            this.checkedListBoxLogFiles.Name = "checkedListBoxLogFiles";
            this.checkedListBoxLogFiles.Size = new System.Drawing.Size(150, 19);
            this.checkedListBoxLogFiles.TabIndex = 6;
            this.checkedListBoxLogFiles.Visible = false;
            this.checkedListBoxLogFiles.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxLogFiles_SelectedIndexChanged);
            // 
            // listViewLogFiles
            // 
            this.listViewLogFiles.BackColor = System.Drawing.SystemColors.Control;
            this.listViewLogFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewLogFiles.FullRowSelect = true;
            this.listViewLogFiles.GridLines = true;
            this.listViewLogFiles.HideSelection = false;
            this.listViewLogFiles.Location = new System.Drawing.Point(2, 52);
            this.listViewLogFiles.Margin = new System.Windows.Forms.Padding(2);
            this.listViewLogFiles.MinimumSize = new System.Drawing.Size(50, 150);
            this.listViewLogFiles.MultiSelect = false;
            this.listViewLogFiles.Name = "listViewLogFiles";
            this.listViewLogFiles.Size = new System.Drawing.Size(150, 250);
            this.listViewLogFiles.TabIndex = 7;
            this.listViewLogFiles.UseCompatibleStateImageBehavior = false;
            this.listViewLogFiles.View = System.Windows.Forms.View.List;
            this.listViewLogFiles.SelectedIndexChanged += new System.EventHandler(this.listViewLogFiles_SelectedIndexChanged);
            // 
            // LogsViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelLogViewer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LogsViewerControl";
            this.Size = new System.Drawing.Size(765, 400);
            this.Load += new System.EventHandler(this.LogsViewerControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLogViewer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.RichTextBox richTextBoxLogViewer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxLogType;
        private System.Windows.Forms.CheckedListBox checkedListBoxLogFiles;
        private System.Windows.Forms.ListView listViewLogFiles;
    }
}
