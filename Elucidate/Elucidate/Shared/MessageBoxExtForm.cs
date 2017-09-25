using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Shared
{
    internal class MessageBoxExtForm : Form
    {
        private MessageBoxButtons mMessageBoxButtons;

        private IContainer components;

        private Panel panel2;

        private TableLayoutPanel tableLayoutPanel1;

        private PictureBox boxIcon;

        private TableLayoutPanel tableLayoutPanel2;

        private Label lblTask;

        private Label lblInformation;

        private FlowLayoutPanel flowLayoutPanel1;

        private Button btnCancel;

        private Button btnOK;

        private Button btnNo;

        private Button btnYes;

        private Button btnIgnore;

        private Button btnRetry;

        private Button btnAbort;

        public MessageBoxExtForm(string caption, string task, string information)
        {
            this.InitializeComponent();
            base.Text = caption;
            this.lblTask.Text = task;
            this.lblInformation.Text = information;
            base.StartPosition = FormStartPosition.CenterParent;
        }

        internal void SetButtons(MessageBoxButtons buttons)
        {
            this.mMessageBoxButtons = buttons;
            this.btnAbort.Visible = false;
            this.btnCancel.Visible = false;
            this.btnIgnore.Visible = false;
            this.btnNo.Visible = false;
            this.btnOK.Visible = false;
            this.btnRetry.Visible = false;
            this.btnYes.Visible = false;
            switch (buttons)
            {
                case MessageBoxButtons.OKCancel:
                    this.btnOK.Visible = true;
                    this.btnCancel.Visible = true;
                    return;
                case MessageBoxButtons.AbortRetryIgnore:
                    this.btnAbort.Visible = true;
                    this.btnRetry.Visible = true;
                    this.btnIgnore.Visible = true;
                    return;
                case MessageBoxButtons.YesNoCancel:
                    this.btnYes.Visible = true;
                    this.btnNo.Visible = true;
                    this.btnCancel.Visible = true;
                    return;
                case MessageBoxButtons.YesNo:
                    this.btnYes.Visible = true;
                    this.btnNo.Visible = true;
                    return;
                case MessageBoxButtons.RetryCancel:
                    this.btnRetry.Visible = true;
                    this.btnCancel.Visible = true;
                    return;
                default:
                    this.btnOK.Visible = true;
                    return;
            }
        }

        internal void SetIcon(MessageBoxIcon icon)
        {
            Icon icon2;
            if (icon <= MessageBoxIcon.Question)
            {
                if (icon == MessageBoxIcon.Hand)
                {
                    icon2 = SystemIcons.Hand;
                    goto IL_4B;
                }
                if (icon == MessageBoxIcon.Question)
                {
                    icon2 = SystemIcons.Question;
                    goto IL_4B;
                }
            }
            else
            {
                if (icon == MessageBoxIcon.Exclamation)
                {
                    icon2 = SystemIcons.Exclamation;
                    goto IL_4B;
                }
                if (icon == MessageBoxIcon.Asterisk)
                {
                    icon2 = SystemIcons.Asterisk;
                    goto IL_4B;
                }
            }
            icon2 = null;
            this.boxIcon.Visible = false;
            IL_4B:
            if (icon2 != null)
            {
                this.boxIcon.Image = new Icon(icon2, 48, 48).ToBitmap();
            }
        }

        internal void SetDefaultButton(MessageBoxDefaultButton defaultButton)
        {
            if (defaultButton != MessageBoxDefaultButton.Button1)
            {
                if (defaultButton != MessageBoxDefaultButton.Button2)
                {
                    if (defaultButton != MessageBoxDefaultButton.Button3)
                    {
                        return;
                    }
                    switch (this.mMessageBoxButtons)
                    {
                        case MessageBoxButtons.AbortRetryIgnore:
                            this.btnIgnore.Focus();
                            return;
                        case MessageBoxButtons.YesNoCancel:
                            this.btnCancel.Focus();
                            return;
                        default:
                            return;
                    }
                }
                else
                {
                    switch (this.mMessageBoxButtons)
                    {
                        case MessageBoxButtons.OKCancel:
                            this.btnCancel.Focus();
                            return;
                        case MessageBoxButtons.AbortRetryIgnore:
                            this.btnRetry.Focus();
                            return;
                        case MessageBoxButtons.YesNoCancel:
                            this.btnNo.Focus();
                            return;
                        case MessageBoxButtons.YesNo:
                            this.btnNo.Focus();
                            return;
                        case MessageBoxButtons.RetryCancel:
                            this.btnCancel.Focus();
                            return;
                        default:
                            return;
                    }
                }
            }
            else
            {
                switch (this.mMessageBoxButtons)
                {
                    case MessageBoxButtons.OK:
                        this.btnOK.Focus();
                        return;
                    case MessageBoxButtons.OKCancel:
                        this.btnOK.Focus();
                        return;
                    case MessageBoxButtons.AbortRetryIgnore:
                        this.btnAbort.Focus();
                        return;
                    case MessageBoxButtons.YesNoCancel:
                        this.btnYes.Focus();
                        return;
                    case MessageBoxButtons.YesNo:
                        this.btnYes.Focus();
                        return;
                    case MessageBoxButtons.RetryCancel:
                        this.btnRetry.Focus();
                        return;
                    default:
                        return;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel2 = new Panel();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.boxIcon = new PictureBox();
            this.tableLayoutPanel2 = new TableLayoutPanel();
            this.lblTask = new Label();
            this.lblInformation = new Label();
            this.flowLayoutPanel1 = new FlowLayoutPanel();
            this.btnCancel = new Button();
            this.btnAbort = new Button();
            this.btnRetry = new Button();
            this.btnIgnore = new Button();
            this.btnYes = new Button();
            this.btnNo = new Button();
            this.btnOK = new Button();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((ISupportInitialize)this.boxIcon).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            base.SuspendLayout();
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = DockStyle.Bottom;
            this.panel2.Location = new Point(0, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(572, 41);
            this.panel2.TabIndex = 1;
            this.tableLayoutPanel1.BackColor = SystemColors.ControlLightLight;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.boxIcon, 0, 0);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            this.tableLayoutPanel1.Size = new Size(572, 130);
            this.tableLayoutPanel1.TabIndex = 2;
            this.boxIcon.Location = new Point(3, 3);
            this.boxIcon.Name = "boxIcon";
            this.boxIcon.Size = new Size(56, 56);
            this.boxIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            this.boxIcon.TabIndex = 0;
            this.boxIcon.TabStop = false;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            this.tableLayoutPanel2.Controls.Add(this.lblTask, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblInformation, 0, 1);
            this.tableLayoutPanel2.Dock = DockStyle.Fill;
            this.tableLayoutPanel2.Location = new Point(65, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 35.08772f));
            this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 64.91228f));
            this.tableLayoutPanel2.Size = new Size(504, 124);
            this.tableLayoutPanel2.TabIndex = 1;
            this.lblTask.AutoSize = true;
            this.lblTask.Dock = DockStyle.Fill;
            this.lblTask.Font = new Font("Tahoma", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblTask.ForeColor = SystemColors.Highlight;
            this.lblTask.Location = new Point(3, 0);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new Size(498, 43);
            this.lblTask.TabIndex = 0;
            this.lblTask.Text = "label1";
            this.lblTask.TextAlign = ContentAlignment.MiddleLeft;
            this.lblInformation.AutoSize = true;
            this.lblInformation.Dock = DockStyle.Fill;
            this.lblInformation.Location = new Point(3, 43);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new Size(498, 81);
            this.lblInformation.TabIndex = 1;
            this.lblInformation.Text = "label2";
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnOK);
            this.flowLayoutPanel1.Controls.Add(this.btnNo);
            this.flowLayoutPanel1.Controls.Add(this.btnYes);
            this.flowLayoutPanel1.Controls.Add(this.btnIgnore);
            this.flowLayoutPanel1.Controls.Add(this.btnRetry);
            this.flowLayoutPanel1.Controls.Add(this.btnAbort);
            this.flowLayoutPanel1.Dock = DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new Padding(0, 6, 0, 0);
            this.flowLayoutPanel1.Size = new Size(572, 41);
            this.flowLayoutPanel1.TabIndex = 0;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(494, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnAbort.DialogResult = DialogResult.Abort;
            this.btnAbort.Location = new Point(8, 9);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new Size(75, 23);
            this.btnAbort.TabIndex = 1;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnRetry.DialogResult = DialogResult.Retry;
            this.btnRetry.Location = new Point(89, 9);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new Size(75, 23);
            this.btnRetry.TabIndex = 2;
            this.btnRetry.Text = "Retry";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnIgnore.DialogResult = DialogResult.Ignore;
            this.btnIgnore.Location = new Point(170, 9);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new Size(75, 23);
            this.btnIgnore.TabIndex = 3;
            this.btnIgnore.Text = "Ignore";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnYes.DialogResult = DialogResult.Yes;
            this.btnYes.Location = new Point(251, 9);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new Size(75, 23);
            this.btnYes.TabIndex = 4;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnNo.DialogResult = DialogResult.No;
            this.btnNo.Location = new Point(332, 9);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new Size(75, 23);
            this.btnNo.TabIndex = 5;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new Point(413, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(572, 171);
            base.ControlBox = false;
            base.Controls.Add(this.tableLayoutPanel1);
            base.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Font = new Font("Tahoma", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "MessageBoxExtForm";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            this.Text = "MessageBoxExtForm";
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((ISupportInitialize)this.boxIcon).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}
