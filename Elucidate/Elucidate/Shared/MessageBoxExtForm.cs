using System.Drawing;
using System.Windows.Forms;

// ReSharper disable UnusedMember.Global
// ReSharper disable RedundantCast
// ReSharper disable MemberCanBePrivate.Global
namespace Elucidate.Shared
{
   /// <summary>
   /// Class of MessageBox
   /// </summary>
   public static class MessageBoxExt
   {
      public static DialogResult Show(IWin32Window owner, string text)
      {
         string caption = string.Empty;
         return Show(owner, text, caption);
      }

      public static DialogResult Show(IWin32Window owner, string text, string caption)
      {
         const MessageBoxButtons BUTTONS = MessageBoxButtons.OK;
         return Show(owner, text, caption, BUTTONS);
      }

      public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
      {
         const MessageBoxIcon ICON = MessageBoxIcon.None;
         return Show(owner, text, caption, buttons, ICON);
      }

      public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
      {
         const MessageBoxDefaultButton DEFAULT_BUTTON = MessageBoxDefaultButton.Button1;
         return Show(owner, text, caption, buttons, icon, DEFAULT_BUTTON);
      }

      private static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
      {
         MessageBoxExtForm form = new MessageBoxExtForm(Application.ProductName, caption, text );

         form.SetButtons(buttons);
         form.SetIcon(icon);
         form.SetDefaultButton(defaultButton);
         form.TopMost = true;
         return form.ShowDialog(owner);
      }
   }

   internal partial class MessageBoxExtForm : Form
   {
      private MessageBoxButtons mMessageBoxButtons;

      public MessageBoxExtForm( string caption, string task, string information)
      {
         InitializeComponent();
         base.Text = caption;
         lblTask.Text = task;
         lblInformation.Text = information;
         StartPosition = FormStartPosition.CenterParent;
      }


      internal void SetButtons(MessageBoxButtons buttons)
      {
         mMessageBoxButtons = buttons;

         btnAbort.Visible = false;
         btnCancel.Visible = false;
         btnIgnore.Visible = false;
         btnNo.Visible = false;
         btnOK.Visible = false;
         btnRetry.Visible = false;
         btnYes.Visible = false;

         switch (buttons)
         {
            case MessageBoxButtons.AbortRetryIgnore:
               btnAbort.Visible = true;
               btnRetry.Visible = true;
               btnIgnore.Visible = true;
               break;

            case MessageBoxButtons.OKCancel:
               btnOK.Visible = true;
               btnCancel.Visible = true;
               break;

            case MessageBoxButtons.RetryCancel:
               btnRetry.Visible = true;
               btnCancel.Visible = true;
               break;

            case MessageBoxButtons.YesNo:
               btnYes.Visible = true;
               btnNo.Visible = true;
               break;

            case MessageBoxButtons.YesNoCancel:
               btnYes.Visible = true;
               btnNo.Visible = true;
               btnCancel.Visible = true;
               break;

            default:
            //case MessageBoxButtons.OK:
               btnOK.Visible = true;
               break;
         }
      }

      internal void SetIcon(MessageBoxIcon icon)
      {
         Icon iconToUse;
         switch (icon)
         {
            default:
               // case MessageBoxIcon.None:
               iconToUse = null;
               boxIcon.Visible = false;
               break;
            case MessageBoxIcon.Hand:
               iconToUse = SystemIcons.Hand;
               break;
            case MessageBoxIcon.Question:
               iconToUse = SystemIcons.Question;
               break;
            case MessageBoxIcon.Exclamation:
               iconToUse = SystemIcons.Exclamation;
               break;
            case MessageBoxIcon.Asterisk:
               iconToUse = SystemIcons.Asterisk;
               break;
         }
         if (iconToUse != null)
         {
            boxIcon.Image = new Icon(iconToUse, 48, 48).ToBitmap();
         }
      }

      internal void SetDefaultButton(MessageBoxDefaultButton defaultButton)
      {
         switch (defaultButton)
         {
            case MessageBoxDefaultButton.Button1:
               switch (mMessageBoxButtons)
               {
                  case MessageBoxButtons.AbortRetryIgnore:
                     btnAbort.Focus();
                     break;
                  case MessageBoxButtons.OKCancel:
                     btnOK.Focus();
                     break;
                  case MessageBoxButtons.RetryCancel:
                     btnRetry.Focus();
                     break;
                  case MessageBoxButtons.YesNo:
                     btnYes.Focus();
                     break;
                  case MessageBoxButtons.YesNoCancel:
                     btnYes.Focus();
                     break;
                  case MessageBoxButtons.OK:
                     btnOK.Focus();
                     break;
               }
               break;
            case MessageBoxDefaultButton.Button2:
               switch (mMessageBoxButtons)
               {
                  case MessageBoxButtons.AbortRetryIgnore:
                     btnRetry.Focus();
                     break;
                  case MessageBoxButtons.OKCancel:
                     btnCancel.Focus();
                     break;
                  case MessageBoxButtons.RetryCancel:
                     btnCancel.Focus();
                     break;
                  case MessageBoxButtons.YesNo:
                     btnNo.Focus();
                     break;
                  case MessageBoxButtons.YesNoCancel:
                     btnNo.Focus();
                     break;
               }
               break;
            case MessageBoxDefaultButton.Button3:
               switch (mMessageBoxButtons)
               {
                  case MessageBoxButtons.AbortRetryIgnore:
                     btnIgnore.Focus();
                     break;
                  case MessageBoxButtons.YesNoCancel:
                     btnCancel.Focus();
                     break;
               }
               break;
         }
      }

   }
}
// ReSharper restore MemberCanBePrivate.Global
// ReSharper restore RedundantCast
// ReSharper restore UnusedMember.Global
