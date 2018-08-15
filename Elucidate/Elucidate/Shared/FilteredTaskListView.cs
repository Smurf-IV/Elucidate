using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.TaskScheduler;

namespace Elucidate.Shared
{
    public class FilteredTaskListView : TaskListView
    {
        public string UniqueValueForConfig { get; set; } = string.Empty;

        protected override void OnTaskSelected(TaskSelectedEventArgs e)
        {
            base.OnTaskSelected(e);
        }

    }
}
