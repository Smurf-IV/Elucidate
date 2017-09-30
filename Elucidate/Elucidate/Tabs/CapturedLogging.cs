#region Copyright (C)

// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="CapturedLogging.cs" company="Smurf-IV">
//
//  Copyright (C) 2015 Simon Coghlan (Aka Smurf-IV)
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 2 of the License, or
//   any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see http://www.gnu.org/licenses/.
//  </copyright>
//  <summary>
//  Url: https://github.com/Smurf-IV/Elucidate
//  Email: https://github.com/Smurf-IV
//  </summary>
// --------------------------------------------------------------------------------------------------------------------

#endregion Copyright (C)

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Elucidate
{
    public partial class Elucidate
    {
        private void AddThreadingCallbacks()
        {
            // Add threading callbacks
            actionWorker.DoWork += actionWorker_DoWork;
            actionWorker.ProgressChanged += actionWorker_ProgressChanged;
            actionWorker.RunWorkerCompleted += actionWorker_RunWorkerCompleted;
            comboBox1.Text = "Stopped";
            comboBox1.Enabled = false;
            timer1.Enabled = true;
        }

        private void deleteContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void copySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataObject dto = new DataObject();
            if (textBox1.SelectionLength <= 1)
            {
                textBox1.SelectAll();
            }
            dto.SetText(textBox1.SelectedRtf, TextDataFormat.Rtf);
            dto.SetText(textBox1.SelectedText, TextDataFormat.UnicodeText);
            Clipboard.Clear();
            Clipboard.SetDataObject(dto);
        }

        private void Elucidate_KeyDown(object sender, KeyEventArgs e)
        {
            // The realtime tab + menu, might not have focus
            if (e.Control
                && e.KeyCode == Keys.C)
            {
                copySelectedToolStripMenuItem_Click(sender, e);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!Logs.Any())
                {
                    return;
                }
                // Now lock in case the timer is overlapping !
                lock (this)
                {
                    textBox1._Paint = false; // turn off flag to ignore WM_PAINT messages
                    if (textBox1.Lines.Length > Properties.Settings.Default.MaxNumberOfRealTimeLines)
                    {
                        //textBox1.SelectionStart = 0;
                        //textBox1.SelectionLength = textBox1.GetFirstCharIndexFromLine(Properties.Settings.Default.MaxNumberOfRealTimeLines - 10);
                        //textBox1.SelectedText = string.Empty;
                        // The above makes it beep as well !!
                        textBox1.Clear();
                    }
                    //read out of the file until the EOF
                    while (Logs.Any())
                    {
                        int textLength = textBox1.TextLength;
                        textBox1.Select(textLength, 0);
                        LogString log = Logs.Dequeue();
                        switch (log.LevelUppercase)
                        {
                            case "FATAL":
                                textBox1.SelectionColor = Color.DarkViolet;
                                break;

                            case "ERROR":
                                textBox1.SelectionColor = Color.Red;
                                break;

                            case "WARN":
                                textBox1.SelectionColor = Color.RoyalBlue;
                                break;

                            case "INFO":
                                textBox1.SelectionColor = Color.Black;
                                break;

                            case "DEBUG":
                                textBox1.SelectionColor = Color.DarkGray;
                                break;

                            case "TRACE":
                                textBox1.SelectionColor = Color.DimGray;
                                break;

                            default:
                                // Leave it as is
                                break;
                        }
                        textBox1.AppendText(log.Message + Environment.NewLine);
                    }
                }
            }
            catch { }
            textBox1._Paint = true;// restore flag so we can paint the control
        }

        private class LogString
        {
            public string LevelUppercase;
            public string Message;
        };

        static private readonly Queue<LogString> Logs = new Queue<LogString>();

        // ReSharper disable UnusedMember.Global
        // This is used by the logging to force all to the output window
        public static void LogMethod(string levelUppercase, string message)
        {
            Logs.Enqueue(new LogString
            {
                LevelUppercase = levelUppercase,
                Message = message
            });
        }


    }
}
