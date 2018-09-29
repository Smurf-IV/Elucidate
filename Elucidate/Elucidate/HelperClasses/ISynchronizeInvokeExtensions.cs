using System;

namespace Elucidate.HelperClasses
{
    using System.ComponentModel;
    // ReSharper disable once InconsistentNaming
    public static class ISynchronizeInvokeExtensions
    {
        public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
        {
            // ex: this.InvokeEx(f => f.listView1.Items.Clear());
            // ex: listView1.InvokeEx(lv => lv.Items.Clear());
            if (@this.InvokeRequired)
            {
                @this.Invoke(action, new object[] { @this });
            }
            else
            {
                action(@this);
            }
        }
    }
}
