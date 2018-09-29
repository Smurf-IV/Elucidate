using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using wyDay.Controls;

// Stuff Resdharper comment here to prevent it trying to remove designer reflection methods
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global
namespace Shared
{
    /// <summary>
    /// Color fill taken from http://stackoverflow.com/questions/778678/how-to-change-the-color-of-progressbar-in-c-net-3-5
    /// Text overwrite taken from http://www.dreamincode.net/forums/blog/217/entry-2366-a-professional-looking-progressbar-with-percentage/
    /// Sigma bell hints from http://www.c-sharpcorner.com/UploadFile/mahesh/759/
    /// RoundRect from taken from http://www.codeproject.com/KB/GDI-plus/ExtendedGraphics.aspx?msg=2073988#xx2073988xx
    /// Then modified by me to add some more settings
    /// </summary>
    public class TextOverProgressBar : Windows7ProgressBar
    {
        private readonly Timer marqueeTimer = new Timer();

        public TextOverProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
               ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            marqueeTimer.Interval = 1000;
            marqueeTimer.Tick += AnimateTimer_OnTick;
            marqueeTimer.Enabled = (Style == ProgressBarStyle.Marquee);
        }

        [Category("Appearance")]
        [DefaultValue(typeof(StringAlignment), "Near")]
        public StringAlignment TextAlignment { get; set; }

        /// <summary>
        /// Overrides System.Windows.Forms.Control.Text.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(string), "ControlText")]
        public string DisplayText
        {
            get => Text;
            set
            {
                if (Text != value)
                {
                    Text = value;
                    Invalidate();
                }

            }
        }

        [Category("Appearance")]
        [DefaultValue(typeof(SystemColors), "ControlText")]
        public Color TextColor { get; set; }

        public new ProgressBarState State
        {
            get => base.State;
            set
            {
                if (base.State != value)
                {
                    base.State = value;
                    Color newColor;
                    switch (value)
                    {
                        case ProgressBarState.Normal:
                            newColor = Color.LimeGreen;
                            break;
                        case ProgressBarState.Pause:
                            newColor = Color.FromArgb(210, 200, 0);
                            break;
                        case ProgressBarState.Error:
                            newColor = Color.Red;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("value");
                    }
                    ForeColor = Color.FromArgb(Enabled ? 255 : 128, newColor);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [Category("CatBehavior")]
        [Description("ProgressBarStyleDescr")]
        [DefaultValue(ProgressBarStyle.Blocks)]
        public new ProgressBarStyle Style
        {
            get => base.Style;
            set
            {
                if (base.Style == value)
                {
                    return;
                }
                base.Style = value;
                marqueeTimer.Interval = MarqueeAnimationSpeed;
                marqueeTimer.Enabled = (base.Style == ProgressBarStyle.Marquee);
            }
        }

        private void PaintMarquee(PaintEventArgs e)
        {
            float stepWidthPixel = (float)Width / Maximum;
            int localValue = (int)(Value * stepWidthPixel);
            stepWidthPixel *= Step;
            stepWidthPixel = Math.Max(stepWidthPixel, 5);
            int left = Math.Max(Math.Min(localValue + 2, (int)(localValue + stepWidthPixel)), 2);
            Rectangle rec = new Rectangle(left, 2, (int)stepWidthPixel * 2, Height);
            rec.Height -= 3;

            // Create a linear gradient brush
            using (LinearGradientBrush rgBrush = new LinearGradientBrush(rec, Color.Transparent, ForeColor, 0.0f, true))
            {
                // Set sigma bell shape
                rgBrush.SetSigmaBellShape(0.5f, 1.0f);
                // Set blend triangular shape
                rgBrush.SetBlendTriangularShape(0.5f, 1.0f);
                // Fill rectangle again
                e.Graphics.FillRectangle(rgBrush, rec);
            }
        }


        private void AnimateTimer_OnTick(object sender, EventArgs e)
        {
            if (marqueeTimer.Interval != MarqueeAnimationSpeed)
            {
                marqueeTimer.Interval = MarqueeAnimationSpeed;
            }
            if (Style == ProgressBarStyle.Marquee)
            {
                int localValue = Value;
                if (State != ProgressBarState.Pause)
                {
                    localValue += Step;
                    if ((localValue >= Maximum)
                        || (localValue < Minimum)
                       )
                    {
                        localValue = Minimum;
                    }
                    Value = localValue;
                }
                Refresh();
            }

        }

        #region No Style implemented Workaround (i.e. via RDP)

        /// <summary>
        /// Taken from http://www.codeproject.com/KB/GDI-plus/ExtendedGraphics.aspx?msg=2073988#xx2073988xx
        /// Creates the rounded rectangle path.
        /// </summary>
        /// <returns>The rounded rectangle path.</returns>
        /// <param name='baseRect'> Rect.</param>
        /// <param name="radiusX"></param>
        /// <param name="radiusY"></param>
        public static GraphicsPath GetRoundedRect(RectangleF baseRect, float radiusX, float radiusY)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.StartFigure();

            if (radiusX <= 0.0F || radiusY <= 0.0F)
            {
                gp.AddRectangle(baseRect);
            }
            else
            {
                //arcs work with diameters (radius * 2)
                PointF d = new PointF(Math.Min(radiusX * 2, baseRect.Width), Math.Min(radiusY * 2, baseRect.Height));
                gp.AddArc(baseRect.X, baseRect.Y, d.X, d.Y, 180, 90);
                gp.AddArc(baseRect.Right - d.X, baseRect.Y, d.X, d.Y, 270, 90);
                gp.AddArc(baseRect.Right - d.X, baseRect.Bottom - d.Y, d.X, d.Y, 0, 90);
                gp.AddArc(baseRect.X, baseRect.Bottom - d.Y, d.X, d.Y, 90, 90);
            }
            gp.CloseFigure();
            return gp;
        }

        protected void NoRendererSupport(PaintEventArgs e, Rectangle rec)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            rec.Inflate(-1, -1);
            DrawBackground(e.Graphics, rec);
            DrawBackgroundShadows(e.Graphics, rec);
            DrawBarHighlight(e.Graphics, rec);
        }
        private void DrawBackground(Graphics g, Rectangle rect)
        {
            using (GraphicsPath backgroundPath = GetRoundedRect(rect, 2, 2))
            {
                using (Brush backBrush = new SolidBrush(BackColor))
                {
                    g.FillPath(backBrush, backgroundPath);
                }
            }
        }
        private readonly Color black30 = Color.FromArgb(30, Color.Black);
        private readonly Color black20 = Color.FromArgb(20, Color.Black);
        private readonly Color white128 = Color.FromArgb(128, Color.White);
        private void DrawBarHighlight(Graphics g, Rectangle rect)
        {
            Rectangle tr = new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 1, 6);
            using (GraphicsPath tp = GetRoundedRect(tr, 2, 2))
            {
                g.SetClip(tp);
                using (Brush tg = new LinearGradientBrush(tr, Color.WhiteSmoke, white128, LinearGradientMode.Vertical))
                {
                    g.FillPath(tg, tp);
                }
                g.ResetClip();
            }

            Rectangle br = new Rectangle(rect.Left + 1, rect.Bottom - 8, rect.Width - 1, 6);
            using (GraphicsPath bp = GetRoundedRect(br, 2, 2))
            {
                g.SetClip(bp);
                using (Brush bg = new LinearGradientBrush(br, Color.Transparent, black20, LinearGradientMode.Vertical))
                {
                    g.FillPath(bg, bp);
                }
                g.ResetClip();
            }
        }

