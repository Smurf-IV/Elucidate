namespace Elucidate.TabPages
{
    partial class Schedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schedule));
            this.panelTaskView = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLinkLabel1 = new Krypton.Toolkit.KryptonLinkLabel();
            this.kryptonWrapLabel1 = new Krypton.Toolkit.KryptonWrapLabel();
            ((System.ComponentModel.ISupportInitialize)(this.panelTaskView)).BeginInit();
            this.panelTaskView.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTaskView
            // 
            this.panelTaskView.AutoSize = true;
            this.panelTaskView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTaskView.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelTaskView.Controls.Add(this.kryptonWrapLabel1);
            this.panelTaskView.Controls.Add(this.kryptonLinkLabel1);
            this.panelTaskView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTaskView.Location = new System.Drawing.Point(0, 0);
            this.panelTaskView.Margin = new System.Windows.Forms.Padding(2);
            this.panelTaskView.Name = "panelTaskView";
            this.panelTaskView.Size = new System.Drawing.Size(692, 428);
            this.panelTaskView.TabIndex = 2;
            // 
            // kryptonLinkLabel1
            // 
            this.kryptonLinkLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLinkLabel1.Location = new System.Drawing.Point(23, 14);
            this.kryptonLinkLabel1.Name = "kryptonLinkLabel1";
            this.kryptonLinkLabel1.Size = new System.Drawing.Size(406, 20);
            this.kryptonLinkLabel1.TabIndex = 1;
            this.kryptonLinkLabel1.Values.ExtraText = "Link To Open Issue";
            this.kryptonLinkLabel1.Values.Text = "https://github.com/Smurf-IV/Elucidate/issues/64";
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(23, 49);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(543, 345);
            this.kryptonWrapLabel1.Text = resources.GetString("kryptonWrapLabel1.Text");
            // 
            // Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panelTaskView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Schedule";
            this.Size = new System.Drawing.Size(692, 428);
            ((System.ComponentModel.ISupportInitialize)(this.panelTaskView)).EndInit();
            this.panelTaskView.ResumeLayout(false);
            this.panelTaskView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Krypton.Toolkit.KryptonPanel panelTaskView;
        private Krypton.Toolkit.KryptonLinkLabel kryptonLinkLabel1;
        private Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
    }
}
