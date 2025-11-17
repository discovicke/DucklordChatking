using System.Collections.Generic;
using System.Numerics;
using ChatClient.Core;
using Raylib_cs;

namespace ChatClient.UI.Components;

/// <summary>
/// Responsible for: rendering online/offline user lists in a scrollable panel.
/// </summary>
public class UserListView
{
    private readonly ScrollablePanel _panel;
    private Rectangle _bounds;

    public UserListView(ScrollablePanel panel)
    {
        _panel = panel;
    }

    public void SetBounds(Rectangle bounds)
    {
        _bounds = bounds;
        _panel.SetBounds(bounds);
    }

    public void Render(IReadOnlyList<string> onlineUsers, IReadOnlyList<string> offlineUsers)
    {
        const float lineH = 22f;
        const float fontSize = 14f;
        const float inset = 10f;

        float totalHeight = lineH + (onlineUsers.Count * lineH) + 10 + lineH + (offlineUsers.Count * lineH);
        _panel.BeginScroll(totalHeight);

        float x = _bounds.X + inset;
        float y = _bounds.Y + inset;

        // Online header
        float scrolledY = _panel.GetScrolledY(y);
        Raylib.DrawTextEx(ResourceLoader.BoldFont, "ONLINE", new Vector2(x, scrolledY), fontSize, 0.5f, Colors.AccentColor);
        y += lineH;

        // Online users
        foreach (var user in onlineUsers)
        {
            scrolledY = _panel.GetScrolledY(y);
            if (_panel.IsVisible(scrolledY, lineH))
            {
                Raylib.DrawCircle((int)x + 5, (int)scrolledY + 7, 4f, Colors.AccentColor);
                Raylib.DrawTextEx(ResourceLoader.RegularFont, user, new Vector2(x + 15, scrolledY), fontSize, 0.5f, Colors.UiText);
            }
            y += lineH;
        }

        y += 10;

        // Offline header
        scrolledY = _panel.GetScrolledY(y);
        Raylib.DrawTextEx(ResourceLoader.BoldFont, "OFFLINE", new Vector2(x, scrolledY), fontSize, 0.5f, Colors.SubtleText);
        y += lineH;

        // Offline users
        foreach (var user in offlineUsers)
        {
            scrolledY = _panel.GetScrolledY(y);
            if (_panel.IsVisible(scrolledY, lineH))
            {
                Raylib.DrawCircle((int)x + 5, (int)scrolledY + 7, 4f, Colors.SubtleText);
                Raylib.DrawTextEx(ResourceLoader.RegularFont, user, new Vector2(x + 15, scrolledY), fontSize, 0.5f, Colors.SubtleText);
            }
            y += lineH;
        }

        _panel.EndScroll();
    }
}

