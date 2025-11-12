using Raylib_cs;

namespace ChatClient.UI.Components;

class UIWrapper
{
    public float X, Y;

    public float Width, Height;
    // Optional: container children if you need it later
    //public List<UIElement> Children = new();

    public Rectangle Bounds => new Rectangle(X, Y, Width, Height);

    public void SetToFullWindow()
    {
        X = 0;
        Y = 0;
        Width = Raylib.GetScreenWidth();
        Height = Raylib.GetScreenHeight();
    }

    // Center a child horizontally at a given y-offset (relative to this wrapper)
    public Rectangle CenterHoriz(float childWidth, float childHeight, float y)
    {
        return new Rectangle(
            X + (Width - childWidth) / 2f,
            Y + y,
            childWidth,
            childHeight
        );
    }

    // Place a child at x/y (relative to this wrapper)
    public Rectangle At(float x, float y, float w, float h)
    {
        return new Rectangle(X + x, Y + y, w, h);
    }

    // Existing helpers
   /* public void Draw()
    {
        foreach (var child in Children)
        {
            child.DrawAt(X + child.OffsetX, Y + child.OffsetY);
        }
    }

    public void CenterChildrenHorizontally()
    {
        foreach (var child in Children)
        {
            child.OffsetX = (Width - child.Width) / 2f;
        }
    }*/
}