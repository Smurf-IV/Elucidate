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
        private Thread workerThread;

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            workerThread = Thread.CurrentThread;
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
            if (workerThread == null)
            {
                return;
            }

            workerThread.Abort();
            workerThread = null;
        }
    }
}
