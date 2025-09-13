using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using ExtendedControls.ExtendedToolkit.Values;
using ExtendedControls.ExtendedToolkit.View_Draw;

using Krypton.Toolkit;

namespace ExtendedControls.ExtendedToolkit.Controls;

/// <summary>
/// Combines button functionality with the styling features of the Krypton Toolkit.
/// </summary>
/// <remarks>
/// Main code taken from KryptonButton, then trimmed out to force the CommandLink layout
/// </remarks>
[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonButton), "ToolboxBitmaps.KryptonButton.bmp")] // TODO: use a local image
[DefaultEvent("Click")]
[DefaultProperty("Heading")]
[Designer(typeof(Designers.KryptonCommandLinkButtonDesigner))]
[DesignerCategory("code")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[DisplayName("Krypton Command Link")]
[Description("A Krypton Command Link Button.")]
[ComVisible(true)]
public class KryptonCommandLinkButton : VisualSimpleBase, IButtonControl
{
    #region Instance Fields
    private readonly ViewDrawCommandLinkButton drawButton;
    private ButtonStyle style;
    private readonly ButtonController buttonController;
    private VisualOrientation orientation;
    private readonly PaletteTripleOverride overrideFocus;
    private readonly PaletteTripleOverride overrideNormal;
    private readonly PaletteTripleOverride overrideTracking;
    private readonly PaletteTripleOverride overridePressed;
    private IKryptonCommand command;
    private bool isDefault;
    private bool useMnemonic;
    private bool wasEnabled;
    #endregion

    #region Events
    /// <summary>
    /// Occurs when the value of the KryptonCommand property changes.
    /// </summary>
    [Category("Property Changed")]
    [Description("Occurs when the value of the KryptonCommand property changes.")]
    public event EventHandler KryptonCommandChanged;
    #endregion

    #region Identity
    /// <summary>
    /// Initialize a new instance of the KryptonButton class.
    /// </summary>
    public KryptonCommandLinkButton()
    {
        // We generate click events manually, suppress default
        // production of them by the base Control class
        SetStyle(ControlStyles.StandardClick |
                 ControlStyles.StandardDoubleClick, false);

        // Set default button properties
        base.AutoSize = false;
        DialogResult = DialogResult.None;
        orientation = VisualOrientation.Top;
        useMnemonic = true;

        // Create content storage
        CommandLinkImageValue = new ImageValue(NeedPaintDelegate);
        CommandLinkTextValues = new CommandLinkTextValues(NeedPaintDelegate, GetDpiFactor);

        // Create the palette storage
        StateCommon = new PaletteTripleRedirect(Redirector, PaletteBackStyle.ButtonCommand, PaletteBorderStyle.ButtonCommand, PaletteContentStyle.ButtonCommand, NeedPaintDelegate);
        PaletteContentText contentShortText = StateCommon.Content.ShortText;
        contentShortText.Font = new Font(@"Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        contentShortText.TextH = PaletteRelativeAlign.Near;
        contentShortText.TextV = PaletteRelativeAlign.Center;
        StateCommon.Content.LongText.TextH = PaletteRelativeAlign.Near;
        StateCommon.Content.LongText.TextV = PaletteRelativeAlign.Far;

        StateDisabled = new PaletteTriple(StateCommon, NeedPaintDelegate);
        StateNormal = new PaletteTriple(StateCommon, NeedPaintDelegate);
        StateTracking = new PaletteTriple(StateCommon, NeedPaintDelegate);
        StatePressed = new PaletteTriple(StateCommon, NeedPaintDelegate);
        OverrideDefault = new PaletteTripleRedirect(Redirector, PaletteBackStyle.ButtonCommand, PaletteBorderStyle.ButtonCommand, PaletteContentStyle.ButtonCommand, NeedPaintDelegate);
        OverrideFocus = new PaletteTripleRedirect(Redirector, PaletteBackStyle.ButtonCommand, PaletteBorderStyle.ButtonCommand, PaletteContentStyle.ButtonCommand, NeedPaintDelegate)
        {
            Border =
                {
                    Draw = InheritBool.True,
                    DrawBorders = PaletteDrawBorders.All,
                    GraphicsHint = PaletteGraphicsHint.AntiAlias
                }
        };
        // Force style update
        ButtonStyle = ButtonStyle.Command;

        // Create the override handling classes
        overrideFocus = new PaletteTripleOverride(OverrideFocus, StateNormal, PaletteState.FocusOverride);
        overrideNormal = new PaletteTripleOverride(OverrideDefault, overrideFocus, PaletteState.NormalDefaultOverride);
        overrideTracking = new PaletteTripleOverride(OverrideFocus, StateTracking, PaletteState.FocusOverride);
        overridePressed = new PaletteTripleOverride(OverrideFocus, StatePressed, PaletteState.FocusOverride);

        // Create the view button instance
        drawButton = new ViewDrawCommandLinkButton(StateDisabled,
                                         overrideNormal,
                                         overrideTracking,
                                         overridePressed,
                                         new PaletteMetricRedirect(Redirector),
                                         CommandLinkImageValue, CommandLinkTextValues,
                                         Orientation,
                                         UseMnemonic)
        {
            // Only draw a focus rectangle when focus cues are needed in the top level form
            TestForFocusCues = true
        };

        // Create a button controller to handle button style behaviour
        buttonController = new ButtonController(drawButton, NeedPaintDelegate);

        // Assign the controller to the view element to treat as a button
        drawButton.MouseController = buttonController;
        drawButton.KeyController = buttonController;
        drawButton.SourceController = buttonController;

        // Need to know when user clicks the button view or mouse selects it
        buttonController.Click += OnButtonClick;
        buttonController.MouseSelect += OnButtonSelect;

        // Create the view manager instance
        ViewManager = new ViewManager(this, drawButton);
    }
    #endregion

    #region Public

    /// <summary>
    /// Gets and sets the automatic resize of the control to fit contents.
    /// </summary>
    [Browsable(false)]
    [Localizable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override bool AutoSize
    {
        get => base.AutoSize;
        set
        {
            // Do nothing }
        }
    }

    /// <summary>
    /// Gets and sets the internal padding space.
    /// </summary>
    [Browsable(false)]
    [Localizable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new Padding Padding
    {
        get => base.Padding;
        set => base.Padding = value;
    }

    /// <summary>
    /// Gets or sets the text associated with this control. 
    /// </summary>
    [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
    [Browsable(false)]
    [Localizable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override string Text
    {
        get => CommandLinkTextValues.Heading;

        set => CommandLinkTextValues.Heading = value;
    }

    private static bool ShouldSerializeText() =>
        // Never serialize, let the button values serialize instead
        false;

    /// <summary>
    /// Resets the Text property to its default value.
    /// </summary>
    public override void ResetText()
    {
        CommandLinkTextValues.ResetText();
    }

    /// <summary>
    /// Gets and sets the visual orientation of the control.
    /// </summary>
    [Category("Visuals")]
    [Description("Visual orientation of the control.")]
    [DefaultValue(typeof(VisualOrientation), "Top")]
    public virtual VisualOrientation Orientation
    {
        get => orientation;

        set
        {
            if (orientation != value)
            {
                orientation = value;

                // Update the associated visual elements that are effected
                drawButton.Orientation = value;

                PerformNeedPaint(true);
            }
        }
    }

    /// <summary>
    /// Gets and sets the button style.
    /// </summary>
    [Category("Visuals")]
    [Description("Button style.")]
    public ButtonStyle ButtonStyle
    {
        get => style;

        set
        {
            if (style != value)
            {
                style = value;
                SetStyles(style);
                PerformNeedPaint(true);
            }
        }
    }

    private bool ShouldSerializeButtonStyle() => (ButtonStyle != ButtonStyle.Command);

    private void ResetButtonStyle()
    {
        ButtonStyle = ButtonStyle.Command;
    }

    /// <summary>
    /// Gets access to the button content.
    /// </summary>
    [Category("CommandLink")]
    [Description("CommandLink Button Text")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public CommandLinkTextValues CommandLinkTextValues { get; }

    /// <summary>
    /// Gets access to the button content.
    /// </summary>
    [Category("CommandLink")]
    [Description("CommandLink Button Image")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ImageValue CommandLinkImageValue { get; }

    private static bool ShouldSerializeCommandLinkImageValue() => false;

    /// <summary>
    /// Gets access to the common button appearance that other states can override.
    /// </summary>
    [Category("Visuals")]
    [Description("Overrides for defining common button appearance that other states can override.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public PaletteTripleRedirect StateCommon { get; }

    private bool ShouldSerializeStateCommon() => !StateCommon.IsDefault;

    /// <summary>
    /// Gets access to the disabled button appearance entries.
    /// </summary>
    [Category("Visuals")]
    [Description("Overrides for defining disabled button appearance.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public PaletteTriple StateDisabled { get; }

    private bool ShouldSerializeStateDisabled() => !StateDisabled.IsDefault;

    /// <summary>
    /// Gets access to the normal button appearance entries.
    /// </summary>
    [Category("Visuals")]
    [Description("Overrides for defining normal button appearance.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public PaletteTriple StateNormal { get; }

    private bool ShouldSerializeStateNormal() => !StateNormal.IsDefault;

    /// <summary>
    /// Gets access to the hot tracking button appearance entries.
    /// </summary>
    [Category("Visuals")]
    [Description("Overrides for defining hot tracking button appearance.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public PaletteTriple StateTracking { get; }

    private bool ShouldSerializeStateTracking() => !StateTracking.IsDefault;

    /// <summary>
    /// Gets access to the pressed button appearance entries.
    /// </summary>
    [Category("Visuals")]
    [Description("Overrides for defining pressed button appearance.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public PaletteTriple StatePressed { get; }

    private bool ShouldSerializeStatePressed() => !StatePressed.IsDefault;

    /// <summary>
    /// Gets access to the normal button appearance when default.
    /// </summary>
    [Category("Visuals")]
    [Description("Overrides for defining normal button appearance when default.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public PaletteTripleRedirect OverrideDefault { get; }

    private bool ShouldSerializeOverrideDefault() => !OverrideDefault.IsDefault;

    /// <summary>
    /// Gets access to the button appearance when it has focus.
    /// </summary>
    [Category("Visuals")]
    [Description("Overrides for defining button appearance when it has focus.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public PaletteTripleRedirect OverrideFocus { get; }

    private bool ShouldSerializeOverrideFocus() => !OverrideFocus.IsDefault;

    /// <summary>
    /// Gets or sets the value returned to the parent form when the button is clicked.
    /// </summary>
    [Category("Behavior")]
    [Description("The dialog-box result produced in a modal form by clicking the button.")]
    [DefaultValue(typeof(DialogResult), "None")]
    public DialogResult DialogResult { get; set; }

    /// <summary>
    /// Gets and sets the associated KryptonCommand.
    /// </summary>
    [Category("Behavior")]
    [Description("Command associated with the button.")]
    [DefaultValue(null)]
    public virtual IKryptonCommand KryptonCommand
    {
        get => command;

        set
        {
            if (command == value)
                return;
            if (command != null)
            {
                command.PropertyChanged -= OnCommandPropertyChanged;
            }
            else
            {
                wasEnabled = Enabled;
            }

            command = value;
            OnKryptonCommandChanged(EventArgs.Empty);

            if (command != null)
            {
                command.PropertyChanged += OnCommandPropertyChanged;
            }
            else
            {
                Enabled = wasEnabled;
            }
        }
    }

    /// <summary>
    /// Notifies a control that it is the default button so that its appearance and behavior is adjusted accordingly. 
    /// </summary>
    /// <param name="value">true if the control should behave as a default button; otherwise false.</param>
    public void NotifyDefault(bool value)
    {
        if (!ViewDrawButton.IsFixed && (isDefault != value))
        {
            // Remember new default status
            isDefault = value;

            // Decide if the default overrides should be applied
            overrideNormal.Apply = value;

            // Change in default state requires a layout and repaint
            PerformNeedPaint(true);
        }
    }

    /// <summary>
    /// Generates a Click event for the control.
    /// </summary>
    public void PerformClick()
    {
        if (CanSelect)
        {
            OnClick(EventArgs.Empty);
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether an ampersand is included in the text of the control. 
    /// </summary>
    [Category("Appearance")]
    [Description("When true the first character after an ampersand will be used as a mnemonic.")]
    [DefaultValue(true)]
    public bool UseMnemonic
    {
        get => useMnemonic;

        set
        {
            if (useMnemonic != value)
            {
                useMnemonic = value;
                drawButton.UseMnemonic = value;
                PerformNeedPaint(true);
            }
        }
    }

    /// <summary>
    /// Fix the control to a particular palette state.
    /// </summary>
    /// <param name="state">Palette state to fix.</param>
    public virtual void SetFixedState(PaletteState state)
    {
        if (state == PaletteState.NormalDefaultOverride)
        {
            // Setup the overrides correctly to match state
            overrideFocus.Apply = true;
            overrideNormal.Apply = true;

            // Must pass a proper drawing state to the view
            state = PaletteState.Normal;
        }

        // Request fixed state from the view
        drawButton.FixedState = state;
    }

    /// <summary>
    /// Determines the IME status of the object when selected.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new ImeMode ImeMode
    {
        get => base.ImeMode;
        set => base.ImeMode = value;
    }
    #endregion

    #region Protected Overrides
    /// <summary>
    /// Gets the default size of the control.
    /// </summary>
    protected override Size DefaultSize => new (250, 55);

    /// <summary>
    /// Gets the default Input Method Editor (IME) mode supported by this control.
    /// </summary>
    protected override ImeMode DefaultImeMode => ImeMode.Disable;

    /// <summary>
    /// Raises the EnabledChanged event.
    /// </summary>
    /// <param name="e">An EventArgs that contains the event data.</param>
    protected override void OnEnabledChanged(EventArgs e)
    {
        // Change in enabled state requires a layout and repaint
        PerformNeedPaint(true);

        // Let base class fire standard event
        base.OnEnabledChanged(e);
    }

    /// <summary>
    /// Raises the GotFocus event.
    /// </summary>
    /// <param name="e">An EventArgs that contains the event data.</param>
    protected override void OnGotFocus(EventArgs e)
    {
        if (!ViewDrawButton.IsFixed)
        {
            // Apply the focus overrides
            overrideFocus.Apply = true;
            overrideTracking.Apply = true;
            overridePressed.Apply = true;

            // Change in focus requires a repaint
            PerformNeedPaint(false);
        }

        // Let base class fire standard event
        base.OnGotFocus(e);
    }

    /// <summary>
    /// Raises the LostFocus event.
    /// </summary>
    /// <param name="e">An EventArgs that contains the event data.</param>
    protected override void OnLostFocus(EventArgs e)
    {
        if (!ViewDrawButton.IsFixed)
        {
            // Apply the focus overrides
            overrideFocus.Apply = false;
            overrideTracking.Apply = false;
            overridePressed.Apply = false;

            // Change in focus requires a repaint
            PerformNeedPaint(false);
        }

        // Let base class fire standard event
        base.OnLostFocus(e);
    }

    /// <summary>
    /// Raises the Click event.
    /// </summary>
    /// <param name="e">An EventArgs that contains the event data.</param>
    protected override void OnClick(EventArgs e)
    {
        // Find the form this button is on
        Form owner = FindForm();

        // If we find a valid owner
        if (owner != null)
        {
            // Update owner with our dialog result setting
            owner.DialogResult = DialogResult;
        }

        // Let base class fire standard event
        base.OnClick(e);

        // If we have an attached command then execute it
        KryptonCommand?.PerformExecute();
    }

    /// <summary>
    /// Processes a mnemonic character.
    /// </summary>
    /// <param name="charCode">The mnemonic character entered.</param>
    /// <returns>true if the mnemonic was processed; otherwise, false.</returns>
    protected override bool ProcessMnemonic(char charCode)
    {
        // Are we allowed to process mnemonics?
        if (UseMnemonic && CanProcessMnemonic())
        {
            // Does the button primary text contain the mnemonic?
            if (IsMnemonic(charCode, CommandLinkTextValues.Heading))
            {
                // Perform default action for a button, click it!
                PerformClick();
                return true;
            }
        }

        // No match found, let base class do standard processing
        return base.ProcessMnemonic(charCode);
    }

    /// <summary>
    /// Called when a context menu has just been closed.
    /// </summary>
    protected override void ContextMenuClosed()
    {
        buttonController.RemoveFixed();
    }

    #endregion

    #region Protected Virtual
    /// <summary>
    /// Update the state objects to reflect the new button style.
    /// </summary>
    /// <param name="buttonStyle">New button style.</param>
    protected virtual void SetStyles(ButtonStyle buttonStyle)
    {
        StateCommon.SetStyles(buttonStyle);
        OverrideDefault.SetStyles(buttonStyle);
        OverrideFocus.SetStyles(buttonStyle);
    }

    /// <summary>
    /// Creates a values storage object appropriate for control.
    /// </summary>
    /// <returns>Set of button values.</returns>
    /// <param name="needPaint">Delegate for notifying paint requests.</param>
    protected virtual ButtonValues CreateButtonValues(NeedPaintHandler needPaint) => new (needPaint);

    /// <summary>
    /// Raises the KryptonCommandChanged event.
    /// </summary>
    /// <param name="e">An EventArgs containing the event data.</param>
    protected virtual void OnKryptonCommandChanged(EventArgs e)
    {
        KryptonCommandChanged?.Invoke(this, e);

        // Use the values from the new command
        if (KryptonCommand != null)
        {
            Enabled = KryptonCommand.Enabled;
        }

        // Redraw to update the text/extratext/image properties
        PerformNeedPaint(true);
    }

    /// <summary>
    /// Handles a change in the property of an attached command.
    /// </summary>
    /// <param name="sender">Source of the event.</param>
    /// <param name="e">A PropertyChangedEventArgs that contains the event data.</param>
    protected virtual void OnCommandPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case @"Enabled":
                Enabled = KryptonCommand.Enabled;
                break;
            case @"Text":
            case @"ExtraText":
            case @"ImageSmall":
            case @"ImageTransparentColor":
                PerformNeedPaint(true);
                break;
        }
    }

    /// <summary>
    /// Gets access to the view element for the color button.
    /// </summary>
    protected virtual ViewDrawCommandLinkButton ViewDrawButton => drawButton;

    #endregion

    #region Implementation
    private float GetDpiFactor()
    {
        return DeviceDpi / 96F;
    }

    private void OnButtonTextChanged(object sender, EventArgs e)
    {
        OnTextChanged(EventArgs.Empty);
    }

    private void OnButtonClick(object sender, MouseEventArgs e)
    {
        // Raise the standard click event
        OnClick(EventArgs.Empty);

        // Raise event to indicate it was a mouse activated click
        OnMouseClick(e);
    }

    private void OnButtonSelect(object sender, MouseEventArgs e)
    {
        // Take the focus if allowed
        if (CanFocus)
        {
            Focus();
        }
    }

    #endregion
}