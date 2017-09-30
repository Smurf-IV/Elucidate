// Taken from
// http://www.c-sharpcorner.com/UploadFile/mgold/ColorSyntaxEditor12012005235814PM/ColorSyntaxEditor.aspx

using System;
using System.Windows.Forms;

namespace Shared
{
   /// <summary>
   /// Summary description for FlickerFreeRichEditTextBox - Subclasses the RichTextBox to allow control over flicker
   /// </summary>
   public class FlickerFreeRichEditTextBox : RichTextBox
   {
      const short WM_PAINT = 0x00f;
// ReSharper disable EmptyConstructor
      public FlickerFreeRichEditTextBox()
// ReSharper restore EmptyConstructor
      {
      }
      public bool _Paint = true;
      protected override void WndProc(ref Message m)
      {
         // Code courtesy of Mark Mihevc
         // sometimes we want to eat the paint message so we don't have to see all the
         // flicker from when we select the text to change the color.
         if (m.Msg == WM_PAINT)
         {
            if (_Paint)
               base.WndProc(ref m); // if we decided to paint this control, just call the RichTextBox WndProc
            else
               m.Result = IntPtr.Zero; // not painting, must set this to IntPtr.Zero if not painting therwise serious problems.
         }
         else
            base.WndProc(ref m); // message other than WM_PAINT, jsut do what you normally do.
      }
   }
}