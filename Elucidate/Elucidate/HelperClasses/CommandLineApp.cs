using System.Diagnostics;
using System.IO;
using Elucidate.Logging;

namespace Elucidate.HelperClasses
{
    public class CommandLineApp
    {
        // ReSharper disable once UnusedMember.Global
        public void RunWithNoLogCapture(string args, string appPath)
        {
            Log.Instance.Info("Running without Capture mode");
            Log.Instance.Info("Starting minimised {0} {1}", appPath, args);
            Log.Instance.Info("Working...");
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "CMD.exe",
                Arguments = $" /C \"{appPath} {args}\"",
                WorkingDirectory = $"{Path.GetDirectoryName(Properties.Settings.Default.SnapRAIDFileLocation)}",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Minimized,
                ErrorDialog = true
            };
            Process process = Process.Start(startInfo);
            if (process != null) Log.Instance.Info("Process is running PID[{0}]", process.Id);
        }
    }
}
