#region License (c)

// The MIT License (MIT)
// Copyright (c) 2013-2014 Simon Coghlan (Smurf-IV)
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
// associated documentation files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modify, merge, publish, distribute,
// sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
// NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion License (c)

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

// ReSharper disable UnusedMember.Global
public class ToolStripCheckBoxMenuItem : ToolStripMenuItem
{
    public ToolStripCheckBoxMenuItem()
    {
        Initialize();
    }

    public ToolStripCheckBoxMenuItem(string text)
       : base(text, null, (EventHandler)null)
    {
        Initialize();
    }

    public ToolStripCheckBoxMenuItem(Image image)
       : base(null, image, (EventHandler)null)
    {
        Initialize();
    }

    public ToolStripCheckBoxMenuItem(string text, Image image)
       : base(text, image, (EventHandler)null)
    {
        Initialize();
    }

    public ToolStripCheckBoxMenuItem(string text, Image image,
        EventHandler onClick)
       : base(text, image, onClick)
    {
        Initialize();
    }

    public ToolStripCheckBoxMenuItem(string text, Image image,
        EventHandler onClick, string name)
       : base(text, image, onClick, name)
    {
        Initialize();
    }

    public ToolStripCheckBoxMenuItem(string text, Image image,
        params ToolStripItem[] dropDownItems)
       : base(text, image, dropDownItems)
    {
        Initialize();
    }

    public ToolStripCheckBoxMenuItem(string text, Image image,
        EventHandler onClick, Keys shortcutKeys)
       : base(text, image, onClick)
    {
        Initialize();
        ShortcutKeys = shortcutKeys;
    }

    // Called by all constructors to initialize CheckOnClick.
    private void Initialize()
    {
        CheckOnClick = true;
    }

    // Let the item paint itself, and then paint the RadioButton
    // where the check mark is normally displayed.
    protected override void OnPaint(PaintEventArgs e)
    {
        if (Image != null)
        {
            // If the client sets the Image property, the selection behavior
            // remains unchanged, but the RadioButton is not displayed and the
            // selection is indicated only by the selection rectangle.
            base.OnPaint(e);
            return;
        }
        else
        {
            // If the Image property is not set, call the base OnPaint method
            // with the CheckState property temporarily cleared to prevent
            // the check mark from being painted.
            CheckState currentState = CheckState;
            CheckState = CheckState.Unchecked;
            base.OnPaint(e);
            CheckState = currentState;
        }

        // Determine the correct state of the RadioButton.
        CheckBoxState buttonState = CheckBoxState.UncheckedNormal;
        if (Enabled)
        {
            if (mouseDownState)
            {
                buttonState = Checked ? CheckBoxState.CheckedPressed : CheckBoxState.UncheckedPressed;
            }
            else if (mouseHoverState)
            {
                buttonState = Checked ? CheckBoxState.CheckedHot : CheckBoxState.UncheckedHot;
            }
            else
            {
                if (Checked)
                {
                    buttonState = CheckBoxState.CheckedNormal;
                }
            }
        }
        else
        {
            buttonState = Checked ? CheckBoxState.CheckedDisabled : CheckBoxState.UncheckedDisabled;
        }

        // Calculate the position at which to display the RadioButton.
        Int32 offset = (ContentRectangle.Height - CheckBoxRenderer.GetGlyphSize(e.Graphics, buttonState).Height) / 2;
        Point imageLocation = new Point(ContentRectangle.Location.X + 4, ContentRectangle.Location.Y + offset);

        // Paint the RadioButton.
        CheckBoxRenderer.DrawCheckBox(e.Graphics, imageLocation, buttonState);
    }

    private bool mouseHoverState;

    protected override void OnMouseEnter(EventArgs e)
    {
        mouseHoverState = true;

        // Force the item to repaint with the new RadioButton state.
        Invalidate();

        base.OnMouseEnter(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        mouseHoverState = false;
        base.OnMouseLeave(e);
    }

    private bool mouseDownState;

    protected override void OnMouseDown(MouseEventArgs e)
    {
        mouseDownState = true;

        // Force the item to repaint with the new RadioButton state.
        Invalidate();

        base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        mouseDownState = false;
        base.OnMouseUp(e);
    }

    // Enable the item only if its parent item is in the checked state
    // and its Enabled property has not been explicitly set to false.
    public override bool Enabled
    {
        get
        {
            ToolStripMenuItem ownerMenuItem = OwnerItem as ToolStripMenuItem;

            // Use the base value in design mode to prevent the designer
            // from setting the base value to the calculated value.
            return (!DesignMode
                  && (ownerMenuItem != null)
                  && ownerMenuItem.CheckOnClick
                  )
                      ? base.Enabled && ownerMenuItem.Checked
                      : base.Enabled;
        }
        set => base.Enabled = value;
    }

    // When OwnerItem becomes available, if it is a ToolStripMenuItem
    // with a CheckOnClick property value of true, subscribe to its
    // CheckedChanged event.
    protected override void OnOwnerChanged(EventArgs e)
    {
        if (OwnerItem is ToolStripMenuItem ownerMenuItem && ownerMenuItem.CheckOnClick)
        {
            ownerMenuItem.CheckedChanged += OwnerMenuItem_CheckedChanged;
        }
        base.OnOwnerChanged(e);
    }

    // When the checked state of the parent item changes,
    // repaint the item so that the new Enabled state is displayed.
    private void OwnerMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        Invalidate();
    }
}
// ReSharper restore UnusedMember.Global
