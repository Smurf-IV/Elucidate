using System;
using ExceptionReporting;
using NLog;

namespace Elucidate
{
    public static class ExceptionHandler
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static void ReportException(Exception ex, string strMessage = null)
        {
            if (strMessage == null)
                Log.Fatal(ex);
            else
                Log.Fatal(ex, strMessage.Trim());
            ExceptionReporter reporter = new ExceptionReporter();
            reporter.Config.AppName = "Elucidate";
            reporter.Config.CompanyName = "Elucidate";
            reporter.Config.TitleText = "Elucidate Error Report";
            reporter.Config.ShowEmailButton = false;
            reporter.Config.ShowSysInfoTab = true;   // all tabs are shown by default
            reporter.Config.ShowFlatButtons = true;  // this particular config is code-only
            reporter.Config.TakeScreenshot = false;  // attached if sending email
            reporter.Show(ex);
        }
    }
}
