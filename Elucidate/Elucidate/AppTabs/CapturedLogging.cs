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
using Elucidate.Logging;

namespace Elucidate
{
    public partial class ElucidateForm
    {
        private void AddThreadingCallbacks()
        {
            // Add threading callbacks
            actionWorker.DoWork += actionWorker_DoWork;
            actionWorker.ProgressChanged += actionWorker_ProgressChanged;
            actionWorker.RunWorkerCompleted += actionWorker_RunWorkerCompleted;
            comboBox1.Text = @"Stopped";
            comboBox1.Enabled = false;
            timer1.Enabled = true;
        }

        private void DeleteContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxLogging1.Clear();
        }

        private void CopySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataObject dto = new DataObject();
            if (textBoxLogging1.SelectionLength <= 1)
            {
                textBoxLogging1.SelectAll();
            }
            dto.SetText(textBoxLogging1.SelectedRtf, TextDataFormat.Rtf);
            dto.SetText(textBoxLogging1.SelectedText, TextDataFormat.UnicodeText);
            Clipboard.Clear();
            Clipboard.SetDataObject(dto);
        }

        private void Elucidate_KeyDown(object sender, KeyEventArgs e)
        {
            // The realtime tab + menu, might not have focus
            if (e.Control
                && e.KeyCode == Keys.C)
            {
                CopySelectedToolStripMenuItem_Click(sender, e);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!LogQueue.Any())
                {
                    //Thread.Sleep(250);
                    return;
                }
                // Now lock in case the timer is overlapping !
                lock (this)
                {
                    textBoxLogging1._Paint = false; // turn off flag to ignore WM_PAINT messages
                    if (textBoxLogging1.Lines.Length > Properties.Settings.Default.MaxNumberOfRealTimeLines)
                    {
                        //textBox1.SelectionStart = 0;
                        //textBox1.SelectionLength = textBox1.GetFirstCharIndexFromLine(Properties.Settings.Default.MaxNumberOfRealTimeLines - 10);
                        //textBox1.SelectedText = string.Empty;
                        // The above makes it beep as well !!
                        textBoxLogging1.Clear();
                    }
                    //read out of the file until the EOF
                    while (LogQueue.Any())
                    {
                        LogString log = LogQueue.Dequeue();
                        switch (log.LevelUppercase)
                        {
                            case "FATAL":
                                textBoxLogging1.SelectionColor = Color.DarkViolet;
                                break;

                            case "ERROR":
                                textBoxLogging1.SelectionColor = Color.Red;
                                break;

                            case "WARN":
                                textBoxLogging1.SelectionColor = Color.RoyalBlue;
                                break;

                            case "INFO":
                                textBoxLogging1.SelectionColor = Color.Black;
                                break;

                            case "DEBUG":
                                textBoxLogging1.SelectionColor = Color.DarkGray;
                                break;

                            case "TRACE":
                                textBoxLogging1.SelectionColor = Color.DimGray;
                                break;

                            default:
                                // Leave it as is
                                break;
                        }
                        textBoxLogging1.AppendText(log.Message + Environment.NewLine);
                        textBoxLogging1.ScrollToCaret();
                    }
                    // check if our textbox is getting too full
                    int textLength = textBoxLogging1.TextLength;
                    if (textLength > (textBoxLogging1.MaxLength - 1000))
                    {
                        //max possible on control = 2147483647
                        textBoxLogging1.Clear();
                        Log.Instance.Debug("CLEAR");
                    }
                }
            }
            catch
            {
                // ignored
            }

            textBoxLogging1._Paint = true; // restore flag so we can paint the control
        }

        private class LogString
        {
            public string LevelUppercase;
            public string Message;
        };

        private static readonly Queue<LogString> LogQueue = new Queue<LogString>();

        // ReSharper disable UnusedMember.Global
        // This is used by the logging to force all to the output window
        public static void LogMethod(string levelUppercase, string message)
        {
            LogQueue.Enqueue(new LogString
            {
                LevelUppercase = levelUppercase,
                Message = message
            });
        }

    }
}
