using System;

namespace Elucidate.Threads
{
    public class LogThreadClass : IDisposable
    {
        public delegate void ProcessLogHandler();
        public event ProcessLogHandler OnProcessLogEvt;

        public void ProcessLog()
        {
            TriggerEventProcessLog();
        }

        private void TriggerEventProcessLog()
        {
            OnProcessLogEvt?.Invoke();
        }



        public delegate void LogEntryHandler(string message);
        public event LogEntryHandler OnLogEntryEvt;

        public void LogEntry(string message)
        {
            TriggerEvent(message);
        }

        private void TriggerEvent(string message)
        {
            OnLogEntryEvt?.Invoke(message);
        }

        #region Dispose
        public void Dispose() => GC.SuppressFinalize(this);
        ~LogThreadClass() => Dispose();
        #endregion
    }
}
