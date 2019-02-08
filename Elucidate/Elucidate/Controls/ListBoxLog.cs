using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// ReSharper disable MemberCanBePrivate.Global

// ReSharper disable UnusedMember.Global

namespace Elucidate.Controls
{
    /// <summary>
    /// Stolen from
    /// https://stackoverflow.com/questions/2196097/elegant-log-window-in-winforms-c-sharp
    /// and then
    /// - reformatted to make it work with NLog style levels
    /// - Made to work for multi-line
    /// - Updates via a timer
    /// </summary>
    public sealed class ListBoxLog : IDisposable
    {
        private const int DEFAULT_MAX_LINES_IN_LISTBOX = 2000;
        private const int DEFAULT_UPDATE_FREQUENCY_MS = 250;

        private bool disposed;
        private ListBox listBoxInt;
        private readonly int maxEntriesInListBox;
        private readonly Timer timer1;

        private class LogString
        {
            public string LevelUppercase;
            public string Message;
        };

        private readonly ConcurrentQueue<LogString> pendingLogMessages = new ConcurrentQueue<LogString>();
        private bool alreadyDequing;

        public ListBoxLog(ListBox listBox, int maxLinesInListbox = DEFAULT_MAX_LINES_IN_LISTBOX, int defaultUpdateFrequencyms = DEFAULT_UPDATE_FREQUENCY_MS)
        {
            disposed = false;
            timer1 = new Timer
            {
                Enabled = listBox.IsHandleCreated,
                Interval = defaultUpdateFrequencyms,
            };
            timer1.Tick += timer1_Tick;

            listBoxInt = listBox;
            maxEntriesInListBox = maxLinesInListbox;

            Paused = false;

            listBoxInt.SelectionMode = SelectionMode.MultiExtended;

            listBoxInt.HandleCreated += OnHandleCreated;
            listBoxInt.HandleDestroyed += OnHandleDestroyed;
            listBoxInt.DrawItem += DrawItemHandler;
            listBoxInt.KeyDown += KeyDownHandler;
            listBoxInt.MeasureItem += MeasureItem;
            listBoxInt.DrawMode = DrawMode.OwnerDrawVariable;

            MenuItem[] menuItems = new[] { new MenuItem("Copy", CopyMenuOnClickHandler) };
            listBoxInt.ContextMenu = new ContextMenu(menuItems);
            listBoxInt.ContextMenu.Popup += CopyMenuPopupHandler;

        }

        public void LogMethod(string levelUppercase, string message)
        {
            pendingLogMessages.Enqueue(new LogString
            {
                LevelUppercase = levelUppercase,
                Message = message + Environment.NewLine
            });
        }


        public bool Paused { get; set; }

        ~ListBoxLog()
        {
            if (!disposed)
            {
                Dispose(false);
                disposed = true;
            }
        }

        public void Dispose()
        {
            if (!disposed)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
                disposed = true;
            }
        }

        private void OnHandleCreated(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void OnHandleDestroyed(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                if (!(((ListBox)sender).Items[e.Index] is LogString logEvent))
                {
                    logEvent = new LogString
                    {
                        LevelUppercase = @"FATAL",
                        Message = ((ListBox)sender).Items[e.Index].ToString()
                    };
                }

                e.ItemHeight = (int) (e.Graphics.MeasureString(logEvent.Message, listBoxInt.Font).Height + 2);
            }
        }


