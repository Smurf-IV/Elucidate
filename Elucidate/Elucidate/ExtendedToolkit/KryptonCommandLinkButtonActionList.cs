using System.ComponentModel.Design;
using System.Drawing;

using ExtendedControls.ExtendedToolkit.Controls;

using Krypton.Toolkit;

namespace ExtendedControls.ExtendedToolkit.Designers
{
    internal class KryptonCommandLinkButtonActionList : DesignerActionList
    {
        #region Instance Fields
        private readonly KryptonCommandLinkButton button;
        private readonly IComponentChangeService service;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonButtonActionList class.
        /// </summary>
        /// <param name="owner">Designer that owns this action list instance.</param>
        public KryptonCommandLinkButtonActionList(KryptonCommandLinkButtonDesigner owner)
            : base(owner.Component)
        {
            // Remember the button instance
            button = owner.Component as KryptonCommandLinkButton;

            // Cache service used to notify when a property has changed
            service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
        }
        #endregion

        #region Public
        /// <summary>
        /// Gets and sets the button style.
        /// </summary>
        public ButtonStyle ButtonStyle
        {
            get => button.ButtonStyle;

            set
            {
                if (button.ButtonStyle != value)
                {
                    service.OnComponentChanged(button, null, button.ButtonStyle, value);
                    button.ButtonStyle = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the visual orientation.
        /// </summary>
        public VisualOrientation Orientation
        {
            get => button.Orientation;

            set
            {
                if (button.Orientation != value)
                {
                    service.OnComponentChanged(button, null, button.Orientation, value);
                    button.Orientation = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the button text.
        /// </summary>
        public string Heading
        {
            get => button.CommandLinkTextValues.Heading;

            set
            {
                if (button.CommandLinkTextValues.Heading != value)
                {
                    service.OnComponentChanged(button, null, button.CommandLinkTextValues.Heading, value);
                    button.CommandLinkTextValues.Heading = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the extra button text.
        /// </summary>
        public string Description
        {
            get => button.CommandLinkTextValues.Description;

            set
            {
                if (button.CommandLinkTextValues.Description != value)
                {
                    service.OnComponentChanged(button, null, button.CommandLinkTextValues.Description, value);
                    button.CommandLinkTextValues.Description = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the button image.
        /// </summary>
        public Image Image
        {
            get => button.CommandLinkImageValue.Image;

            set
            {
                if (button.CommandLinkImageValue.Image != value)
                {
                    service.OnComponentChanged(button, null, button.CommandLinkImageValue.Image, value);
                    button.CommandLinkImageValue.Image = value;
                }
            }
        }

        /// <summary>
        /// Gets and sets the palette mode.
        /// </summary>
        public PaletteMode PaletteMode
        {
            get => button.PaletteMode;

            set
            {
                if (button.PaletteMode != value)
                {
                    service.OnComponentChanged(button, null, button.PaletteMode, value);
                    button.PaletteMode = value;
                }
            }
        }
        #endregion

        #region Public Override
        /// <summary>
        /// Returns the collection of DesignerActionItem objects contained in the list.
        /// </summary>
        /// <returns>A DesignerActionItem array that contains the items in this list.</returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            // Create a new collection for holding the single item we want to create
            var actions = new DesignerActionItemCollection();

            // This can be null when deleting a control instance at design time
            if (button != null)
            {
                // Add the list of button specific actions
                actions.Add(new DesignerActionHeaderItem("Appearance"));
                actions.Add(new DesignerActionPropertyItem("Orientation", "Orientation", "Appearance", "Button orientation"));
                actions.Add(new DesignerActionHeaderItem("CommandLink"));
                actions.Add(new DesignerActionPropertyItem("Heading", "Heading", "CommandLink", "Button Heading text"));
                actions.Add(new DesignerActionPropertyItem("Description", "Description", "CommandLink", "Button Subscript Description text"));
                actions.Add(new DesignerActionPropertyItem("Image", "Image", "CommandLink", "Button image"));
                actions.Add(new DesignerActionHeaderItem("Visuals"));
                actions.Add(new DesignerActionPropertyItem("ButtonStyle", "Style", "Visuals", "Button style"));
                actions.Add(new DesignerActionPropertyItem("PaletteMode", "Palette", "Visuals", "Palette applied to drawing"));
            }

            return actions;
        }
        #endregion
    }
}
