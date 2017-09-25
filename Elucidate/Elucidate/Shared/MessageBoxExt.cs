using System;
using System.Windows.Forms;

namespace Shared
{
    public static class MessageBoxExt
    {
        public static DialogResult Show(IWin32Window owner, string text)
        {
            string empty = string.Empty;
            return MessageBoxExt.Show(owner, text, empty);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            return MessageBoxExt.Show(owner, text, caption, MessageBoxButtons.OK);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            return MessageBoxExt.Show(owner, text, caption, buttons, MessageBoxIcon.None);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBoxExt.Show(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            MessageBoxExtForm messageBoxExtForm = new MessageBoxExtForm(Application.ProductName, caption, text);
            messageBoxExtForm.SetButtons(buttons);
            messageBoxExtForm.SetIcon(icon);
            messageBoxExtForm.SetDefaultButton(defaultButton);
            messageBoxExtForm.TopMost = true;
            return messageBoxExtForm.ShowDialog(owner);
        }
    }
}