            private void DrawItemHandler(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();

                // SafeGuard against wrong configuration of list box
                if (!(((ListBox)sender).Items[e.Index] is LogString logEvent))
                {
                    logEvent = new LogString
                    {
                        LevelUppercase = @"FATAL",
                        Message = ((ListBox) sender).Items[e.Index].ToString()
                    };
                }

                Brush color;
                switch (logEvent.LevelUppercase)
                {
                    case @"FATAL":
                        color = Brushes.White;
                        break;
                    case @"ERROR":
                        color = Brushes.Red;
                        break;
                    case @"WARNING":
                        color = Brushes.Goldenrod;
                        break;
                    case @"INFO":
                        color = Brushes.Black;
                        break;
                    case @"DEBUG":
                        color = Brushes.Gray;
                        break;
                        case @"TRACE":
                        color = Brushes.DarkGray;
                        break;
                    default:
                        color = Brushes.Black;
                        break;
                }

                if (logEvent.LevelUppercase == @"FATAL")
                {
                    e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
                }

                e.Graphics.DrawString(logEvent.Message, listBoxInt.Font, color, e.Bounds);
            }
        }

        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.C)
                {
                    CopyToClipboard();
                }
                else if (e.KeyCode == Keys.C)
                {
                    listBoxInt.BeginUpdate();
                    for (int i = listBoxInt.Items.Count - 1; i >= 0; i--)
                    {
                        listBoxInt.SetSelected(i, true);
                    }
                    listBoxInt.EndUpdate();
                }
            }
        }

        private void CopyMenuOnClickHandler(object sender, EventArgs e)
        {
            CopyToClipboard();
        }

        private void CopyMenuPopupHandler(object sender, EventArgs e)
        {
            if (sender is ContextMenu menu)
            {
                menu.MenuItems[0].Enabled = (listBoxInt.SelectedItems.Count > 0);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (alreadyDequing
                || pendingLogMessages.IsEmpty)
                {
                    return;
                }

                alreadyDequing = true;
                // Now lock in case the timer is overlapping !
                //BeginInvoke((MethodInvoker)delegate
                {
                    //some stuffs for best performance
                    listBoxInt.BeginUpdate();

                    // find the style to use
                    while (pendingLogMessages.TryDequeue(out LogString log))
                    {
                        listBoxInt.Items.Add(log);
                    }

                    if (listBoxInt.Items.Count > maxEntriesInListBox)
                    {
                        listBoxInt.Items.RemoveAt(0);
                    }

                    if (!Paused)
                    {
                        listBoxInt.TopIndex = listBoxInt.Items.Count - 1;
                    }

                    listBoxInt.EndUpdate();
                    //}
                    alreadyDequing = false;
                }
                //);
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
            }
        }

private void CopyToClipboard()
        {
            if (listBoxInt.SelectedItems.Count > 0)
            {
                StringBuilder selectedItemsAsRtfText = new StringBuilder();
                //selectedItemsAsRtfText.AppendLine(@"{\rtf1\ansi\deff0{\fonttbl{\f0\fcharset0 Courier;}}");
                //selectedItemsAsRtfText.AppendLine(
                //    @"{\colortbl;\red255\green255\blue255;\red255\green0\blue0;\red218\green165\blue32;\red0\green128\blue0;\red0\green0\blue255;\red0\green0\blue0}");
                foreach (LogString logEvent in listBoxInt.SelectedItems)
                {
                    //selectedItemsAsRtfText.AppendFormat(@"{{\f0\fs16\chshdng0\chcbpat{0}\cb{0}\cf{1} ",
                    //    (logEvent.LevelUppercase == @"FATAL") ? 2 : 1,
                    //    (logEvent.LevelUppercase == @"FATAL") ? 1 :
                    //    ((int)logEvent.Level > 5) ? 6 : ((int)logEvent.Level) + 1);
                    //selectedItemsAsRtfText.Append(FormatALogEventMessage(logEvent, messageFormat));
                    //selectedItemsAsRtfText.AppendLine(@"\par}");
                    selectedItemsAsRtfText.Append(logEvent.Message);
                }

                //selectedItemsAsRtfText.AppendLine(@"}");
                //Clipboard.SetData(DataFormats.Rtf, selectedItemsAsRtfText.ToString());
                Clipboard.SetData(DataFormats.UnicodeText, selectedItemsAsRtfText.ToString());
            }

        }


        private void Dispose(bool disposing)
        {
            if (listBoxInt != null)
            {
                timer1.Enabled = false;

                listBoxInt.HandleCreated -= OnHandleCreated;
                listBoxInt.HandleCreated -= OnHandleDestroyed;
                listBoxInt.DrawItem -= DrawItemHandler;
                listBoxInt.KeyDown -= KeyDownHandler;

                listBoxInt.ContextMenu.MenuItems.Clear();
                listBoxInt.ContextMenu.Popup -= CopyMenuPopupHandler;
                listBoxInt.ContextMenu = null;

                listBoxInt.Items.Clear();
                listBoxInt.DrawMode = DrawMode.Normal;
                listBoxInt = null;
            }
        }
    }
}
