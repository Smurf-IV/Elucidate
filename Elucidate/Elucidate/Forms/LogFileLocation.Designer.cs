using System.ComponentModel;
using System.Windows.Forms;

namespace Elucidate
{
   partial class LogFileLocation
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogFileLocation));
         this.label1 = new System.Windows.Forms.Label();
         this.txtCurrentLocation = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.txtNewLocation = new System.Windows.Forms.TextBox();
         this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
         this.btnLaunchBrowser = new System.Windows.Forms.Button();
         this.btnCommit = new System.Windows.Forms.Button();
         this.btnDefault = new System.Windows.Forms.Button();
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(102, 14);
         this.label1.TabIndex = 0;
         this.label1.Text = "Current Location:";
         // 
         // txtCurrentLocation
         // 
         this.txtCurrentLocation.Location = new System.Drawing.Point(121, 10);
         this.txtCurrentLocation.Name = "txtCurrentLocation";
         this.txtCurrentLocation.ReadOnly = true;
         this.txtCurrentLocation.Size = new System.Drawing.Size(478, 22);
         this.txtCurrentLocation.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(16, 43);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(94, 14);
         this.label2.TabIndex = 2;
         this.label2.Text = "  &New Location:";
         // 
         // txtNewLocation
         // 
         this.txtNewLocation.Location = new System.Drawing.Point(121, 40);
         this.txtNewLocation.Name = "txtNewLocation";
         this.txtNewLocation.Size = new System.Drawing.Size(441, 22);
         this.txtNewLocation.TabIndex = 3;
         this.txtNewLocation.Text = "New Location";
         // 
         // btnLaunchBrowser
         // 
         this.btnLaunchBrowser.Location = new System.Drawing.Point(568, 39);
         this.btnLaunchBrowser.Name = "btnLaunchBrowser";
         this.btnLaunchBrowser.Size = new System.Drawing.Size(31, 23);
         this.btnLaunchBrowser.TabIndex = 4;
         this.btnLaunchBrowser.Text = "...";
         this.btnLaunchBrowser.UseVisualStyleBackColor = true;
         this.btnLaunchBrowser.Click += new System.EventHandler(this.btnLaunchBrowser_Click);
         // 
         // btnCommit
         // 
         this.btnCommit.Location = new System.Drawing.Point(524, 78);
         this.btnCommit.Name = "btnCommit";
         this.btnCommit.Size = new System.Drawing.Size(75, 23);
         this.btnCommit.TabIndex = 5;
         this.btnCommit.Text = "Commit";
         this.btnCommit.UseVisualStyleBackColor = true;
         this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
         // 
         // btnDefault
         // 
         this.btnDefault.Location = new System.Drawing.Point(431, 78);
         this.btnDefault.Name = "btnDefault";
         this.btnDefault.Size = new System.Drawing.Size(75, 23);
         this.btnDefault.TabIndex = 6;
         this.btnDefault.Text = "Default";
         this.btnDefault.UseVisualStyleBackColor = true;
         this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
         // 
         // richTextBox1
         // 
         this.richTextBox1.Location = new System.Drawing.Point(17, 109);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.ReadOnly = true;
         this.richTextBox1.Size = new System.Drawing.Size(580, 183);
         this.richTextBox1.TabIndex = 7;
         this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
         // 
         // LogFileLocation
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(611, 304);
         this.Controls.Add(this.richTextBox1);
         this.Controls.Add(this.btnDefault);
         this.Controls.Add(this.btnCommit);
         this.Controls.Add(this.btnLaunchBrowser);
         this.Controls.Add(this.txtNewLocation);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.txtCurrentLocation);
         this.Controls.Add(this.label1);
         this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(627, 342);
         this.Name = "LogFileLocation";
         this.Text = "Log File Location";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Label label1;
      private TextBox txtCurrentLocation;
      private Label label2;
      private TextBox txtNewLocation;
      private FolderBrowserDialog folderBrowserDialog1;
      private Button btnLaunchBrowser;
      private Button btnCommit;
      private Button btnDefault;
      private RichTextBox richTextBox1;
   }
}