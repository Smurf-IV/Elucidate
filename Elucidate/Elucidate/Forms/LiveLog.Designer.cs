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
            this.rtbLiveLog.Margin = new System.Windows.Forms.Padding(4);
            this.rtbLiveLog.Name = "rtbLiveLog";
            this.rtbLiveLog.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.rtbLiveLog.Size = new System.Drawing.Size(912, 506);
            this.rtbLiveLog.TabIndex = 1;
            // 
            // LiveLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(912, 506);
            this.ControlBox = false;
            this.Controls.Add(this.rtbLiveLog);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(930, 500);
            this.Name = "LiveLog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Live Log view";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LiveLog_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox rtbLiveLog;
    }
}