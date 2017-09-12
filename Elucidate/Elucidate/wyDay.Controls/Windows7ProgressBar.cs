using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace wyDay.Controls
{
    [ToolboxBitmap(typeof(ProgressBar))]
    public class Windows7ProgressBar : ProgressBar
    {
        private bool showInTaskbar;

        private ProgressBarState mState = ProgressBarState.Normal;

        private ContainerControl ownerForm;

        public ContainerControl ContainerControl
        {
            get
            {
                return this.ownerForm;
            }
            set
            {
                this.ownerForm = value;
                if (!this.ownerForm.Visible)
                {
                    ((Form)this.ownerForm).Shown += new EventHandler(this.Windows7ProgressBar_Shown);
                }
            }
        }

        public override ISite Site
        {
            set
            {
                base.Site = value;
                if (value == null)
                {
                    return;
                }
                IDesignerHost designerHost = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (designerHost == null)
                {
                    return;
                }
                IComponent rootComponent = designerHost.RootComponent;
                this.ContainerControl = (rootComponent as ContainerControl);
            }
        }

        [DefaultValue(false)]
        public bool ShowInTaskbar
        {
            get
            {
                return this.showInTaskbar;
            }
            set
            {
                if (this.showInTaskbar != value)
                {
                    this.showInTaskbar = value;
                    if (this.ownerForm != null)
                    {
                        if (this.Style != ProgressBarStyle.Marquee)
                        {
                            this.SetValueInTaskBar();
                        }
                        this.SetStateInTaskBar();
                    }
                }
            }
        }

        public new int Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                base.Value = value;
                base.Value = ((value != 0) ? (value - 1) : 1);
                base.Value = value;
                this.SetValueInTaskBar();
            }
        }

        public new ProgressBarStyle Style
        {
            get
            {
                return base.Style;
            }
            set
            {
                base.Style = value;
                if (this.showInTaskbar && this.ownerForm != null)
                {
                    this.SetStateInTaskBar();
                }
            }
        }

        [DefaultValue(ProgressBarState.Normal)]
        public ProgressBarState State
        {
            get
            {
                return this.mState;
            }
            set
            {
                this.mState = value;
                bool flag = this.Style == ProgressBarStyle.Marquee;
                if (flag)
                {
                    this.Style = ProgressBarStyle.Blocks;
                }
                Windows7Taskbar.SendMessage(base.Handle, 1040, (int)value, 0);
                if (flag)
                {
                    this.SetValueInTaskBar();
                    return;
                }
                this.SetStateInTaskBar();
            }
        }

        public Windows7ProgressBar()
        {
        }

        public Windows7ProgressBar(ContainerControl parentControl)
        {
            this.ContainerControl = parentControl;
        }

        private void Windows7ProgressBar_Shown(object sender, EventArgs e)
        {
            if (this.ShowInTaskbar)
            {
                if (this.Style != ProgressBarStyle.Marquee)
                {
                    this.SetValueInTaskBar();
                }
                this.SetStateInTaskBar();
            }
            ((Form)this.ownerForm).Shown -= new EventHandler(this.Windows7ProgressBar_Shown);
        }

        public new void Increment(int value)
        {
            base.Increment(value);
            this.SetValueInTaskBar();
        }

        public new void PerformStep()
        {
            base.PerformStep();
            this.SetValueInTaskBar();
        }

        private void SetValueInTaskBar()
        {
            if (this.showInTaskbar)
            {
                ulong maximum = (ulong)((long)(base.Maximum - base.Minimum));
                ulong current = (ulong)((long)(this.Value - base.Minimum));
                Windows7Taskbar.SetProgressValue(this.ownerForm.Handle, current, maximum);
            }
        }

        private void SetStateInTaskBar()
        {
            if (this.ownerForm == null)
            {
                return;
            }
            ThumbnailProgressState state = ThumbnailProgressState.Normal;
            if (!this.showInTaskbar)
            {
                state = ThumbnailProgressState.NoProgress;
            }
            else if (this.Style == ProgressBarStyle.Marquee)
            {
                state = ThumbnailProgressState.Indeterminate;
            }
            else if (this.mState == ProgressBarState.Error)
            {
                state = ThumbnailProgressState.Error;
            }
            else if (this.mState == ProgressBarState.Pause)
            {
                state = ThumbnailProgressState.Paused;
            }
            Windows7Taskbar.SetProgressState(this.ownerForm.Handle, state);
        }
    }
}
