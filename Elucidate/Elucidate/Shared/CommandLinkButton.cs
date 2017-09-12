using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Shared
{
    [ToolboxBitmap(typeof(Button))]
    public sealed class CommandLinkButton : Button
    {
        private enum State
        {
            Normal,
            Hover,
            Pushed,
            Disabled
        }

        private bool showUnderLine;

        private Image grayImage;

        private CommandLinkButton.State state;

        private sbyte buttonDepress = 2;

        private string subscript;

        private Font subscriptFont = new Font("Tahoma", 8f);

        private int textGap = 3;

        private float imageMargin = 4f;

        private Color highlightColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);

        private float hightlightWidth = 2f;

        private float rounding = 10f;

        private bool useHighlighFill = true;

        private byte highlightFillAlphaNormal = 50;

        private byte highlightFillAlpha = 200;

        private byte highlightFillAlphaMouse = 100;

        [DefaultValue(typeof(Font), "Tahoma, 14.25pt")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                this.Refresh();
            }
        }

        [Browsable(true), Category("Command Appearance"), DefaultValue(2), Description("The amount the text and image move diagonally when pressed")]
        public sbyte ButtonDepress
        {
            get
            {
                return this.buttonDepress;
            }
            set
            {
                this.buttonDepress = value;
            }
        }

        [Browsable(true), Category("Command Appearance"), DefaultValue(null)]
        public new Image Image
        {
            get
            {
                return base.Image;
            }
            set
            {
                if (this.grayImage != null)
                {
                    this.grayImage.Dispose();
                }
                this.grayImage = ((value != null) ? CommandLinkButton.GetGrayscale(value) : null);
                base.Image = value;
                this.Refresh();
            }
        }

        [Category("Appearance"), DefaultValue("Describe the command executed here"), Description("The text to display as the subscript.")]
        public string Subscript
        {
            get
            {
                return this.subscript;
            }
            set
            {
                if (this.subscript != value)
                {
                    this.subscript = value;
                    this.Refresh();
                }
            }
        }

        [Category("Appearance"), DefaultValue(typeof(Font), "Tahoma, 8pt"), Description("The font to use for the subscript.")]
        public Font SubscriptFont
        {
            get
            {
                return this.subscriptFont;
            }
            set
            {
                if (this.subscriptFont != value)
                {
                    this.subscriptFont = value;
                    this.Refresh();
                }
            }
        }

        [Category("Appearance"), DefaultValue(3), Description("Specifies the gap between the headline and subscript text.")]
        public int TextGap
        {
            get
            {
                return this.textGap;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot be negative.", "TextGap");
                }
                if (this.textGap != value)
                {
                    this.textGap = value;
                    this.Refresh();
                }
            }
        }

        [Category("Appearance"), DefaultValue(4f), Description("Specifies the margin at each side of the image.")]
        public float ImageMargin
        {
            get
            {
                return this.imageMargin;
            }
            set
            {
                if (value < 0f)
                {
                    throw new ArgumentException("Cannot be negative.", "ImageMargin");
                }
                if (this.imageMargin != value)
                {
                    this.imageMargin = value;
                    this.Refresh();
                }
            }
        }

        [Category("Highlight"), DefaultValue(typeof(Color), "GradientActiveCaption"), Description("The color to use for the highlight.")]
        public Color HighlightColor
        {
            get
            {
                return this.highlightColor;
            }
            set
            {
                if (this.highlightColor != value)
                {
                    this.highlightColor = value;
                    this.Refresh();
                }
            }
        }

        [Category("Highlight"), Description("The width of the highlight line.")]
        public float HighlightWidth
        {
            get
            {
                return this.hightlightWidth;
            }
            set
            {
                if (value < 0f)
                {
                    throw new ArgumentException("Cannot be negative.", "HighlightWidth");
                }
                if (this.hightlightWidth != value)
                {
                    this.hightlightWidth = value;
                    this.Refresh();
                }
            }
        }

        [Category("Highlight"), Description("Controls how round the corners of the highlight are.")]
        public float Rounding
        {
            get
            {
                return this.rounding;
            }
            set
            {
                if (this.rounding != value)
                {
                    this.rounding = value;
                    this.Refresh();
                }
            }
        }

        [Category("Highlight"), DefaultValue(true), Description("When true the interior background of the control will be blended with the highlight color.")]
        public bool UseHighlighFill
        {
            get
            {
                return this.useHighlighFill;
            }
            set
            {
                if (this.useHighlighFill != value)
                {
                    this.useHighlighFill = value;
                    this.Refresh();
                }
            }
        }

        [Category("Highlight"), DefaultValue(50), Description("Sets the maximum alpha value to use for the graduated normal fill.")]
        public byte HighlightFillAlphaNormal
        {
            get
            {
                return this.highlightFillAlphaNormal;
            }
            set
            {
                if (this.highlightFillAlphaNormal != value)
                {
                    this.highlightFillAlphaNormal = value;
                    this.Refresh();
                }
            }
        }

        [Category("Highlight"), DefaultValue(200), Description("Sets the maximum alpha value to use for the graduated highlight fill.")]
        public byte HighlightFillAlpha
        {
            get
            {
                return this.highlightFillAlpha;
            }
            set
            {
                if (this.highlightFillAlpha != value)
                {
                    this.highlightFillAlpha = value;
                    this.Refresh();
                }
            }
        }

        [Category("Highlight"), DefaultValue(100), Description("Sets the maximum alpha value to use for the graduated highlight fill when the the mouse is over the control.")]
        public byte HighlightFillAlphaMouse
        {
            get
            {
                return this.highlightFillAlphaMouse;
            }
            set
            {
                if (this.highlightFillAlphaMouse != value)
                {
                    this.highlightFillAlphaMouse = value;
                    this.Refresh();
                }
            }
        }

        public CommandLinkButton()
        {
            base.ImageAlign = ContentAlignment.MiddleLeft;
            base.TextAlign = ContentAlignment.MiddleLeft;
            base.Width = 375;
            base.Height = 65;
            base.Font = new Font("Tahoma", 14.25f);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.showUnderLine = SystemInformation.MenuAccessKeysUnderlined;
            base.ChangeUICues += new UICuesEventHandler(this.btnChangeUICues);
        }

        private void btnChangeUICues(object sender, UICuesEventArgs uiCuesEventArgs)
        {
            if (uiCuesEventArgs.ChangeKeyboard)
            {
                this.showUnderLine = uiCuesEventArgs.ShowKeyboard;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (base.DesignMode)
            {
                this.showUnderLine = true;
            }
        }

        protected override void OnPaint(PaintEventArgs paintEvent)
        {
            GraphicsPath graphicsPath = this.CreateOutlinePath(paintEvent.Graphics);
            if (this.state == CommandLinkButton.State.Disabled)
            {
                using (Brush brush = new SolidBrush(Color.FromArgb(128, this.BackColor)))
                {
                    paintEvent.Graphics.FillRectangle(brush, base.ClientRectangle);
                    goto IL_57;
                }
            }
            this.DrawHighlight(paintEvent.Graphics, graphicsPath);
            IL_57:
            using (Pen pen = new Pen(base.Enabled ? this.highlightColor : Color.FromArgb(128, Color.FromKnownColor(KnownColor.GrayText)), base.Enabled ? this.hightlightWidth : 0.1f))
            {
                paintEvent.Graphics.DrawPath(pen, graphicsPath);
            }
            int num = (int)((this.state == CommandLinkButton.State.Pushed) ? this.buttonDepress : 0);
            RectangleF bounds = new RectangleF(base.ClientRectangle.Location, base.ClientRectangle.Size);
            Image drawImage = this.GetDrawImage();
            if (drawImage != null)
            {
                RectangleF alignedRectangle = CommandLinkButton.GetAlignedRectangle(bounds, drawImage.Size, base.ImageAlign);
                float num2 = alignedRectangle.Width + 2f * this.imageMargin;
                ContentAlignment imageAlign = base.ImageAlign;
                if (imageAlign <= ContentAlignment.MiddleLeft)
                {
                    if (imageAlign != ContentAlignment.TopLeft)
                    {
                        if (imageAlign == ContentAlignment.TopRight)
                        {
                            goto IL_19A;
                        }
                        if (imageAlign != ContentAlignment.MiddleLeft)
                        {
                            goto IL_1BD;
                        }
                    }
                }
                else
                {
                    if (imageAlign == ContentAlignment.MiddleRight)
                    {
                        goto IL_19A;
                    }
                    if (imageAlign != ContentAlignment.BottomLeft)
                    {
                        if (imageAlign != ContentAlignment.BottomRight)
                        {
                            goto IL_1BD;
                        }
                        goto IL_19A;
                    }
                }
                bounds.Width -= num2;
                bounds.Offset(num2, 0f);
                alignedRectangle.Offset(this.imageMargin, 0f);
                goto IL_1BD;
                IL_19A:
                bounds.Width -= num2;
                alignedRectangle.Offset(-this.imageMargin, 0f);
                IL_1BD:
                if (num != 0)
                {
                    alignedRectangle.Offset((float)num, (float)num);
                }
                paintEvent.Graphics.DrawImage(drawImage, alignedRectangle);
            }
            Size size = TextRenderer.MeasureText(paintEvent.Graphics, this.Text, this.Font);
            Size size2 = TextRenderer.MeasureText(paintEvent.Graphics, this.subscript, this.subscriptFont);
            Size p = new Size(Math.Max(size.Width, size2.Width), size.Height + size2.Height + this.textGap);
            Rectangle rectangle = Rectangle.Round(CommandLinkButton.GetAlignedRectangle(bounds, p, this.TextAlign));
            if (num != 0)
            {
                rectangle.Offset(num, num);
            }
            TextFormatFlags textFormatFlags = TextFormatFlags.WordEllipsis;
            if (!this.showUnderLine)
            {
                textFormatFlags |= TextFormatFlags.HidePrefix;
            }
            Color foreColor = base.Enabled ? this.ForeColor : Color.FromKnownColor(KnownColor.GrayText);
            TextRenderer.DrawText(paintEvent.Graphics, this.Text, this.Font, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, size.Height), foreColor, Color.Transparent, textFormatFlags);
            TextRenderer.DrawText(paintEvent.Graphics, this.subscript, this.subscriptFont, new Rectangle(rectangle.X, rectangle.Y + size.Height + this.textGap, rectangle.Width, size2.Height), foreColor, Color.Transparent, TextFormatFlags.WordEllipsis);
        }

        private void DrawHighlight(Graphics graphics, GraphicsPath hp)
        {
            if (base.Enabled && this.useHighlighFill)
            {
                byte alpha = this.highlightFillAlphaNormal;
                switch (this.state)
                {
                    case CommandLinkButton.State.Normal:
                        alpha = (this.Focused ? this.highlightFillAlpha : this.highlightFillAlphaNormal);
                        break;
                    case CommandLinkButton.State.Hover:
                        alpha = (this.Focused ? (byte) 255 : this.highlightFillAlphaMouse);
                        break;
                    case CommandLinkButton.State.Pushed:
                        alpha = this.highlightFillAlpha;
                        break;
                    case CommandLinkButton.State.Disabled:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                using (Brush brush = new LinearGradientBrush(base.ClientRectangle, this.BackColor, Color.FromArgb((int)alpha, this.highlightColor), 90f))
                {
                    graphics.FillPath(brush, hp);
                }
            }
        }

        private GraphicsPath CreateOutlinePath(Graphics graphics)
        {
            using (Brush brush = new SolidBrush(this.BackColor))
            {
                graphics.FillRectangle(brush, base.ClientRectangle);
            }
            float num = this.hightlightWidth / 2f;
            float num2 = (float)base.Height - num;
            float y = num2 - this.rounding;
            float num3 = num;
            float num4 = (float)base.Width - num3;
            float x = num4 - this.rounding;
            GraphicsPath graphicsPath = new GraphicsPath(FillMode.Winding);
            graphicsPath.AddArc(x, num, this.rounding, this.rounding, 270f, 90f);
            graphicsPath.AddArc(x, y, this.rounding, this.rounding, 0f, 90f);
            graphicsPath.AddArc(num3, y, this.rounding, this.rounding, 90f, 90f);
            graphicsPath.AddArc(num3, num, this.rounding, this.rounding, 180f, 90f);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        private static Bitmap GetGrayscale(Image original)
        {
            Bitmap bitmap = new Bitmap(original.Width, original.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                float[][] array = new float[6][];
                array[0] = new float[]
                {
                    0.3f,
                    0.3f,
                    0.3f,
                    0f,
                    0f
                };
                array[1] = new float[]
                {
                    0.59f,
                    0.59f,
                    0.59f,
                    0f,
                    0f
                };
                array[2] = new float[]
                {
                    0.11f,
                    0.11f,
                    0.11f,
                    0f,
                    0f
                };
                float[][] arg_76_0 = array;
                int arg_76_1 = 3;
                float[] array2 = new float[6];
                array2[3] = 1f;
                arg_76_0[arg_76_1] = array2;
                float[][] arg_8D_0 = array;
                int arg_8D_1 = 4;
                float[] array3 = new float[6];
                array3[4] = 1f;
                arg_8D_0[arg_8D_1] = array3;
                array[5] = new float[]
                {
                    0f,
                    0f,
                    0f,
                    0f,
                    0f,
                    1f
                };
                ColorMatrix colorMatrix = new ColorMatrix(array);
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(colorMatrix);
                graphics.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, imageAttributes);
            }
            return bitmap;
        }

        private static RectangleF GetAlignedRectangle(RectangleF bounds, SizeF desiredSize, ContentAlignment alignment)
        {
            SizeF size = new SizeF(Math.Min(bounds.Width, desiredSize.Width), Math.Min(bounds.Height, desiredSize.Height));
            if (alignment <= ContentAlignment.MiddleCenter)
            {
                switch (alignment)
                {
                    case ContentAlignment.TopCenter:
                        return new RectangleF(bounds.Left + (bounds.Width - size.Width) / 2f, bounds.Top, size.Width, size.Height);
                    case (ContentAlignment)3:
                        break;
                    case ContentAlignment.TopRight:
                        return new RectangleF(bounds.Right - size.Width, bounds.Top, size.Width, size.Height);
                    default:
                        if (alignment == ContentAlignment.MiddleLeft)
                        {
                            return new RectangleF(bounds.Left, bounds.Top + (bounds.Height - size.Height) / 2f, size.Width, size.Height);
                        }
                        if (alignment == ContentAlignment.MiddleCenter)
                        {
                            return new RectangleF(bounds.Left + (bounds.Width - size.Width) / 2f, bounds.Top + (bounds.Height - size.Height) / 2f, size.Width, size.Height);
                        }
                        break;
                }
            }
            else if (alignment <= ContentAlignment.BottomLeft)
            {
                if (alignment == ContentAlignment.MiddleRight)
                {
                    return new RectangleF(bounds.Right - size.Width, bounds.Top + (bounds.Height - size.Height) / 2f, size.Width, size.Height);
                }
                if (alignment == ContentAlignment.BottomLeft)
                {
                    return new RectangleF(bounds.Left, bounds.Bottom - size.Height, size.Width, size.Height);
                }
            }
            else
            {
                if (alignment == ContentAlignment.BottomCenter)
                {
                    return new RectangleF(bounds.Left + (bounds.Width - size.Width) / 2f, bounds.Bottom - size.Height, size.Width, size.Height);
                }
                if (alignment == ContentAlignment.BottomRight)
                {
                    return new RectangleF(bounds.Right - size.Width, bounds.Bottom - size.Height, size.Width, size.Height);
                }
            }
            return new RectangleF(bounds.Location, size);
        }

        private Image GetDrawImage()
        {
            Image image = this.Image;
            if (image == null && base.ImageList != null)
            {
                image = ((!string.IsNullOrEmpty(base.ImageKey)) ? base.ImageList.Images[base.ImageKey] : base.ImageList.Images[base.ImageIndex]);
            }
            if (image != null && this.grayImage == null)
            {
                this.grayImage = CommandLinkButton.GetGrayscale(image);
            }
            if (!base.Enabled)
            {
                return this.grayImage;
            }
            return image;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.grayImage != null)
            {
                this.grayImage.Dispose();
                this.grayImage = null;
            }
            base.Dispose(disposing);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (base.Enabled)
            {
                this.state = CommandLinkButton.State.Hover;
            }
            this.Refresh();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (base.Enabled)
            {
                this.state = CommandLinkButton.State.Normal;
            }
            this.Refresh();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (base.Enabled)
            {
                this.state = CommandLinkButton.State.Pushed;
            }
            this.Refresh();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (base.Enabled)
            {
                this.state = (base.RectangleToScreen(base.ClientRectangle).Contains(Cursor.Position) ? CommandLinkButton.State.Hover : CommandLinkButton.State.Normal);
            }
            this.Refresh();
            base.OnMouseUp(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            this.state = (base.Enabled ? CommandLinkButton.State.Normal : CommandLinkButton.State.Disabled);
            this.Refresh();
            base.OnEnabledChanged(e);
        }
    }
}
