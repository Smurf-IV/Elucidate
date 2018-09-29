using System;

namespace Elucidate.Threads
{
    public class RecoverThreadClass : IDisposable
    {
        public delegate void AddNodeHandler(string name);
        public event AddNodeHandler OnAddNodeEvt;

        public void AddNode(string name)
        {
            TriggerEvent(name);
        }

        private void TriggerEvent(string name)
        {
            OnAddNodeEvt?.Invoke(name);
        }

        #region Dispose
        public void Dispose() => GC.SuppressFinalize(this);
        ~RecoverThreadClass() => Dispose();
        #endregion

    }
}
