using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

// These are like this to prevent resharper trying to remove the calls that are used by the designer via reflection
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
//
namespace Shared
{
    /// <summary>
    /// Implements a .NET version of the new Vista Command Link style buttons.
    /// Allows the user to specify an image, headline item text and subscript text.<br/>
    /// Provides focus and mouse over highlighting.
    /// </summary>
    [ToolboxBitmap(typeof(Button))]
    public sealed class CommandLinkButton : Button
    {
        /// <summary>
        /// Constructs a new command link button.
        /// </summary>
        public CommandLinkButton()
        {
            ImageAlign = ContentAlignment.MiddleLeft;
            base.TextAlign = ContentAlignment.MiddleLeft;
            Width = 375;
            Height = 65;
            base.Font = new Font("Tahoma", 14.25f);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            showUnderLine = SystemInformation.MenuAccessKeysUnderlined;
            ChangeUICues += BtnChangeUICues;
        }

        bool showUnderLine = false;
        private void BtnChangeUICues(object sender, UICuesEventArgs uiCuesEventArgs)
        {
            if (uiCuesEventArgs.ChangeKeyboard)
            {
                showUnderLine = uiCuesEventArgs.ShowKeyboard;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (DesignMode)
            {
                showUnderLine = true;
            }
        }
        private Image grayImage;
        /// <summary>
        /// Overrides the default button font to a more suitable headline font.
        /// </summary>
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
                Refresh();
            }
        }

        private enum State
        {
            Normal,
            Hover,
            Pushed,
            Disabled
        }
        private State state = State.Normal;

