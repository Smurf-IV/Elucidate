using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// ReSharper disable MemberCanBePrivate.Global

// ReSharper disable UnusedMember.Global

namespace Elucidate.Controls;

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

    private readonly ConcurrentQueue<LogString> pendingLogMessages = new();
    private bool alreadyDequeing;

    public ListBoxLog(ListBox listBox, int maxLinesInListbox = DEFAULT_MAX_LINES_IN_LISTBOX, int defaultUpdateFrequencyms = DEFAULT_UPDATE_FREQUENCY_MS)
    {
        disposed = false;

        listBoxInt = listBox;
        maxEntriesInListBox = maxLinesInListbox;

        Paused = false;

        listBoxInt.SelectionMode = SelectionMode.MultiExtended;
        // Display a horizontal scroll bar.
        listBoxInt.HorizontalScrollbar = true;
        listBoxInt.DrawMode = DrawMode.OwnerDrawVariable;

        listBoxInt.HandleCreated += OnHandleCreated;
        listBoxInt.HandleDestroyed += OnHandleDestroyed;
        listBoxInt.DrawItem += DrawItemHandler;
        listBoxInt.KeyDown += KeyDownHandler;
        listBoxInt.MeasureItem += MeasureItem;

        var menuItems = new[] { new MenuItem("Copy", CopyMenuOnClickHandler) };
        listBoxInt.ContextMenu = new ContextMenu(menuItems);
        listBoxInt.ContextMenu.Popup += CopyMenuPopupHandler;

        timer1 = new Timer
        {
            Enabled = listBox.IsHandleCreated,
            Interval = defaultUpdateFrequencyms,
        };
        timer1.Tick += timer1_Tick;

    }

    public void LogMethod(string levelUppercase, string message)
    {
        pendingLogMessages.Enqueue(new LogString
        {
            LevelUppercase = levelUppercase,
            Message = message
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
            if (((ListBox)sender).Items[e.Index] is not LogString logEvent)
            {
                logEvent = new LogString
                {
                    LevelUppercase = @"FATAL",
                    Message = ((ListBox)sender).Items[e.Index].ToString()
                };
            }

            Size sizeF = TextRenderer.MeasureText(e.Graphics, logEvent.Message, listBoxInt.Font);

            e.ItemHeight = sizeF.Height + 2;
            if (listBoxInt.HorizontalExtent < sizeF.Width)
            {
                listBoxInt.HorizontalExtent = sizeF.Width + 2;
            }
        }
    }


    private void DrawItemHandler(object sender, DrawItemEventArgs e)
    {
        if (e.Index >= 0)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            // SafeGuard against wrong configuration of list box
            if (((ListBox)sender).Items[e.Index] is not LogString logEvent)
            {
                logEvent = new LogString
                {
                    LevelUppercase = @"FATAL",
                    Message = ((ListBox)sender).Items[e.Index].ToString()
                };
            }

            Color color = logEvent.LevelUppercase switch
            {
                @"FATAL" => Color.White,
                @"ERROR" => Color.Red,
                @"WARN" => Color.Goldenrod,
                @"INFO" => Color.Black,
                @"DEBUG" => Color.Gray,
                @"TRACE" => Color.DarkGray,
                _ => Color.Black
            };

            if (logEvent.LevelUppercase == @"FATAL")
            {
                e.Graphics.FillRectangle(Brushes.Red, e.Bounds);
            }
            // https://blogs.msdn.microsoft.com/cjacks/2006/05/19/gdi-vs-gdi-text-rendering-performance/
            TextRenderer.DrawText(e.Graphics, logEvent.Message, listBoxInt.Font, new Point(0, e.Bounds.Y + 2), color, TextFormatFlags.ExternalLeading);
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
                for (var i = listBoxInt.Items.Count - 1; i >= 0; i--)
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
            if (alreadyDequeing
                || pendingLogMessages.IsEmpty)
            {
                return;
            }

            // Now lock in case the timer is overlapping !
            alreadyDequeing = true;

            listBoxInt.BeginInvoke((MethodInvoker)delegate
            {
                //some stuffs for best performance
                listBoxInt.BeginUpdate();

                if (listBoxInt.Items.Count > maxEntriesInListBox)
                {
                    var existingLogs = new object[listBoxInt.Items.Count];
                    listBoxInt.Items.CopyTo(existingLogs, 0);
                    listBoxInt.Items.Clear();
                    listBoxInt.Items.AddRange(existingLogs.Skip(maxEntriesInListBox / 2).ToArray());
                }

                // find the style to use
                while (pendingLogMessages.TryDequeue(out LogString log))
                {
                    listBoxInt.Items.Add(log);
                }

                if (!Paused)
                {
                    listBoxInt.TopIndex = listBoxInt.Items.Count - 1;
                }

                listBoxInt.EndUpdate();
                alreadyDequeing = false;
            });
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
            var selectedItemsAsRtfText = new StringBuilder();
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
                selectedItemsAsRtfText.AppendLine(logEvent.Message);
            }

            //selectedItemsAsRtfText.AppendLine(@"}");
            //Clipboard.SetData(DataFormats.Rtf, selectedItemsAsRtfText.ToString());
            Clipboard.SetData(DataFormats.UnicodeText, selectedItemsAsRtfText.ToString());
        }
    }


    private void Dispose(bool _)
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