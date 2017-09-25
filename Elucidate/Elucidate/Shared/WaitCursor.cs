using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Shared
{
    public class WaitCursor : IDisposable
    {
        private Control targetControl;

        private readonly Cursor previousCursor;

        private bool applicationWide;

        private bool disposed;

        public WaitCursor(bool applicationWide)
        {
            if (!applicationWide)
            {
                throw new ArgumentException("Application wide has to be set to true to use this constructor", "applicationWide");
            }
            this.SetApplicationWide(true);
        }

        protected void SetApplicationWide(bool value)
        {
            this.applicationWide = value;
            if (value == Application.UseWaitCursor)
            {
                return;
            }
            Application.UseWaitCursor = value;
            IntPtr foregroundWindow = WaitCursor.GetForegroundWindow();
            WaitCursor.SendMessage(foregroundWindow, 32, foregroundWindow, (IntPtr)1);
        }

        public WaitCursor() : this(Cursors.WaitCursor)
        {
        }

        public WaitCursor(Control target) : this(target, Cursors.WaitCursor)
        {
            if (this.targetControl == null)
            {
                throw new ArgumentNullException("target");
            }
        }

        public WaitCursor(Cursor curs) : this(null, curs)
        {
        }

        public WaitCursor(Control target, Cursor curs)
        {
            if (null == curs)
            {
                throw new ArgumentNullException("curs");
            }
            this.targetControl = target;
            if (this.targetControl != null)
            {
                this.previousCursor = this.targetControl.Cursor;
                this.targetControl.Cursor = curs;
                this.targetControl.HandleDestroyed += new EventHandler(this.targetControl_HandleDestroyed);
                return;
            }
            this.previousCursor = Cursor.Current;
            Cursor.Current = curs;
        }

        ~WaitCursor()
        {
            this.Dispose(false);
        }

        private void targetControl_HandleDestroyed(object sender, EventArgs e)
        {
            if (this.targetControl != null && !this.targetControl.RecreatingHandle)
            {
                this.targetControl = null;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (this.targetControl != null)
                {
                    this.targetControl.HandleDestroyed -= new EventHandler(this.targetControl_HandleDestroyed);
                    this.targetControl.Cursor = this.previousCursor;
                    this.targetControl = null;
                }
                else if (this.applicationWide)
                {
                    this.SetApplicationWide(false);
                }
                else
                {
                    Cursor.Current = this.previousCursor;
                }
                this.disposed = true;
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}