        /// <summary>
        /// Implements the custom drawing for the button.
        /// </summary>
        /// <param name="paintEvent">The paint event args.</param>
        protected override void OnPaint(PaintEventArgs paintEvent)
        {
            GraphicsPath gp = CreateOutlinePath(paintEvent.Graphics);
            if (state == State.Disabled)
            {
                using (Brush b = new SolidBrush(Color.FromArgb(128, BackColor)))
                {
                    paintEvent.Graphics.FillRectangle(b, ClientRectangle);
                }
            }
            else
            {
                DrawHighlight(paintEvent.Graphics, gp);
            }
            using (Pen p = new Pen(Enabled ? highlightColor : Color.FromArgb(128, Color.FromKnownColor(KnownColor.GrayText)),
                                 Enabled ? hightlightWidth : 0.1f))
            {
                paintEvent.Graphics.DrawPath(p, gp);
            }

            // ReSharper disable RedundantCast
            // This cast is done to enable Mono to package this
            int offset = (state == State.Pushed) ? (int)buttonDepress : 0;
            // ReSharper restore RedundantCast

            RectangleF available = new RectangleF(ClientRectangle.Location, ClientRectangle.Size);
            // Draw the image...
            Image drawImage = GetDrawImage();
            if (drawImage != null)
            {
                // Figure out where to stick the image.
                RectangleF imageRect = GetAlignedRectangle(available, drawImage.Size, ImageAlign);
                float imageAndMargins = imageRect.Width + (2f * imageMargin);
                switch (ImageAlign)
                {
                    case ContentAlignment.BottomLeft:
                    case ContentAlignment.MiddleLeft:
                    case ContentAlignment.TopLeft:
                        available.Width -= imageAndMargins;
                        available.Offset(imageAndMargins, 0f);
                        imageRect.Offset(imageMargin, 0f);
                        break;
                    case ContentAlignment.BottomRight:
                    case ContentAlignment.MiddleRight:
                    case ContentAlignment.TopRight:
                        available.Width -= imageAndMargins;
                        imageRect.Offset(-imageMargin, 0f);
                        break;
                }
                if (offset != 0)
                {
                    imageRect.Offset(offset, offset);
                }
                paintEvent.Graphics.DrawImage(drawImage, imageRect);
            }

            // Now fill in the text
            {
                Size headlineSize = TextRenderer.MeasureText(paintEvent.Graphics, Text, Font);
                Size subscriptSize = TextRenderer.MeasureText(paintEvent.Graphics, subscript, subscriptFont);
                Size combined = new Size(Math.Max(headlineSize.Width, subscriptSize.Width),
                                         headlineSize.Height + subscriptSize.Height + textGap);

                Rectangle textRect = Rectangle.Round(GetAlignedRectangle(available, combined, TextAlign));
                // Draw the headline text...
                if (offset != 0)
                {
                    textRect.Offset(offset, offset);
                }
                TextFormatFlags tf = TextFormatFlags.WordEllipsis;
                if (!showUnderLine)
                {
                    tf |= TextFormatFlags.HidePrefix;
                }
                Color textColor = Enabled ? ForeColor : Color.FromKnownColor(KnownColor.GrayText);

                TextRenderer.DrawText(paintEvent.Graphics, Text, Font,
                                      new Rectangle(textRect.X, textRect.Y, textRect.Width, headlineSize.Height),
                                      textColor, Color.Transparent, tf);
                // Draw the subscript text...
                TextRenderer.DrawText(paintEvent.Graphics, subscript, subscriptFont,
                                      new Rectangle(textRect.X, textRect.Y + headlineSize.Height + textGap, textRect.Width, subscriptSize.Height),
                                      textColor, Color.Transparent, TextFormatFlags.WordEllipsis);
            }

        }
        private void DrawHighlight(Graphics graphics, GraphicsPath hp)
        {
            if (Enabled
               && useHighlighFill
               )
            {
                byte alpha = highlightFillAlphaNormal;
                switch (state)
                {
                    case State.Normal:
                        alpha = Focused ? highlightFillAlpha : highlightFillAlphaNormal;
                        break;
                    case State.Hover:
                        alpha = Focused ? byte.MaxValue : highlightFillAlphaMouse;
                        break;
                    case State.Pushed:
                        alpha = highlightFillAlpha;
                        break;
                    case State.Disabled:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                using (Brush b = new LinearGradientBrush(ClientRectangle, BackColor, Color.FromArgb(alpha, highlightColor), 90f))
                {
                    graphics.FillPath(b, hp);
                }
            }
        }

        private GraphicsPath CreateOutlinePath(Graphics graphics)
        {
            using (Brush b = new SolidBrush(BackColor))
            {
                graphics.FillRectangle(b, ClientRectangle);
            }
            float top = hightlightWidth / 2f;
            //float topInset = top + rounding;
            float bottom = Height - top;
            float bottomInset = bottom - rounding;
            float left = top;
            //float leftInset = left + rounding;
            float right = Width - left;
            float rightInset = right - rounding;

            GraphicsPath gp = new GraphicsPath(FillMode.Winding);
            // Top
            gp.AddArc(rightInset, top, rounding, rounding, 270f, 90f);
            // Right
            gp.AddArc(rightInset, bottomInset, rounding, rounding, 0f, 90f);
            // Bottom
            gp.AddArc(left, bottomInset, rounding, rounding, 90f, 90f);
            // Left
            gp.AddArc(left, top, rounding, rounding, 180f, 90f);
            // Add the lines...
            gp.CloseFigure();
            return gp;
        }

        private sbyte buttonDepress = 2;

        [Category("Command Appearance")]
        [Browsable(true)]
        [DefaultValue(2)]
        [Description("The amount the text and image move diagonally when pressed")]
        public sbyte ButtonDepress
        {
            get
            {
                return buttonDepress;
            }
            set
            {
                buttonDepress = value;
            }
        }

        [Category("Command Appearance")]
        [Browsable(true)]
        [DefaultValue(null)]
        public new Image Image
        {
            get
            {
                return base.Image;
            }
            set
            {
                //Clean up
                if (grayImage != null)
                {
                    grayImage.Dispose();
                }

                grayImage = value != null ? GetGrayscale(value) : null;
                base.Image = value;
                Refresh();
            }
        }

        /// <summary>
        /// Taken from code @ http://www.bobpowell.net/grayscale.htm
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        private static Bitmap GetGrayscale(Image original)
        {
            //Set up the drawing surface
            Bitmap grayscale = new Bitmap(original.Width, original.Height);
            using (Graphics g = Graphics.FromImage(grayscale))
            {
                // Grayscale Color Matrix
                // Gilles Khouzams colour corrected grayscale shear
                ColorMatrix colorMatrix = new ColorMatrix(new[]
                                                             {
                                                            new[] {0.3f, 0.3f, 0.3f, 0, 0},
                                                            new[] {0.59f, 0.59f, 0.59f, 0, 0},
                                                            new[] {0.11f, 0.11f, 0.11f, 0, 0},
                                                            new float[] {0, 0, 0, 1, 0, 0},
                                                            new float[] {0, 0, 0, 0, 1, 0},
                                                            new float[] {0, 0, 0, 0, 0, 1}
                                                         });
                //Create attributes
                ImageAttributes att = new ImageAttributes();
                att.SetColorMatrix(colorMatrix);

                //Draw the image with the new attributes
                g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width,
                            original.Height, GraphicsUnit.Pixel, att);

            }
            return grayscale;
        }

