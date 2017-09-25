using System;
using System.Windows.Forms;

namespace Shared
{
    public class FlickerFreeRichEditTextBox : RichTextBox
    {
        private const short WM_PAINT = 15;

        public bool _Paint = true;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg != 15)
            {
                base.WndProc(ref m);
                return;
            }
            if (this._Paint)
            {
                base.WndProc(ref m);
                return;
            }
            m.Result = IntPtr.Zero;
        }
    }
}
