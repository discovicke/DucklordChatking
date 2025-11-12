using ChatClient.Core;
using Raylib_cs;

namespace ChatClient.UI.Components;


public abstract class UIComponent
{
    public Rectangle Rect { get; protected set; }
    public Color BackgroundColor { get; set; }
    public Color HoverColor { get; set; }

    public abstract void Draw();
    public abstract void Update();

    public bool IsHovered() => MouseInput.IsHovered(Rect);
}