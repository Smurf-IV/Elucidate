using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using wyDay.Controls;

namespace Shared
{
    public class TextOverProgressBar : Windows7ProgressBar
    {
        private readonly Timer marqueeTimer = new Timer();

        private readonly Color black30 = Color.FromArgb(30, Color.Black);

        private readonly Color black20 = Color.FromArgb(20, Color.Black);

        private readonly Color white128 = Color.FromArgb(128, Color.White);

        [Category("Appearance"), DefaultValue(typeof(StringAlignment), "Near")]
        public StringAlignment TextAlignment
        {
            get;
            set;
        }

        [Category("Appearance"), DefaultValue(typeof(string), "ControlText")]
        public string DisplayText
        {
            get
            {
                return this.Text;
            }
            set
            {
                if (this.Text != value)
                {
                    this.Text = value;
                    base.Invalidate();
                }
            }
        }

        [Category("Appearance"), DefaultValue(typeof(SystemColors), "ControlText")]
        public Color TextColor
        {
            get;
            set;
        }

        public new ProgressBarState State
        {
            get
            {
                return base.State;
            }
            set
            {
                if (base.State != value)
                {
                    base.State = value;
                    Color baseColor;
                    switch (value)
                    {
                        case ProgressBarState.Normal:
                            baseColor = Color.LimeGreen;
                            break;
                        case ProgressBarState.Error:
                            baseColor = Color.Red;
                            break;
                        case ProgressBarState.Pause:
                            baseColor = Color.FromArgb(210, 200, 0);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("value");
                    }
                    this.ForeColor = Color.FromArgb(base.Enabled ? 255 : 128, baseColor);
                }
            }
        }

        [Browsable(true), Category("CatBehavior"), DefaultValue(ProgressBarStyle.Blocks), Description("ProgressBarStyleDescr"), EditorBrowsable(EditorBrowsableState.Always)]
        public new ProgressBarStyle Style
        {
            get
            {
                return base.Style;
            }
            set
            {
                if (base.Style == value)
                {
                    return;
                }
                base.Style = value;
                this.marqueeTimer.Interval = base.MarqueeAnimationSpeed;
                this.marqueeTimer.Enabled = (base.Style == ProgressBarStyle.Marquee);
            }
        }

        public TextOverProgressBar()
        {
            base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.marqueeTimer.Interval = 1000;
            this.marqueeTimer.Tick += new EventHandler(this.AnimateTimer_OnTick);
            this.marqueeTimer.Enabled = (this.Style == ProgressBarStyle.Marquee);
        }

