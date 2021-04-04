using System.Windows.Forms;
using Elucidate.Controls;

namespace Elucidate.TabPages
{
    partial class Recover
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRecoverSelectedFiles = new System.Windows.Forms.Button();
            this.btnSelectAllFiles = new System.Windows.Forms.Button();
            this.btnClearFiles = new System.Windows.Forms.Button();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.timerTreeViewFill = new System.Windows.Forms.Timer(this.components);
            this.timerTreeViewRecover = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnSelectAllFiles);
            this.flowLayoutPanel1.Controls.Add(this.btnRecoverSelectedFiles);
            this.flowLayoutPanel1.Controls.Add(this.btnClearFiles);
            this.flowLayoutPanel1.Controls.Add(this.kryptonLabel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1113, 36);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnRecoverSelectedFiles
            // 
            this.btnRecoverSelectedFiles.Location = new System.Drawing.Point(197, 4);
            this.btnRecoverSelectedFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecoverSelectedFiles.Name = "btnRecoverSelectedFiles";
            this.btnRecoverSelectedFiles.Size = new System.Drawing.Size(185, 28);
            this.btnRecoverSelectedFiles.TabIndex = 1;
            this.btnRecoverSelectedFiles.Text = "Recover Selected Files";
            this.btnRecoverSelectedFiles.UseVisualStyleBackColor = true;
            this.btnRecoverSelectedFiles.Click += new System.EventHandler(this.btnRecoverSelectedFiles_Click);
            // 
            // btnSelectAllFiles
            // 
            this.btnSelectAllFiles.Location = new System.Drawing.Point(4, 4);
            this.btnSelectAllFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectAllFiles.Name = "btnSelectAllFiles";
            this.btnSelectAllFiles.Size = new System.Drawing.Size(185, 28);
            this.btnSelectAllFiles.TabIndex = 3;
            this.btnSelectAllFiles.Text = "Select All Files";
            this.btnSelectAllFiles.UseVisualStyleBackColor = true;
            this.btnSelectAllFiles.Click += new System.EventHandler(this.btnRecoverAllFiles_Click);
            // 
            // btnClearFiles
            // 
            this.btnClearFiles.Location = new System.Drawing.Point(390, 4);
            this.btnClearFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearFiles.Name = "btnClearFiles";
            this.btnClearFiles.Size = new System.Drawing.Size(100, 28);
            this.btnClearFiles.TabIndex = 2;
            this.btnClearFiles.Text = "Clear Selected";
            this.btnClearFiles.UseVisualStyleBackColor = true;
            this.btnClearFiles.Click += new System.EventHandler(this.btnClearFiles_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.Location = new System.Drawing.Point(497, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(605, 30);
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "Warning: Will not restore empty directories. Will not restore full paths (due to " +
    "-a usage)";
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.FullRowSelect = true;
            this.treeView1.Location = new System.Drawing.Point(0, 36);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(1113, 498);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // timerTreeViewFill
            // 
            this.timerTreeViewFill.Interval = 250;
            this.timerTreeViewFill.Tick += new System.EventHandler(this.timerTreeViewFill_Tick);
            // 
            // timerTreeViewRecover
            // 
            this.timerTreeViewRecover.Interval = 250;
            this.timerTreeViewRecover.Tick += new System.EventHandler(this.timerTreeViewRecover_Tick);
            // 
            // Recover
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Recover";
            this.Size = new System.Drawing.Size(1113, 534);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnRecoverSelectedFiles;
        private System.Windows.Forms.Button btnClearFiles;
        private System.Windows.Forms.Timer timerTreeViewFill;
        private TreeView treeView1;
        private Timer timerTreeViewRecover;
        private Button btnSelectAllFiles;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
