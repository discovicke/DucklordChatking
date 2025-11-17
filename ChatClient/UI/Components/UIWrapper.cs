using Raylib_cs;

namespace ChatClient.UI.Components;

class UIWrapper
{
    public float Width, Height;
    
    public void SetToFullWindow()
    {
        //int rw = Raylib.GetRenderWidth();
        //int rh = Raylib.GetRenderHeight();
        int sw = Raylib.GetScreenWidth();
        int sh = Raylib.GetScreenHeight();

        //Width = (rw > 0 ? rw : sw);
        //Height = (rh > 0 ? rh : sh);
        Width = sw;
        Height = sh;
    }

    // Center a child horizontally at a given y-offset (relative to this wrapper)
    public Rectangle CenterHoriz(float width, float height, float top)
    {
        float x = (Width - width) * 0.5f;
        return new Rectangle(x, top, width, height);
    }
}   