        /// <summary>
        /// Calculates the rectangle to be use for the specified alignment.
        /// </summary>
        /// <param name="bounds">The outer bounding rectangle.</param>
        /// <param name="desiredSize">The desired size of the inner rectangle.</param>
        /// <param name="alignment">The content alignement.</param>
        /// <returns>The rectangle positioned for the content alignment.</returns>
        private static RectangleF GetAlignedRectangle(RectangleF bounds, SizeF desiredSize, ContentAlignment alignment)
        {

            SizeF size = new SizeF(Math.Min(bounds.Width, desiredSize.Width),
               Math.Min(bounds.Height, desiredSize.Height));
            switch (alignment)
            {
                // Left aligned items
                case ContentAlignment.MiddleLeft:
                    return new RectangleF(bounds.Left, bounds.Top + ((bounds.Height - size.Height) / 2f),
                       size.Width, size.Height);

                case ContentAlignment.BottomLeft:
                    return new RectangleF(bounds.Left, bounds.Bottom - size.Height,
                       size.Width, size.Height);

                // Center aligned items
                case ContentAlignment.TopCenter:
                    return new RectangleF(bounds.Left + ((bounds.Width - size.Width) / 2f),
                       bounds.Top,
                       size.Width, size.Height);

                case ContentAlignment.MiddleCenter:
                    return new RectangleF(bounds.Left + ((bounds.Width - size.Width) / 2f),
                       bounds.Top + ((bounds.Height - size.Height) / 2f),
                       size.Width, size.Height);

                case ContentAlignment.BottomCenter:
                    return new RectangleF(bounds.Left + ((bounds.Width - size.Width) / 2f),
                       bounds.Bottom - size.Height,
                       size.Width, size.Height);

                // Right aligned items
                case ContentAlignment.TopRight:
                    return new RectangleF(bounds.Right - size.Width,
                       bounds.Top,
                       size.Width, size.Height);

                case ContentAlignment.MiddleRight:
                    return new RectangleF(bounds.Right - size.Width,
                       bounds.Top + ((bounds.Height - size.Height) / 2f),
                       size.Width, size.Height);

                case ContentAlignment.BottomRight:
                    return new RectangleF(bounds.Right - size.Width,
                       bounds.Bottom - size.Height,
                       size.Width, size.Height);
            }
            // Top Left alignment.
            return new RectangleF(bounds.Location, size);
        }

        /// <summary>
        /// Gets the image to be drawn, the image can be specified via the Image property or
        /// by using an image list.
        /// </summary>
        /// <returns>The image to be drawn or null for no image.</returns>
        private Image GetDrawImage()
        {
            Image image = Image;
            if (image == null && ImageList != null)
            {
                image = !string.IsNullOrEmpty(ImageKey) ? ImageList.Images[ImageKey] : ImageList.Images[ImageIndex];
            }
            if ((image != null)
               && (grayImage == null)
               )
            {
                grayImage = GetGrayscale(image);
            }
            return Enabled ? image : grayImage;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (grayImage != null)
                {
                    grayImage.Dispose();
                    grayImage = null;
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Tracks the event to support mouse over highlighting.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            if (Enabled)
            {
                state = State.Hover;
            }
            Refresh();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Tracks the event to support mouse over highlighting.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            if (Enabled)
            {
                state = State.Normal;
            }
            Refresh();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (Enabled)
            {
                state = State.Pushed;
            }
            Refresh();

            base.OnMouseDown(e);
        }


        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (Enabled)
            {
                state = RectangleToScreen(ClientRectangle).Contains(Cursor.Position) ? State.Hover : State.Normal;
            }
            Refresh();

            base.OnMouseUp(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            state = Enabled ? State.Normal : State.Disabled;

            Refresh();

            base.OnEnabledChanged(e);
        }


        #region Properties

        private string subscript;

        /// <summary>
        /// Gets and sets the text to be displayed in the subscript area.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue("Describe the command executed here")]
        [Description("The text to display as the subscript.")]
        public string Subscript
        {
            get { return subscript; }
            set
            {
                if (subscript != value)
                {
                    subscript = value;
                    Refresh();
                }
            }
        }

        private Font subscriptFont = new Font("Tahoma", 8f);

        /// <summary>
        /// Gets and sets the font to use for the subscript text.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(typeof(Font), "Tahoma, 8pt")]
        [Description("The font to use for the subscript.")]
        public Font SubscriptFont
        {
            get { return subscriptFont; }
            set
            {
                if (subscriptFont != value)
                {
                    subscriptFont = value;
                    Refresh();
                }
            }
        }

        private int textGap = 3;

        /// <summary>
        /// Gets and sets the gap between the headline and subscript text blocks.
        /// </summary>
        [DefaultValue(3)]
        [Category("Appearance")]
        [Description("Specifies the gap between the headline and subscript text.")]
        public int TextGap
        {
            get { return textGap; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot be negative.", "TextGap");
                }
                if (textGap != value)
                {
                    textGap = value;
                    Refresh();
                }
            }
        }

