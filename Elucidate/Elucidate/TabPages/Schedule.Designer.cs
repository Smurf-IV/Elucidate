using Microsoft.Win32.TaskScheduler;

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
            this.taskListView = new Microsoft.Win32.TaskScheduler.TaskListView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGetSchedules = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.menuButtonNewScheduleItem = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.kcmNewOptions = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.kryptonContextMenuItems1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kcmItemSync = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kcmItemCheck = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kcmItemDiff = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.kcmItemScrub = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem();
            this.btnDelete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEdit = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEnableDisable = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnRun = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panelTaskView = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelTaskView)).BeginInit();
            this.panelTaskView.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskListView
            // 
            this.taskListView.AutoScroll = true;
            this.taskListView.AutoSize = true;
            this.taskListView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.taskListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskListView.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskListView.Location = new System.Drawing.Point(120, 0);
            this.taskListView.Margin = new System.Windows.Forms.Padding(0);
            this.taskListView.MinimumSize = new System.Drawing.Size(375, 162);
            this.taskListView.Name = "taskListView";
            this.taskListView.SelectedIndex = -1;
            this.taskListView.Size = new System.Drawing.Size(572, 428);
            this.taskListView.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.btnGetSchedules);
            this.flowLayoutPanel1.Controls.Add(this.menuButtonNewScheduleItem);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Controls.Add(this.btnEnableDisable);
            this.flowLayoutPanel1.Controls.Add(this.btnRun);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(38, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(120, 428);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnGetSchedules
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.btnGetSchedules, true);
            this.btnGetSchedules.Location = new System.Drawing.Point(6, 6);
            this.btnGetSchedules.Margin = new System.Windows.Forms.Padding(6);
            this.btnGetSchedules.Name = "btnGetSchedules";
            this.btnGetSchedules.Size = new System.Drawing.Size(108, 26);
            this.btnGetSchedules.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetSchedules.TabIndex = 4;
            this.btnGetSchedules.Values.Text = "Get &Schedules";
            this.btnGetSchedules.Click += new System.EventHandler(this.btnGetSchedules_Click);
            // 
            // menuButtonNewScheduleItem
            // 
            this.menuButtonNewScheduleItem.KryptonContextMenu = this.kcmNewOptions;
            this.menuButtonNewScheduleItem.Location = new System.Drawing.Point(6, 44);
            this.menuButtonNewScheduleItem.Margin = new System.Windows.Forms.Padding(6);
            this.menuButtonNewScheduleItem.Name = "menuButtonNewScheduleItem";
            this.menuButtonNewScheduleItem.Size = new System.Drawing.Size(108, 26);
            this.menuButtonNewScheduleItem.Splitter = false;
            this.menuButtonNewScheduleItem.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButtonNewScheduleItem.TabIndex = 6;
            this.menuButtonNewScheduleItem.Values.Text = "&New";
            // 
            // kcmNewOptions
            // 
            this.kcmNewOptions.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kryptonContextMenuItems1});
            // 
            // kryptonContextMenuItems1
            // 
            this.kryptonContextMenuItems1.ImageColumn = false;
            this.kryptonContextMenuItems1.Items.AddRange(new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase[] {
            this.kcmItemSync,
            this.kcmItemCheck,
            this.kcmItemDiff,
            this.kcmItemScrub});
            // 
            // kcmItemSync
            // 
            this.kcmItemSync.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.kcmItemSync.Text = "&Sync";
            // 
            // kcmItemCheck
            // 
            this.kcmItemCheck.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.kcmItemCheck.Text = "&Check";
            // 
            // kcmItemDiff
            // 
            this.kcmItemDiff.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.kcmItemDiff.Text = "&Diff";
            // 
            // kcmItemScrub
            // 
            this.kcmItemScrub.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.kcmItemScrub.Text = "Sc&rub";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.flowLayoutPanel1.SetFlowBreak(this.btnDelete, true);
            this.btnDelete.Location = new System.Drawing.Point(6, 82);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(108, 26);
            this.btnDelete.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Values.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.flowLayoutPanel1.SetFlowBreak(this.btnEdit, true);
            this.btnEdit.Location = new System.Drawing.Point(6, 120);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(108, 26);
            this.btnEdit.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Values.Text = "&Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnEnableDisable
            // 
            this.btnEnableDisable.Enabled = false;
            this.flowLayoutPanel1.SetFlowBreak(this.btnEnableDisable, true);
            this.btnEnableDisable.Location = new System.Drawing.Point(6, 158);
            this.btnEnableDisable.Margin = new System.Windows.Forms.Padding(6);
            this.btnEnableDisable.Name = "btnEnableDisable";
            this.btnEnableDisable.Size = new System.Drawing.Size(108, 40);
            this.btnEnableDisable.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnableDisable.StateCommon.Content.ShortText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnEnableDisable.TabIndex = 6;
            this.btnEnableDisable.Values.Text = "En&able -\r\nDisable";
            this.btnEnableDisable.Click += new System.EventHandler(this.btnEnableDisable_Click);
            // 
            // btnRun
            // 
            this.flowLayoutPanel1.SetFlowBreak(this.btnRun, true);
            this.btnRun.Location = new System.Drawing.Point(6, 210);
            this.btnRun.Margin = new System.Windows.Forms.Padding(6);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(108, 26);
            this.btnRun.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.TabIndex = 6;
            this.btnRun.Values.Text = "&Run";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // panelTaskView
            // 
            this.panelTaskView.AutoSize = true;
            this.panelTaskView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTaskView.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelTaskView.Controls.Add(this.taskListView);
            this.panelTaskView.Controls.Add(this.flowLayoutPanel1);
            this.panelTaskView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTaskView.Location = new System.Drawing.Point(0, 0);
            this.panelTaskView.Margin = new System.Windows.Forms.Padding(2);
            this.panelTaskView.Name = "panelTaskView";
            this.panelTaskView.Size = new System.Drawing.Size(692, 428);
            this.panelTaskView.TabIndex = 2;
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
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelTaskView)).EndInit();
            this.panelTaskView.ResumeLayout(false);
            this.panelTaskView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEdit;
        private TaskListView taskListView;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelTaskView;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGetSchedules;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton menuButtonNewScheduleItem;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEnableDisable;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnRun;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu kcmNewOptions;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kcmItemSync;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kcmItemCheck;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kcmItemDiff;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem kcmItemScrub;
    }
}