        private void DrawBackgroundShadows(Graphics g, Rectangle rect)
        {
            Rectangle lr = new Rectangle(rect.Left + 2, rect.Top + 2, 10, rect.Height - 5);
            using (Brush lg = new LinearGradientBrush(lr, black30, Color.Transparent, LinearGradientMode.Horizontal))
            {
                lr.X--;
                g.FillRectangle(lg, lr);
            }

            Rectangle rr = new Rectangle(rect.Right - 12, rect.Top + 2, 10, rect.Height - 5);
            using (Brush rg = new LinearGradientBrush(rr, Color.Transparent, black20, LinearGradientMode.Horizontal))
            {
                g.FillRectangle(rg, rr);
            }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = new Rectangle(0, 0, Width, Height);

            if (ProgressBarRenderer.IsSupported)
            {
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);
            }
            else
            {
                NoRendererSupport(e, rec);
            }
            switch (Style)
            {
                case ProgressBarStyle.Blocks:
                case ProgressBarStyle.Continuous:
                    using (LinearGradientBrush brush = new LinearGradientBrush(rec, BackColor, ForeColor,
                                                                             LinearGradientMode.Vertical))
                    {
                        e.Graphics.FillRectangle(brush, 1, 1, (int)(rec.Width * ((double)Value / Maximum)) - 3, rec.Height - 3);
                    }
                    break;
                case ProgressBarStyle.Marquee:
                    PaintMarquee(e);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            using (SolidBrush sb = new SolidBrush(TextColor))
            {
                using (StringFormat sf = new StringFormat(StringFormatFlags.NoWrap)
                {
                    Alignment = TextAlignment,
                    LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisWord
                }
                   )
                {
                    rec.Inflate(-5, -2);
                    e.Graphics.DrawString(Text, Font, sb, rec, sf);
                }
            }
        }


    }

}
// ReSharper restore UnusedMember.Global
// ReSharper restore UnusedAutoPropertyAccessor.Global
// ReSharper restore MemberCanBePrivate.Global
