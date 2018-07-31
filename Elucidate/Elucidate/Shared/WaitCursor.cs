using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Elucidate.Shared
{
    /// <summary>
    /// Class to implement correctly restore of the previous cursor, Will default to the Cursors.WaitCursor if none specified
    /// </summary>
    /// <remarks>
    /// Some code ideas stolen from 
    /// - http://stackoverflow.com/questions/302663/cursor-current-vs-this-cursor-in-net-c
    /// - http://wiert.me/2012/01/26/netc-using-idisposable-to-restore-temporary-settrings-example-temporarycursor-class/
    /// </remarks>
    public class WaitCursor : IDisposable
    {
        private Control targetControl;
        //Private storage for replaced cursor. 
        //Assures that nested usage also works
        private readonly Cursor previousCursor;
        private bool applicationWide;
        private bool disposed;

        /// <summary>
        /// A mode to enforce the the hourGlass cursor across the application
        /// </summary>
        /// <param name="applicationWide"></param>
        public WaitCursor(bool applicationWide)
        {
            if (!applicationWide)
            {
                throw new ArgumentException(@"Application wide has to be set to true to use this constructor", nameof(applicationWide));
            }
            SetApplicationWide(true);
        }

        private void SetApplicationWide(bool value)
        {
            applicationWide = value;
            if (value == Application.UseWaitCursor)
            {
                return;
            }

            Application.UseWaitCursor = value;
            IntPtr handle = GetForegroundWindow();
            SendMessage(handle, 0x20, handle, (IntPtr)1);
        }

        /// <summary>
        /// Change Mouse Cursor to Cursors.WaitCursor
        /// </summary>
        public WaitCursor()
           : this(Cursors.WaitCursor)
        {
        }

        /// <summary>
        /// Changes the target control to use the waitCursor
        /// </summary>
        /// <param name="target"></param>
        // ReSharper disable once UnusedMember.Global
        public WaitCursor(Control target)
           : this(target, Cursors.WaitCursor)
        {
            if (null == targetControl)
            {
                throw new ArgumentNullException(nameof(target));
            }
        }

        /// <summary>
        /// Change to a specific cursor
        /// </summary>
        /// <param name="curs"></param>
        // ReSharper disable once MemberCanBePrivate.Global
        public WaitCursor(Cursor curs)
           : this(null, curs)
        {
        }

        /// <summary>
        /// Change the controls cursor until this or the control is destroyed
        /// </summary>
        /// <param name="target">can be null for default Win32.SetCursor usage</param>
        /// <param name="curs"></param>
        public WaitCursor(Control target, Cursor curs)
        {
            if (null == curs)
            {
                throw new ArgumentNullException(nameof(curs));
            }

            this.targetControl = target;
            if (targetControl != null)
            {
                previousCursor = targetControl.Cursor;
                targetControl.Cursor = curs;
                targetControl.HandleDestroyed += targetControl_HandleDestroyed;
            }
            else
            {
                previousCursor = Cursor.Current;
                Cursor.Current = curs;
            }
        }

        // Finalizer
        ~WaitCursor()
        {
            Dispose(false);
        }

        private void targetControl_HandleDestroyed(object sender, EventArgs e)
        {
            if (null == targetControl) return;
            if (!targetControl.RecreatingHandle)
            {
                targetControl = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        //Change the Mouse Pointer back to the previous
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (null != targetControl)
            {
                targetControl.HandleDestroyed -= targetControl_HandleDestroyed;
                //  TODO: Should only be restored if it indeed still has that value
                // if (curs == targetControl.Cursor)
                targetControl.Cursor = previousCursor;
                targetControl = null;
            }
            else if (applicationWide)
            {
                SetApplicationWide(false);
            }
            else
            {
                Cursor.Current = previousCursor;
            }
            disposed = true;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

    }
}