        private float imageMargin = 4f;

        /// <summary>
        /// Gets and sets the left and right margin used for the image.
        /// </summary>
        [DefaultValue(4f)]
        [Category("Appearance")]
        [Description("Specifies the margin at each side of the image.")]
        public float ImageMargin
        {
            get { return imageMargin; }
            set
            {
                if (value < 0f)
                {
                    throw new ArgumentException("Cannot be negative.", "ImageMargin");
                }
                if (imageMargin != value)
                {
                    imageMargin = value;
                    Refresh();
                }
            }
        }

        private Color highlightColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);

        /// <summary>
        /// Gets and sets the color used for the highlight.
        /// </summary>
        [Category("Highlight")]
        [Description("The color to use for the highlight.")]
        [DefaultValue(typeof(Color), "GradientActiveCaption")]
        public Color HighlightColor
        {
            get { return highlightColor; }
            set
            {
                if (highlightColor != value)
                {
                    highlightColor = value;
                    Refresh();
                }
            }
        }

        private float hightlightWidth = 2f;

        /// <summary>
        /// Gets and sets the width of the highlight.
        /// </summary>
        [Category("Highlight")]
        [Description("The width of the highlight line.")]
        public float HighlightWidth
        {
            get { return hightlightWidth; }
            set
            {
                if (value < 0f)
                {
                    throw new ArgumentException("Cannot be negative.", "HighlightWidth");
                }
                if (hightlightWidth != value)
                {
                    hightlightWidth = value;
                    Refresh();
                }
            }
        }

        private float rounding = 10f;

        /// <summary>
        /// Gets and sets the rounding factor controlling how round the corners of the highlight are.
        /// </summary>
        [Category("Highlight")]
        [Description("Controls how round the corners of the highlight are.")]
        public float Rounding
        {
            get { return rounding; }
            set
            {
                if (rounding != value)
                {
                    rounding = value;
                    Refresh();
                }
            }
        }

        private bool useHighlighFill = true;

        /// <summary>
        /// Gets and sets whether the interior background colour of the control will be blended with the highlight
        /// color when the highlight is shown.
        /// </summary>
        [Category("Highlight")]
        [Description("When true the interior background of the control will be blended with the highlight color.")]
        [DefaultValue(true)]
        public bool UseHighlighFill
        {
            get { return useHighlighFill; }
            set
            {
                if (useHighlighFill != value)
                {
                    useHighlighFill = value;
                    Refresh();
                }
            }
        }

        private byte highlightFillAlphaNormal = 50;

        /// <summary>
        /// Gets and sets the maximum value of the alpha channel used when the control is being drawn normally.
        /// </summary>
        [Category("Highlight")]
        [DefaultValue(50)]
        [Description("Sets the maximum alpha value to use for the graduated normal fill.")]
        public byte HighlightFillAlphaNormal
        {
            get { return highlightFillAlphaNormal; }
            set
            {
                if (highlightFillAlphaNormal != value)
                {
                    highlightFillAlphaNormal = value;
                    Refresh();
                }
            }
        }


        private byte highlightFillAlpha = 200;

        /// <summary>
        /// Gets and sets the maximum value of the alpha channel used when the control is focus highlighted.
        /// </summary>
        [Category("Highlight")]
        [DefaultValue(200)]
        [Description("Sets the maximum alpha value to use for the graduated highlight fill.")]
        public byte HighlightFillAlpha
        {
            get { return highlightFillAlpha; }
            set
            {
                if (highlightFillAlpha != value)
                {
                    highlightFillAlpha = value;
                    Refresh();
                }
            }
        }

        private byte highlightFillAlphaMouse = 100;

        /// <summary>
        /// Gets and sets the maximum value of the alpha channel used when the control is mouse highlighted.
        /// </summary>
        [Category("Highlight")]
        [DefaultValue(100)]
        [Description("Sets the maximum alpha value to use for the graduated highlight fill when the the mouse is over the control.")]
        public byte HighlightFillAlphaMouse
        {
            get { return highlightFillAlphaMouse; }
            set
            {
                if (highlightFillAlphaMouse != value)
                {
                    highlightFillAlphaMouse = value;
                    Refresh();
                }
            }
        }

        #endregion

    }
}
// ReSharper restore UnusedMember.Global
// ReSharper restore MemberCanBePrivate.Global
