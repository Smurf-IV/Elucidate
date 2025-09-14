namespace Elucidate.Controls
{
    internal partial class ProtectedDrivesDisplay
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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.driveGrid = new Krypton.Toolkit.KryptonDataGridView();
            this.colPath = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colName = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            this.colDriveSpace = new Elucidate.Controls.DataGridViewTripleValueBarColumn();
            this.colDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.driveGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.AllowDrop = true;
            this.kryptonPanel1.Controls.Add(this.driveGrid);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(537, 357);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // driveGrid
            // 
            this.driveGrid.AllowDrop = true;
            this.driveGrid.AllowUserToResizeColumns = false;
            this.driveGrid.AllowUserToResizeRows = false;
            this.driveGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.driveGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.driveGrid.ColumnHeadersHeight = 36;
            this.driveGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPath,
            this.colName,
            this.colDriveSpace,
            this.colDetails});
            this.driveGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.driveGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.driveGrid.Location = new System.Drawing.Point(0, 0);
            this.driveGrid.Margin = new System.Windows.Forms.Padding(4);
            this.driveGrid.MultiSelect = false;
            this.driveGrid.Name = "driveGrid";
            this.driveGrid.RowHeadersVisible = false;
            this.driveGrid.RowHeadersWidth = 51;
            this.driveGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.driveGrid.ShowEditingIcon = false;
            this.driveGrid.Size = new System.Drawing.Size(537, 357);
            this.driveGrid.StateCommon.BackStyle = Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            this.driveGrid.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driveGrid.StateCommon.HeaderColumn.Content.Hint = Krypton.Toolkit.PaletteTextHint.AntiAlias;
            this.driveGrid.TabIndex = 0;
            this.driveGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.driveGrid_RowsAdded);
            this.driveGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DriveGrid_MouseDown);
            // 
            // colPath
            // 
            this.colPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPath.Frozen = true;
            this.colPath.HeaderText = "Path";
            this.colPath.MinimumWidth = 6;
            this.colPath.Name = "colPath";
            this.colPath.ReadOnly = true;
            this.colPath.Width = 75;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colName.HeaderText = "Name";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.Width = 84;
            // 
            // colDriveSpace
            // 
            this.colDriveSpace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDriveSpace.HeaderText = "Drive Space Protected : Used : Max Available";
            this.colDriveSpace.MinimumWidth = 6;
            this.colDriveSpace.Name = "colDriveSpace";
            // 
            // colDetails
            // 
            this.colDetails.HeaderText = "Prot : Used : Max";
            this.colDetails.MinimumWidth = 6;
            this.colDetails.Name = "colDetails";
            this.colDetails.Width = 167;
            // 
            // ProtectedDrivesDisplay
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.kryptonPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProtectedDrivesDisplay";
            this.Size = new System.Drawing.Size(537, 357);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.driveGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        internal Krypton.Toolkit.KryptonDataGridView driveGrid;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colPath;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn colName;
        private DataGridViewTripleValueBarColumn colDriveSpace;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetails;
    }
}
