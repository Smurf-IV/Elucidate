using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace Elucidate.Controls
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
            this.taskListView = new Microsoft.Win32.TaskScheduler.TaskListView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGetSchedules = new System.Windows.Forms.Button();
            this.btnNewReplace = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panelTaskView = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelTaskView.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskListView
            // 
            this.taskListView.AutoSize = true;
            this.taskListView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.taskListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskListView.Location = new System.Drawing.Point(0, 0);
            this.taskListView.Margin = new System.Windows.Forms.Padding(0);
            this.taskListView.MinimumSize = new System.Drawing.Size(500, 200);
            this.taskListView.Name = "taskListView";
            this.taskListView.SelectedIndex = -1;
            this.taskListView.Size = new System.Drawing.Size(796, 527);
            this.taskListView.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnGetSchedules);
            this.flowLayoutPanel1.Controls.Add(this.btnNewReplace);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(50, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(127, 527);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnGetSchedules
            // 
            this.btnGetSchedules.AutoSize = true;
            this.btnGetSchedules.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.SetFlowBreak(this.btnGetSchedules, true);
            this.btnGetSchedules.Location = new System.Drawing.Point(8, 8);
            this.btnGetSchedules.Margin = new System.Windows.Forms.Padding(8);
            this.btnGetSchedules.Name = "btnGetSchedules";
            this.btnGetSchedules.Size = new System.Drawing.Size(111, 27);
            this.btnGetSchedules.TabIndex = 4;
            this.btnGetSchedules.Text = "Get &Schedules";
            this.btnGetSchedules.UseVisualStyleBackColor = true;
            this.btnGetSchedules.Click += new System.EventHandler(this.btnGetSchedules_Click);
            // 
            // btnNewReplace
            // 
            this.btnNewReplace.AutoSize = true;
            this.btnNewReplace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.SetFlowBreak(this.btnNewReplace, true);
            this.btnNewReplace.Location = new System.Drawing.Point(8, 51);
            this.btnNewReplace.Margin = new System.Windows.Forms.Padding(8);
            this.btnNewReplace.Name = "btnNewReplace";
            this.btnNewReplace.Size = new System.Drawing.Size(109, 27);
            this.btnNewReplace.TabIndex = 5;
            this.btnNewReplace.Text = "New / Replace";
            this.btnNewReplace.UseVisualStyleBackColor = true;
            this.btnNewReplace.Click += new System.EventHandler(this.btnNewReplace_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.btnDelete, true);
            this.btnDelete.Location = new System.Drawing.Point(8, 94);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(59, 27);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.flowLayoutPanel1.SetFlowBreak(this.btnEdit, true);
            this.btnEdit.Location = new System.Drawing.Point(8, 137);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(42, 27);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // panelTaskView
            // 
            this.panelTaskView.AutoSize = true;
            this.panelTaskView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTaskView.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelTaskView.Controls.Add(this.taskListView);
            this.panelTaskView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTaskView.Location = new System.Drawing.Point(127, 0);
            this.panelTaskView.Name = "panelTaskView";
            this.panelTaskView.Size = new System.Drawing.Size(796, 527);
            this.panelTaskView.TabIndex = 2;
            // 
            // Scheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panelTaskView);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Scheduler";
            this.Size = new System.Drawing.Size(923, 527);
            this.Load += new System.EventHandler(this.Scheduler_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panelTaskView.ResumeLayout(false);
            this.panelTaskView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnGetSchedules;
        private System.Windows.Forms.Button btnNewReplace;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private TaskListView taskListView;
        private Panel panelTaskView;
    }
}
