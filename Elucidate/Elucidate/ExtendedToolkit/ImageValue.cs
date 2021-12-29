using System.ComponentModel;
using System.Drawing;

using Krypton.Toolkit;

namespace ExtendedControls.ExtendedToolkit.Values
{
    public class ImageValue : Storage, IContentValues
    {
        #region Static Fields

        private static readonly Image DefaultImage = new Bitmap(1, 1);//Properties.Resources.Question_32_x_32);Properties.Resources.Question_32_x_32;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the HeaderValuesBase class.
        /// </summary>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        public ImageValue(NeedPaintHandler needPaint)
        {
            // Store the provided paint notification delegate
            NeedPaint = needPaint;

            // Set initial values to the default
            ResetImage();
            ResetImageTransparentColor();
        }
        #endregion

        #region Instance Fields
        private Color transparent;

        private Image image;

        [Localizable(true)]
        [Category("Visuals")]
        [Description("Image.")]
        [RefreshProperties(RefreshProperties.All)]
        public Image Image
        {
            get => image;
            set
            {
                if (image != value)
                {
                    image = value;
                    PerformNeedPaint(true);
                }
            }

        }
        #endregion

        #region IsDefault
        /// <summary>
        /// Gets a value indicating if all values are default.
        /// </summary>
        [Browsable(false)]
        public override bool IsDefault => ((Image == DefaultImage) &&
                                           (ImageTransparentColor == Color.Empty)
                                           );

        #endregion

        private bool ShouldSerializeImage() => Image != DefaultImage;

        #region IContentValues
        /// <summary>
        /// Resets the Image property to its default value.
        /// </summary>
        public void ResetImage()
        {
            Image = DefaultImage;
        }

        /// <summary>
        /// Gets the content short text.
        /// </summary>
        /// <returns>String value.</returns>
        public Image GetImage(PaletteState state) => Image;

        public string GetShortText() => string.Empty;

        public string GetLongText() => string.Empty;

        #endregion

        #region ImageTransparentColor
        /// <summary>
        /// Gets and sets the heading image transparent color.
        /// </summary>
        [Localizable(true)]
        [Category("Visuals")]
        [Description("Image transparent color.")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        [KryptonDefaultColorAttribute()]
        public Color ImageTransparentColor
        {
            get => transparent;

            set
            {
                if (transparent != value)
                {
                    transparent = value;
                    PerformNeedPaint(true);
                }
            }
        }

        private bool ShouldSerializeImageTransparentColor() => ImageTransparentColor != Color.Empty;

        /// <summary>
        /// Resets the ImageTransparentColor property to its default value.
        /// </summary>
        public void ResetImageTransparentColor()
        {
            ImageTransparentColor = Color.Empty;
        }

        /// <summary>
        /// Gets the content image transparent color.
        /// </summary>
        /// <param name="state">The state for which the image color is needed.</param>
        /// <returns>Color value.</returns>
        public virtual Color GetImageTransparentColor(PaletteState state) => ImageTransparentColor;

        #endregion


    }
}
