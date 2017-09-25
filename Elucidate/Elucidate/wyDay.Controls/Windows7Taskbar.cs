using System;
using System.Runtime.InteropServices;

namespace wyDay.Controls
{
    public static class Windows7Taskbar
    {
        private static ITaskbarList3 taskbarList;

        private static readonly OperatingSystem osInfo = Environment.OSVersion;

        internal static ITaskbarList3 TaskbarList
        {
            get
            {
                if (Windows7Taskbar.taskbarList == null)
                {
                    lock (typeof(Windows7Taskbar))
                    {
                        if (Windows7Taskbar.taskbarList == null)
                        {
                            Windows7Taskbar.taskbarList = (ITaskbarList3)new CTaskbarList();
                            Windows7Taskbar.taskbarList.HrInit();
                        }
                    }
                }
                return Windows7Taskbar.taskbarList;
            }
        }

        internal static bool Windows7OrGreater
        {
            get
            {
                return (Windows7Taskbar.osInfo.Version.Major == 6 && Windows7Taskbar.osInfo.Version.Minor >= 1) || Windows7Taskbar.osInfo.Version.Major > 6;
            }
        }

        public static void SetProgressState(IntPtr hwnd, ThumbnailProgressState state)
        {
            if (Windows7Taskbar.Windows7OrGreater)
            {
                Windows7Taskbar.TaskbarList.SetProgressState(hwnd, state);
            }
        }

        public static void SetProgressValue(IntPtr hwnd, ulong current, ulong maximum)
        {
            if (Windows7Taskbar.Windows7OrGreater)
            {
                Windows7Taskbar.TaskbarList.SetProgressValue(hwnd, current, maximum);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
