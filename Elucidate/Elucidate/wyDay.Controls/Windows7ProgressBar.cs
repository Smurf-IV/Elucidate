using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

//Windows7ProgressBar v1.0, created by Wyatt O'Day
//Visit: http://wyday.com/windows-7-progress-bar/

namespace wyDay.Controls
{
    /// <summary>
    /// A Windows progress bar control with Windows Vista & 7 functionality.
    /// </summary>
    [ToolboxBitmap(typeof(ProgressBar))]
    public class Windows7ProgressBar : ProgressBar
    {
        bool showInTaskbar;
        private ProgressBarState m_State = ProgressBarState.Normal;
        ContainerControl ownerForm;

        public Windows7ProgressBar () {}

        public Windows7ProgressBar(ContainerControl parentControl)
        {
            ContainerControl = parentControl;
        }
        public ContainerControl ContainerControl
        {
            get { return ownerForm; }
            set
            {
                ownerForm = value;

                if(!ownerForm.Visible)
                    ((Form)ownerForm).Shown += Windows7ProgressBar_Shown;
            }
        }
        public override ISite Site
        {
            set
            {
                // Runs at design time, ensures designer initializes ContainerControl
                base.Site = value;
                if (value == null) return;
                IDesignerHost service = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
                if (service == null) return;
                IComponent rootComponent = service.RootComponent;

                ContainerControl = rootComponent as ContainerControl;
            }
        }

        void Windows7ProgressBar_Shown(object sender, System.EventArgs e)
        {
            if (ShowInTaskbar)
            {
                if (Style != ProgressBarStyle.Marquee)
                    SetValueInTB();

                SetStateInTB();
            }

            ((Form)ownerForm).Shown -= Windows7ProgressBar_Shown;
        }



        /// <summary>
        /// Show progress in taskbar
        /// </summary>
        [DefaultValue(false)]
        public bool ShowInTaskbar
        {
            get
            {
                return showInTaskbar;
            }
            set
            {
                if (showInTaskbar != value)
                {
                    showInTaskbar = value;

                    // send signal to the taskbar.
                    if (ownerForm != null)
                    {
                        if (Style != ProgressBarStyle.Marquee)
                            SetValueInTB();

                        SetStateInTB();
                    }
                }
            }
        }


        /// <summary>
        /// Gets or sets the current position of the progress bar.
        /// </summary>
        /// <returns>The position within the range of the progress bar. The default is 0.</returns>
        public new int Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                base.Value = value;

                // send signal to the taskbar.
                SetValueInTB();
            }
        }

        /// <summary>
        /// Gets or sets the manner in which progress should be indicated on the progress bar.
        /// </summary>
        /// <returns>One of the ProgressBarStyle values. The default is ProgressBarStyle.Blocks</returns>
        public new ProgressBarStyle Style
        {
            get
            {
                return base.Style;
            }
            set
            {
                base.Style = value;

                // set the style of the progress bar
                if (showInTaskbar && ownerForm != null)
                {
                    SetStateInTB();
                }
            }
        }


        /// <summary>
        /// The progress bar state for Windows Vista & 7
        /// </summary>
        [DefaultValue(ProgressBarState.Normal)]
        public ProgressBarState State
        {
            get { return m_State; }
            set
            {
                m_State = value;

                bool wasMarquee = Style == ProgressBarStyle.Marquee;

                if(wasMarquee)
                    // sets the state to normal (and implicity calls SetStateInTB() )
                    Style = ProgressBarStyle.Blocks;

                // set the progress bar state (Normal, Error, Paused)
                Windows7Taskbar.SendMessage(Handle, 0x410, (int)value, 0);


                if (wasMarquee)
                    // the Taskbar PB value needs to be reset
                    SetValueInTB();
                else
                    // there wasn't a marquee, thus we need to update the taskbar
                    SetStateInTB();
            }
        }

        /// <summary>
        /// Advances the current position of the progress bar by the specified amount.
        /// </summary>
        /// <param name="value">The amount by which to increment the progress bar's current position.</param>
        public new void Increment(int value)
        {
            base.Increment(value);

            // send signal to the taskbar.
            SetValueInTB();
        }

        /// <summary>
        /// Advances the current position of the progress bar by the amount of the System.Windows.Forms.ProgressBar.Step property.
        /// </summary>
        public new void PerformStep()
        {
            base.PerformStep();

            // send signal to the taskbar.
            SetValueInTB();
        }

        private void SetValueInTB()
        {
            if (showInTaskbar)
            {
                ulong maximum = (ulong) (Maximum - Minimum);
                ulong progress = (ulong) (Value - Minimum);

                Windows7Taskbar.SetProgressValue(ownerForm.Handle, progress, maximum);
            }
        }

        private void SetStateInTB()
        {
            if (ownerForm == null) return;

            ThumbnailProgressState thmState = ThumbnailProgressState.Normal;

            if (!showInTaskbar)
                thmState = ThumbnailProgressState.NoProgress;
            else if (Style == ProgressBarStyle.Marquee)
                thmState = ThumbnailProgressState.Indeterminate;
            else if (m_State == ProgressBarState.Error)
                thmState = ThumbnailProgressState.Error;
            else if (m_State == ProgressBarState.Pause)
                thmState = ThumbnailProgressState.Paused;

            Windows7Taskbar.SetProgressState(ownerForm.Handle, thmState);
        }
    }

    /// <summary>
    /// The progress bar state for Windows Vista & 7
    /// </summary>
    public enum ProgressBarState
    {
        /// <summary>
        /// Indicates normal progress
        /// </summary>
        Normal = 1,
        
        /// <summary>
        /// Indicates an error in the progress
        /// </summary>
        Error = 2,
        
        /// <summary>
        /// Indicates paused progress
        /// </summary>
        Pause = 3
    }
}