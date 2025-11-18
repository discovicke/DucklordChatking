using System.Numerics;
using ChatClient.Core.Infrastructure;
using ChatClient.Core.Input;
using ChatClient.UI.Theme;
using Raylib_cs;

namespace ChatClient.UI.Components.Base;

/// <summary>
/// Responsible for: rendering a checkbox with label and handling toggle state.
/// Provides visual feedback through hover effects and checked/unchecked states.
/// </summary>
public class ToggleBox : UIComponent
{
    private string Label;
    private bool isChecked;
    private const float LabelSpacing = 8f;

    public bool IsChecked => isChecked;

    public ToggleBox(Rectangle rect, string label, bool initialState = false)
    {
        Rect = rect;
        Label = label;
        isChecked = initialState;
    }

    public override void Draw()
    {
        bool hovered = MouseInput.IsHovered(Rect);

        // Checkbox background
        Color bgColor = isChecked ? Colors.BrandGold : Colors.TextFieldUnselected;
        Raylib.DrawRectangleRounded(Rect, 0.15f, 8, bgColor);

        // Border
        Color borderColor = hovered ? Colors.BrandGold : Colors.OutlineColor;
        Raylib.DrawRectangleRoundedLinesEx(Rect, 0.15f, 8, 2, borderColor);

        // Checkmark if checked
        if (isChecked)
        {
            float padding = Rect.Width * 0.25f;
            Vector2 center = new(Rect.X + Rect.Width / 2f, Rect.Y + Rect.Height / 2f);
            float size = Rect.Width - (padding * 2);
            Raylib.DrawCircleV(center, size / 2f, Colors.TextColor);
        }

        // Label text
        int fontSize = (int)(Rect.Height * 0.8f);
        Vector2 textSize = Raylib.MeasureTextEx(ResourceLoader.RegularFont, Label, fontSize, 0.5f);
        float textX = Rect.X + Rect.Width + LabelSpacing;
        float textY = Rect.Y + (Rect.Height - textSize.Y) / 2f;
        Raylib.DrawTextEx(ResourceLoader.RegularFont, Label, new Vector2(textX, textY), fontSize, 0.5f, Colors.TextColor);
    }

    public override void Update()
    {
        if (MouseInput.IsLeftClick(Rect))
        {
            isChecked = !isChecked;
            Raylib.PlaySound(ResourceLoader.ButtonSound);
        }
    }

    public bool IsClicked() => MouseInput.IsLeftClick(Rect);

    public void SetChecked(bool value) => isChecked = value;
}
