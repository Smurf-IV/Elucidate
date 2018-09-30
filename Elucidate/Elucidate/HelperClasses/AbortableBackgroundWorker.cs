using System.ComponentModel;
using System.Threading;

namespace Elucidate.HelperClasses
{
    /// <summary>
    /// Description of AbortableBackgroundWorker.
    /// borrowed from http://stackoverflow.com/questions/800767/how-to-kill-background-worker-completely 
    /// </summary>
    public class AbortableBackgroundWorker : BackgroundWorker
    {
        private Thread _workerThread;

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            _workerThread = Thread.CurrentThread;
            try
            {
                base.OnDoWork(e);
            }
            catch (ThreadAbortException)
            {
                e.Cancel = true; //We must set Cancel property to true!
                Thread.ResetAbort(); //Prevents ThreadAbortException propagation
            }
        }

        public void Abort()
        {
            if (_workerThread == null)
            {
                return;
            }

            _workerThread.Abort();
            _workerThread = null;
        }
    }
}
