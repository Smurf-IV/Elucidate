using System.ComponentModel;
using ComponentFactory.Krypton.Toolkit;
using ExtendedControls.ExtendedToolkit.Values;

namespace Elucidate.ExtendedToolkit
{
    public class CommandLinkToolTipValues : CommandLinkTextValues
    {
        public CommandLinkToolTipValues(NeedPaintHandler needPaint) 
            : base(needPaint)
        {
        }

        /// <summary>
        /// Gets and sets the EnableToolTips
        /// </summary>
        [DefaultValue(false)]
        public bool EnableToolTips { get; set; }

        #region ToolTipStyle
        /// <summary>
        /// Gets and sets the tooltip label style.
        /// </summary>
        [Description("Button tooltip label style.")]
        [DefaultValue(typeof(LabelStyle), "Tooltip")]
        public LabelStyle ToolTipStyle { get; set; }

        private bool ShouldSerializeToolTipStyle()
        {
            return ToolTipStyle != LabelStyle.ToolTip;
        }

        /// <summary>
        /// Resets the ToolTipStyle property to its default value.
        /// </summary>
        public void ResetToolTipStyle()
        {
            ToolTipStyle = LabelStyle.ToolTip;
        }
        #endregion

        #region IsDefault
        /// <summary>
        /// Gets a value indicating if all values are default.
        /// </summary>
        [Browsable(false)]
        public override bool IsDefault => (!EnableToolTips 
                                           && (ToolTipStyle == LabelStyle.ToolTip)
                                           && base.IsDefault
                                           );


        #endregion

    }
}
