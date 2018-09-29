using System;
using System.Diagnostics;
using ExceptionReporting;
using Elucidate.Logging;

namespace Elucidate
{
    public static class ExceptionHandler
    {
        public static void ReportException(Exception ex, string strMessage = null)
        {
            Log.Instance.Fatal(ex,
                strMessage == null
                    ? $"{new StackTrace(ex).GetFrame(0).GetMethod().Name} has thrown: "
                    : strMessage.Trim());
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