        private void PaintMarquee(PaintEventArgs e)
        {
            float num = (float)base.Width / (float)base.Maximum;
            int num2 = (int)((float)base.Value * num);
            num *= (float)base.Step;
            num = Math.Max(num, 5f);
            int x = Math.Max(Math.Min(num2 + 2, (int)((float)num2 + num)), 2);
            Rectangle rect = new Rectangle(x, 2, (int)num * 2, base.Height);
            rect.Height -= 3;
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.Transparent, this.ForeColor, 0f, true))
            {
                linearGradientBrush.SetSigmaBellShape(0.5f, 1f);
                linearGradientBrush.SetBlendTriangularShape(0.5f, 1f);
                e.Graphics.FillRectangle(linearGradientBrush, rect);
            }
        }

        private void AnimateTimer_OnTick(object sender, EventArgs e)
        {
            if (this.marqueeTimer.Interval != base.MarqueeAnimationSpeed)
            {
                this.marqueeTimer.Interval = base.MarqueeAnimationSpeed;
            }
            if (this.Style == ProgressBarStyle.Marquee)
            {
                int num = base.Value;
                if (this.State != ProgressBarState.Pause)
                {
                    num += base.Step;
                    if (num >= base.Maximum || num < base.Minimum)
                    {
                        num = base.Minimum;
                    }
                    base.Value = num;
                }
                this.Refresh();
            }
        }

        public static GraphicsPath GetRoundedRect(RectangleF baseRect, float radiusX, float radiusY)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            if (radiusX <= 0f || radiusY <= 0f)
            {
                graphicsPath.AddRectangle(baseRect);
            }
            else
            {
                PointF pointF = new PointF(Math.Min(radiusX * 2f, baseRect.Width), Math.Min(radiusY * 2f, baseRect.Height));
                graphicsPath.AddArc(baseRect.X, baseRect.Y, pointF.X, pointF.Y, 180f, 90f);
                graphicsPath.AddArc(baseRect.Right - pointF.X, baseRect.Y, pointF.X, pointF.Y, 270f, 90f);
                graphicsPath.AddArc(baseRect.Right - pointF.X, baseRect.Bottom - pointF.Y, pointF.X, pointF.Y, 0f, 90f);
                graphicsPath.AddArc(baseRect.X, baseRect.Bottom - pointF.Y, pointF.X, pointF.Y, 90f, 90f);
            }
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        protected void NoRendererSupport(PaintEventArgs e, Rectangle rec)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            rec.Inflate(-1, -1);
            this.DrawBackground(e.Graphics, rec);
            this.DrawBackgroundShadows(e.Graphics, rec);
            this.DrawBarHighlight(e.Graphics, rec);
        }

        private void DrawBackground(Graphics g, Rectangle rect)
        {
            using (GraphicsPath roundedRect = TextOverProgressBar.GetRoundedRect(rect, 2f, 2f))
            {
                using (Brush brush = new SolidBrush(this.BackColor))
                {
                    g.FillPath(brush, roundedRect);
                }
            }
        }

        private void DrawBarHighlight(Graphics g, Rectangle rect)
        {
            Rectangle rectangle = new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 1, 6);
            using (GraphicsPath roundedRect = TextOverProgressBar.GetRoundedRect(rectangle, 2f, 2f))
            {
                g.SetClip(roundedRect);
                using (Brush brush = new LinearGradientBrush(rectangle, Color.WhiteSmoke, this.white128, LinearGradientMode.Vertical))
                {
                    g.FillPath(brush, roundedRect);
                }
                g.ResetClip();
            }
            Rectangle rectangle2 = new Rectangle(rect.Left + 1, rect.Bottom - 8, rect.Width - 1, 6);
            using (GraphicsPath roundedRect2 = TextOverProgressBar.GetRoundedRect(rectangle2, 2f, 2f))
            {
                g.SetClip(roundedRect2);
                using (Brush brush2 = new LinearGradientBrush(rectangle2, Color.Transparent, this.black20, LinearGradientMode.Vertical))
                {
                    g.FillPath(brush2, roundedRect2);
                }
                g.ResetClip();
            }
        }

        private void DrawBackgroundShadows(Graphics g, Rectangle rect)
        {
            Rectangle rect2 = new Rectangle(rect.Left + 2, rect.Top + 2, 10, rect.Height - 5);
            using (Brush brush = new LinearGradientBrush(rect2, this.black30, Color.Transparent, LinearGradientMode.Horizontal))
            {
                rect2.X--;
                g.FillRectangle(brush, rect2);
            }
            Rectangle rect3 = new Rectangle(rect.Right - 12, rect.Top + 2, 10, rect.Height - 5);
            using (Brush brush2 = new LinearGradientBrush(rect3, Color.Transparent, this.black20, LinearGradientMode.Horizontal))
            {
                g.FillRectangle(brush2, rect3);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
            if (ProgressBarRenderer.IsSupported)
            {
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rectangle);
            }
            else
            {
                this.NoRendererSupport(e, rectangle);
            }
            switch (this.Style)
            {
                case ProgressBarStyle.Blocks:
                case ProgressBarStyle.Continuous:
                    using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangle, this.BackColor, this.ForeColor, LinearGradientMode.Vertical))
                    {
                        e.Graphics.FillRectangle(linearGradientBrush, 1, 1, (int)((double)rectangle.Width * ((double)base.Value / (double)base.Maximum)) - 3, rectangle.Height - 3);
                        goto IL_B0;
                    }
                    break;
                case ProgressBarStyle.Marquee:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            this.PaintMarquee(e);
            IL_B0:
            using (SolidBrush solidBrush = new SolidBrush(this.TextColor))
            {
                using (StringFormat stringFormat = new StringFormat(StringFormatFlags.NoWrap)
                {
                    Alignment = this.TextAlignment,
                    LineAlignment = StringAlignment.Center,
                    Trimming = StringTrimming.EllipsisWord
                })
                {
                    rectangle.Inflate(-5, -2);
                    e.Graphics.DrawString(this.Text, this.Font, solidBrush, rectangle, stringFormat);
                }
            }
        }
    }
}
