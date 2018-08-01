using NLog;

namespace Elucidate.Logging
{
    internal static class Log
    {
        public static Logger Instance { get; private set; }

        internal enum LogLevels
        {
            Trace,
            Debug,
            Warn
        }
        static Log()
        {
#if !DEBUG
            DisableLogLevel(LogLevels.Trace);
            DisableLogLevel(LogLevels.Debug);
#endif
            LogManager.ReconfigExistingLoggers();
            Instance = LogManager.GetCurrentClassLogger();
        }
        public static void SetLogLevel(LogLevels logLevel, bool enable)
        {
            LogLevel targetLogLevel;
            switch (logLevel)
            {
                case LogLevels.Trace:
                    targetLogLevel = LogLevel.Trace;
                    break;
                case LogLevels.Debug:
                    targetLogLevel = LogLevel.Debug;
                    break;
                case LogLevels.Warn:
                    targetLogLevel = LogLevel.Warn;
                    break;
                default:
                    return;
            }
            foreach (var rule in LogManager.Configuration.LoggingRules)
            {
                if (enable)
                {
                    rule.EnableLoggingForLevel(targetLogLevel);
                }
                else
                {
                    rule.DisableLoggingForLevel(targetLogLevel);
                }
            }
            LogManager.ReconfigExistingLoggers();
        }
        private static void DisableLogLevel(LogLevels logLevel)
        {
            SetLogLevel(logLevel, false);
        }
        private static void EnableLogLevel(LogLevels logLevel)
        {
            SetLogLevel(logLevel, true);
        }
        public static void Shutdown()
        {
            Instance.Debug("Shutdown logging");
            LogManager.Shutdown(); // Flush and close down internal threads and timers
        }

    }
}
