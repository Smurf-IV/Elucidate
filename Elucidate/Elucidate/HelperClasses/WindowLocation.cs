// Code ideas stolen and adapted from
// http://www.codeproject.com/Articles/25510/Restore-Form-Position-and-Size-in-C

using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Elucidate
{
   internal static class WindowLocation
   {
      public static void GeometryFromString(string thisWindowGeometry, Form formIn)
      {
         if (string.IsNullOrEmpty(thisWindowGeometry))
         {
            return;
         }
         string[] numbers = thisWindowGeometry.Split('|');
         string windowString = numbers[4];
         switch (windowString)
         {
            case "Normal":
               {
                  Point windowPoint = new Point(int.Parse(numbers[0], CultureInfo.InvariantCulture),
                                                int.Parse(numbers[1], CultureInfo.InvariantCulture));
                  Size windowSize = new Size(int.Parse(numbers[2], CultureInfo.InvariantCulture),
                                             int.Parse(numbers[3], CultureInfo.InvariantCulture));

                  bool locOkay = GeometryIsBizarreLocation(windowPoint, windowSize);
                  bool sizeOkay = GeometryIsBizarreSize(windowSize);

                  if (locOkay && sizeOkay)
                  {
                     formIn.Location = windowPoint;
                     formIn.Size = windowSize;
                     formIn.StartPosition = FormStartPosition.Manual;
                     formIn.WindowState = FormWindowState.Normal;
                  }
                  else if (sizeOkay)
                  {
                     formIn.Size = windowSize;
                  }
               }
               break;

            case "Maximized":
               formIn.Location = new Point(100, 100);
               formIn.StartPosition = FormStartPosition.Manual;
               formIn.WindowState = FormWindowState.Maximized;
               break;
         }
      }

      private static bool GeometryIsBizarreLocation(Point loc, Size size)
      {
         bool locOkay;
         if (loc.X < 0 || loc.Y < 0)
         {
            locOkay = false;
         }
         else if (loc.X + size.Width > Screen.PrimaryScreen.WorkingArea.Width)
         {
            locOkay = false;
         }
         else if (loc.Y + size.Height > Screen.PrimaryScreen.WorkingArea.Height)
         {
            locOkay = false;
         }
         else
         {
            locOkay = true;
         }
         return locOkay;
      }

      private static bool GeometryIsBizarreSize(Size size)
      {
         return (size.Height <= Screen.PrimaryScreen.WorkingArea.Height &&
             size.Width <= Screen.PrimaryScreen.WorkingArea.Width);
      }

      public static string GeometryToString(Form mainForm)
      {
         // Use internal string allocated buffer to make the final string, rather than individual string concats.
         return string.Join("|", new string[] {mainForm.Location.X.ToString(CultureInfo.InvariantCulture),
            mainForm.Location.Y.ToString(CultureInfo.InvariantCulture),
            mainForm.Size.Width.ToString(CultureInfo.InvariantCulture),
             mainForm.Size.Height.ToString(CultureInfo.InvariantCulture),
             mainForm.WindowState.ToString()
         });
      }
   }
}