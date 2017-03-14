using System.ComponentModel;
using System.Windows.Forms;

namespace Elucidate
{
   partial class RecoveryWizard
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.guideIndicator = new TextBox();
         this.SuspendLayout();
         // 
         // guideIndicator
         // 
         this.guideIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.guideIndicator.BackColor = System.Drawing.SystemColors.ControlLight;
         this.guideIndicator.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.guideIndicator.Location = new System.Drawing.Point(0, 0);
         this.guideIndicator.Margin = new System.Windows.Forms.Padding(0);
         this.guideIndicator.Name = "guideIndicator";
         this.guideIndicator.Size = new System.Drawing.Size(660, 96);
         this.guideIndicator.TabIndex = 0;
         this.guideIndicator.Text = "Decide on the Route";
         // 
         // RecoveryWizard
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.guideIndicator);
         this.Name = "RecoveryWizard";
         this.Size = new System.Drawing.Size(660, 305);
         this.ResumeLayout(false);

      }

      #endregion

      private TextBox guideIndicator;
   }
}
