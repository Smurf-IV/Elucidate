using System.ComponentModel;

using Krypton.Toolkit;

namespace ExtendedControls.ExtendedToolkit.Values
{
    public class CommandLinkTextValues : CaptionValues
    {
        private const string DEFAULT_HEADING = @"Command Link V1";
        private const string DEFAULT_DESCRIPTION = @"Here be the ""Note Text""";

        public CommandLinkTextValues(NeedPaintHandler needPaint)
            : base(needPaint)
        {
        }

        protected override string GetHeadingDefault() => DEFAULT_HEADING;

        protected override string GetDescriptionDefault() => DEFAULT_DESCRIPTION;

        #region Description
        /// <summary>
        /// Gets and sets the header description text.
        /// </summary>
        [DefaultValue(DEFAULT_DESCRIPTION)]
        public override string Description
        {
            get => base.Description;
            set => base.Description = value;
        }
        #endregion

        public void ResetText()
        {
            Heading = DEFAULT_HEADING;
            Description = DEFAULT_DESCRIPTION;
        }
    }
}
