
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
            this.panelTaskView = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLinkLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.panelTaskView)).BeginInit();
            this.panelTaskView.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTaskView
            // 
            this.panelTaskView.AutoSize = true;
            this.panelTaskView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTaskView.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelTaskView.Controls.Add(this.kryptonLabel2);
            this.panelTaskView.Controls.Add(this.kryptonLinkLabel1);
            this.panelTaskView.Controls.Add(this.kryptonLabel1);
            this.panelTaskView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTaskView.Location = new System.Drawing.Point(0, 0);
            this.panelTaskView.Margin = new System.Windows.Forms.Padding(2);
            this.panelTaskView.Name = "panelTaskView";
            this.panelTaskView.Size = new System.Drawing.Size(692, 428);
            this.panelTaskView.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel1.Location = new System.Drawing.Point(28, 20);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(134, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "TODO: Add Examples";
            // 
            // kryptonLinkLabel1
            // 
            this.kryptonLinkLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLinkLabel1.Location = new System.Drawing.Point(28, 56);
            this.kryptonLinkLabel1.Name = "kryptonLinkLabel1";
            this.kryptonLinkLabel1.Size = new System.Drawing.Size(406, 20);
            this.kryptonLinkLabel1.TabIndex = 1;
            this.kryptonLinkLabel1.Values.ExtraText = "Link To Open Issue";
            this.kryptonLinkLabel1.Values.Text = "https://github.com/Smurf-IV/Elucidate/issues/64";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel2.Location = new System.Drawing.Point(28, 96);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(653, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Run Elucidate from a commandLine with either -H or --help after it to see the opt" +
    "ions. These can be combined.";
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
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelTaskView;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel kryptonLinkLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
    }
}
