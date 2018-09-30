using System.Windows.Forms;

namespace Elucidate.HelperClasses
{
    public static class ErrorProviderExtensions
    {
        private static int count;

        public static void SetErrorWithCount(this ErrorProvider ep, Control c, string message)
        {
            if (message == "")
            {
                if (ep.GetError(c) != "")
                {
                    count--;
                }
            }
            else
            if (ep.GetError(c) == "")
            {
                count++;
            }

            ep.SetError(c, message);
        }

        public static bool HasErrors(this ErrorProvider ep)
        {
            return count != 0;
        }

        public static int GetErrorCount(this ErrorProvider ep)
        {
            return count;
        }
    }
}
