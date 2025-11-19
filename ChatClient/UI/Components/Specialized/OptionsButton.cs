// csharp
using System.Numerics;
using ChatClient.Core.Application;
using ChatClient.Core.Infrastructure;
using ChatClient.UI.Components.Base;
using ChatClient.UI.Theme;
using Raylib_cs;

namespace ChatClient.UI.Components.Specialized
{
    /// <summary>
    /// Settings button with a vector gear icon (no text).
    /// Draws a rounded background and a cog using Raylib primitives.
    /// </summary>
    public class OptionsButton(Rectangle rect)
        : Button(rect, "", Colors.ButtonDefault, Colors.ButtonHovered, Colors.TextColor) // empty label
    {
        public override void Draw()
        {
            // Resolve hover state to pick background color
            var mouse = Raylib.GetMousePosition();
            bool hovered = Raylib.CheckCollisionPointRec(mouse, Rect);
            Color bg = hovered ? Colors.ButtonHovered : Colors.ButtonDefault;

            // Button background
            Raylib.DrawRectangleRounded(Rect, 0.12f, 12, bg);
            Raylib.DrawRectangleRoundedLinesEx(Rect, 0.12f, 12, 1f, Colors.OutlineColor);

            // --- TEST Gear Icon ---
            string gearIcon = "\uf013";
            float fontSize = Rect.Height * 0.6f;
            Vector2 textSize = Raylib.MeasureTextEx(ResourceLoader.SymbolFont, gearIcon, fontSize, 0);
            // Center icon in button
            Vector2 pos = new Vector2(
                Rect.X + (Rect.Width - textSize.X) * 0.5f,
                Rect.Y + (Rect.Height - textSize.Y) * 0.5f
            );
            Raylib.DrawTextEx(
            ResourceLoader.SymbolFont,
            gearIcon,
            pos,
            fontSize,
            0,
            Colors.TextColor
            );

            /*
            // Gear icon geometry
            Vector2 center = new(Rect.X + Rect.Width * 0.5f, Rect.Y + Rect.Height * 0.5f);
            float size = MathF.Min(Rect.Width, Rect.Height);

            // Radii
            float outerR = size * 0.32f;
            float innerR = outerR * 0.58f;   // ring thickness
            float axleR  = innerR * 0.45f;   // center hole

            // Teeth parameters
            int teeth = 8;                   // even count looks clean at small sizes
            float toothDepth = outerR * 0.28f;
            // Arc per tooth and visual width along arc
            float arc = MathF.Tau / teeth;
            float toothArc = arc * 0.60f;    // 60% of per‑tooth arc width
            float toothWidth = toothArc * outerR; // convert arc length to linear width


            // Gear ring (donut)
            DrawRing(center, innerR, outerR, Colors.UiText);
            

            // Teeth (rotated rectangles)
            for (int i = 0; i < teeth; i++)
            {
                float angle = i * (360f / teeth); // degrees
                float rad = Raylib.DEG2RAD * angle;

                // Rectangle center pushed outward to sit beyond the outer ring
                float cx = center.X + (outerR + toothDepth * 0.5f) * MathF.Cos(rad);
                float cy = center.Y + (outerR + toothDepth * 0.5f) * MathF.Sin(rad);

                var toothRect = new Rectangle(cx, cy, toothWidth, toothDepth);
                var origin = new Vector2(toothWidth * 0.5f, toothDepth * 0.5f);

                Raylib.DrawRectanglePro(toothRect, origin, angle, Colors.UiText);

            }

            // Axle hole
            Raylib.DrawCircleV(center, axleR, bg);
            Raylib.DrawCircleLines((int)center.X, (int)center.Y, axleR, Colors.OutlineColor);

            */
        }

        public override void Update()
        {
            // Keep existing behavior (navigate back if stack allows)
            if (AppState.CanGoBack && IsClicked())
            {
                Log.Info($"[BackButton] Navigating back from {AppState.CurrentScreen}");
                AppState.GoBack();
                Log.Info($"[BackButton] Navigated to {AppState.CurrentScreen}");
            }
        }

        private static void DrawRing(Vector2 center, float inner, float outer, Color color)
        {
            // Use DrawRing when available, else emulate with two circles
            // raylib_cs provides DrawRing in modern versions:
            Raylib.DrawRing(center, inner, outer, 0f, 360f, 48, color);
        }
    }
}
