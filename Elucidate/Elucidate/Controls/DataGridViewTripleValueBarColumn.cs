#region Copyright (C)
// ---------------------------------------------------------------------------------------------------------------
//  <copyright file="LogsViewerControl.cs" company="Smurf-IV">
// 
//  Copyright (C) 2019-2022  Simon Coghlan (Aka Smurf-IV)
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
#endregion

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Elucidate.Controls
{
    public class DataGridViewTripleValueBarColumn : DataGridViewImageColumn
    {
        public DataGridViewTripleValueBarColumn() => CellTemplate = new DataGridViewTripleValueBarCell();
    }

    /// <summary>
    /// Splits the passed in string into 3 values
    /// Low, Middle, Max
    /// These are colon separated float values.
    /// </summary>
    internal class DataGridViewTripleValueBarCell : DataGridViewImageCell
    {
        // Used to make custom cell consistent with a DataGridViewImageCell
        private static readonly Image EmptyImage;

        static DataGridViewTripleValueBarCell() => EmptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

        public DataGridViewTripleValueBarCell() => ValueType = typeof(string);

        // Method required to make the Progress Cell consistent with the default Image Cell. 
        // The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an string.
        protected override object GetFormattedValue(object value,
                            int rowIndex, ref DataGridViewCellStyle cellStyle,
                            TypeConverter valueTypeConverter,
                            TypeConverter formattedValueTypeConverter,
                            DataGridViewDataErrorContexts context) =>
            EmptyImage;

        protected override void Paint(Graphics g, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                var s = ((string)value);
                if (string.IsNullOrWhiteSpace(s))
                {
                    return;
                }

                var values = s.Split(':');
                if (values.Length != 3)
                {
                    return;
                }

                float.TryParse(values[0], out var low);
                float.TryParse(values[1], out var mid);
                float.TryParse(values[2], out var max);

                if (max <= 0)
                {
                    return;
                }

                var lowPercent = low / max;
                var midPercent = mid / max;
                // Draws the cell grid
                base.Paint(g, clipBounds, cellBounds,
                 rowIndex, cellState, value, formattedValue, errorText,
                 cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));
                cellBounds.Inflate(-2, -2);
                if (midPercent > 0.0)
                {
                    g.FillRectangle(SystemBrushes.GradientInactiveCaption, cellBounds.X, cellBounds.Y, midPercent * cellBounds.Width, cellBounds.Height);
                }

                if (lowPercent > 0.0)
                {
                    cellBounds.Inflate(-1, -1);
                    // Draw the progress bar and the text
                    g.FillRectangle(SystemBrushes.ActiveCaption, cellBounds.X, cellBounds.Y, lowPercent * cellBounds.Width, cellBounds.Height);
                    //g.DrawString(progressVal.ToString() + "%", cellStyle.Font, foreColorBrush, cellBounds.X + (cellBounds.Width / 2) - 5, cellBounds.Y + 2);
                }
                //else
                //{
                //    // draw the text
                //    if (this.DataGridView.CurrentRow.Index == rowIndex)
                //        g.DrawString(progressVal.ToString() + "%", cellStyle.Font, new SolidBrush(cellStyle.SelectionForeColor), cellBounds.X + 6, cellBounds.Y + 2);
                //    else
                //        g.DrawString(progressVal.ToString() + "%", cellStyle.Font, foreColorBrush, cellBounds.X + 6, cellBounds.Y + 2);
                //}
            }
            catch /*(Exception e) */{ }

        }
    }
}