namespace Elucidate.Forms
{
    partial class LiveLog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiveLog));
            this.rtbLiveLog = new System.Windows.Forms.ListBox();
            this.logRTB = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbLiveLog
            // 
            this.rtbLiveLog.BackColor = System.Drawing.SystemColors.Control;
            this.rtbLiveLog.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rtbLiveLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLiveLog.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.rtbLiveLog.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLiveLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLiveLog.Margin = new System.Windows.Forms.Padding(6);
            this.rtbLiveLog.Name = "rtbLiveLog";
            this.rtbLiveLog.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.rtbLiveLog.Size = new System.Drawing.Size(1277, 708);
            this.rtbLiveLog.TabIndex = 1;
            // 
            // logRTB
            // 
            this.logRTB.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.logRTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logRTB.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logRTB.Location = new System.Drawing.Point(0, 0);
            this.logRTB.Name = "logRTB";
            this.logRTB.ReadOnly = true;
            this.logRTB.ShortcutsEnabled = false;
            this.logRTB.Size = new System.Drawing.Size(1277, 708);
            this.logRTB.TabIndex = 2;
            this.logRTB.Text = "";
            this.logRTB.WordWrap = false;
            // 
            // LiveLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1277, 708);
            this.CloseBox = false;
            this.Controls.Add(this.logRTB);
            this.Controls.Add(this.rtbLiveLog);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1292, 674);
            this.Name = "LiveLog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Live Log view";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LiveLog_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox rtbLiveLog;
        internal System.Windows.Forms.RichTextBox logRTB;
    }
}