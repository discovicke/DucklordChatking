using ChatClient.UI.Components.Layout;
using Raylib_cs;

namespace ChatClient.UI.Screens.Chat;

/// <summary>
/// Responsible for: calculating layout positions for all UI elements on the chat screen.
/// Determines chat window, user list, input field, send button, and logo placement with dynamic sizing.
/// </summary>
public static class ChatScreenLayout
{
    public struct LayoutData
    {
        public Rectangle ChatRect, InputRect, SendRect, BackRect, UserListRect, OptionsRect;
        public float LogoX, LogoY, LogoScale, LogoWidth, LogoHeight;
    }

    public static LayoutData Calculate(int logoWidth, int logoHeight)
    {
        var wrap = new UIWrapper(); 
        wrap.SetToFullWindow(); // Must call this to get current window dimensions
        
        float w = wrap.Width;
        float h = wrap.Height;
        // --- New margin below Sign out/options buttons ---
        float topBarMargin = 50f;
        

        // Logo
        float logoTargetW = w * 0.15f;
        float logoScale = logoWidth > 0 ? logoTargetW / logoWidth : 0.14f;
        float scaledLogoHeight = logoHeight * logoScale;
        float scaledLogoWidth = logoWidth * logoScale;

        // --- New calc ---
        float logoX = w - scaledLogoWidth - 20f;
        float logoY = 0f; // Temporary value, will be updated later
        // --- ---
        
        // --- Old calc ---
        //float logoX = w - scaledLogoWidth - 20f;
        //float logoY = 20f;
        // --- ---
        
        // Chat window: 10px spacing to logo border and top left of screen
        float chatX = 10f;
        float chatW = logoX - chatX - 10f; // To logos left border minus 10px spacing
        float chatH = h * 0.65f; // Temporary value
        float chatY = topBarMargin;

        // Input field: samma bredd som chat, men lämna plats för send-knappen
        // --- New calc ---
        float inputH = h * 0.14f;
        float inputY = h - inputH - 20f;


        // --- Old calc ---
        //float inputY = chatY + chatH + h * 0.03f;
        //float inputH = h * 0.14f;
        // --- ---
        float btnW = 100f; // Fast bredd för send-knapp
        float inputW = chatW - btnW - 10f; // Minus knappbredd och spacing

        // --- Update logoY ---
        logoY = inputY + inputH - scaledLogoHeight;
        // --- ---
        // --- Update chatH ---
        chatH = inputY - chatY - 20f;

        // User list (höger om chat, över loggan)
        // --- New Calc ---
        float userListX = w - scaledLogoWidth - 20f;
        float userListY = chatY;
        float userListW = scaledLogoWidth;
        float userListH = logoY - userListY - 20f;
        // --- ---

        // --- Old clac ---
        //float userListX = logoX;
        //float userListY = logoY + scaledLogoHeight + 10f; // 10px under loggan
        //float userListW = scaledLogoWidth;
        //float userListH = h - userListY - 10f; // Till fönstrets nederkant minus 10px
        // --- ---

        // Options 
        float optionsW = 40f;
        float optionsH = 30f;
        float optionsX = w - optionsW - 20f;
        float optionsY = 10f;


        
        var chatRect = new Rectangle(chatX, chatY, chatW, chatH);
        var inputRect = new Rectangle(chatX, inputY, inputW, inputH);
        var sendRect = new Rectangle(chatX + inputW + 10f, inputY, btnW, inputH);
        var backRect = new Rectangle(10, 10, 100, 30);
        // --- Options ---
        // --- Old Options ---
        //var optionsRect = new Rectangle(800, 10, 50, 30);

        // --- New Options ---
        var optionsRect = new Rectangle(optionsX, optionsY, optionsW, optionsH);

        // --- ---
        var userListRect = new Rectangle(userListX, userListY, userListW, userListH);

        return new LayoutData
        {
            ChatRect = chatRect,
            InputRect = inputRect,
            SendRect = sendRect,
            BackRect = backRect,
            UserListRect = userListRect,
            LogoScale = logoScale,
            LogoX = logoX,
            LogoY = logoY,
            LogoWidth = scaledLogoWidth,
            LogoHeight = scaledLogoHeight,
            // --- Options ---
            OptionsRect = optionsRect
            // --- ---
        };
    }
}