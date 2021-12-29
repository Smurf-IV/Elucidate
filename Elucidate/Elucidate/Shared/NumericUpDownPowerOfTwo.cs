using System;
using System.Windows.Forms;

namespace Elucidate.Shared
{
    public class NumericUpDownPowerOfTwo : NumericUpDown
    {
        public override void UpButton()
        {
            try
            {
                base.UpButton();
                Value *= 2;
            }
            catch (ArgumentOutOfRangeException)
            {
                Value = Maximum;
            }
        }
        public override void DownButton()
        {
            try
            {
                base.DownButton();
                Value /= 2;
            }
            catch (ArgumentOutOfRangeException)
            {
                Value = Minimum;
            }
        }
    }
}
