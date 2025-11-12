using System.Numerics;
using ChatClient.Core;
using ChatClient.UI.Components;
using Raylib_cs;

namespace ChatClient.UI.Screens
{
    public class StartScreen
    {
        private static Texture2D logo = Raylib.LoadTexture(@"Bilder/DuckLord1.0.png");
        
        // UI Components
        private static TextField userField = new TextField(
            new Rectangle(0, 0, 0, 0),
            Colors.TextFieldColor, Colors.HoverColor, Colors.TextColor,
            allowMultiline: false
        );

        private static TextField passwordField = new TextField(
            new Rectangle(0, 0, 0, 0),
            Colors.TextFieldColor, Colors.HoverColor, Colors.TextColor,
            allowMultiline: false,
            isPassword: true
        );

        // Buttons
        private static Button registerButton = new Button(
            new Rectangle(0, 0, 0, 0),
            "Register", Colors.TextFieldColor, Colors.HoverColor, Colors.TextColor
        );

        private static Button loginButton = new Button(
            new Rectangle(0, 0, 0, 0),
            "Login", Colors.TextFieldColor, Colors.HoverColor, Colors.TextColor
        );

        private static OptionsButton Ducktions = new OptionsButton(
            new Rectangle(0, 0, 0, 0)
        );
        
        
        // Layout and state variables
        private static bool initialized = false;
        private static Rectangle userRect, passRect;
        private static float logoX, logoY, logoScale;
        private static float screenHeight;

        // Main function
        public static void Run()
        {
            if (!initialized)
            {
                InitializeUI();
                initialized = true;
            }

            UpdateAndDraw();
        }

        // UI Initialization (calculate positions and sizes)
        // Updates when screen size changes
        private static void InitializeUI()
        {
            float screenWidth = Raylib.GetScreenWidth();
            screenHeight = Raylib.GetScreenHeight();

            // Create UI wrapper for layout
            // Covers full window
            var uiWrapper = new UIWrapper();
            uiWrapper.SetToFullWindow();

            // Dynamic sizing based on screen dimensions
            float fieldWidth = screenWidth * 0.3f;
            float fieldHeight = screenHeight * 0.05f;
            float buttonWidth = screenWidth * 0.125f;
            float buttonHeight = screenHeight * 0.05f;
            float gap = screenHeight * 0.02f;
            // Starting top position (Y axis) for first column
            float colTop = screenHeight * 0.45f;

            // Calculate rectangles for each component
            // Centered horizontally in the window
            userRect = uiWrapper.CenterHoriz(fieldWidth, fieldHeight, colTop);
            passRect = uiWrapper.CenterHoriz(fieldWidth, fieldHeight, colTop + fieldHeight + gap);
            var loginRect = uiWrapper.CenterHoriz(buttonWidth, buttonHeight, colTop + 2 * (fieldHeight + gap));
            var registerRect = uiWrapper.CenterHoriz(buttonWidth, buttonHeight, colTop + 3 * (fieldHeight + gap));
            var optionsRect = uiWrapper.CenterHoriz(buttonWidth, buttonHeight, colTop + 4 * (fieldHeight + gap));

            // Assigns the calculated rectangles to the UI components
            // Aligns logics and methods with their visual representation
            userField.SetRect(userRect);
            passwordField.SetRect(passRect);
            loginButton.SetRect(loginRect);
            registerButton.SetRect(registerRect);
            Ducktions.SetRect(optionsRect);

            // Logo placement and scale
            float logoTargetWidth = screenWidth * 0.15f;
            logoScale = logo.Width > 0 ? logoTargetWidth / logo.Width : 0.15f;
            logoX = (screenWidth - logo.Width * logoScale) / 2f;
            logoY = screenHeight * 0.10f;
        }

        // Update and draw UI elements each frame
        public static void UpdateAndDraw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Colors.BackgroundColor);
            
            // Draw labels for text fields
            int labelFont = 15;
            int labelYUser = (int)(userRect.Y + (userRect.Height - labelFont) / 2f);
            int labelYPass = (int)(passRect.Y + (passRect.Height - labelFont) / 2f);
            Raylib.DrawText("Username:", (int)(userRect.X - 110), labelYUser, labelFont, Colors.TextFieldColor);
            Raylib.DrawText("Password:", (int)(passRect.X - 110), labelYPass, labelFont, Colors.TextFieldColor);

            // Button logic (screen changes)
            if (MouseInput.IsLeftClick(loginButton.Rect) || Raylib.IsKeyPressed(KeyboardKey.Enter))
            {
                AppState.CurrentScreen = Screen.Chat;
                Log.Info("User logged in, switching to chat screen");
                passwordField.Clear();
                userField.Clear();
            }

            if (MouseInput.IsLeftClick(registerButton.Rect))
            {
                AppState.CurrentScreen = Screen.Register;
                Log.Info("User want to register, switching to register screen");
                passwordField.Clear();
                userField.Clear();
            }

            if (MouseInput.IsLeftClick(Ducktions.Rect))
            {
                AppState.CurrentScreen = Screen.Options;
                Log.Info("User pressed options / Ducktions screen");
                passwordField.Clear();
                userField.Clear();
            }
            
            // Update and draw fields/buttons
            userField.Update();
            userField.Draw();

            passwordField.Update();
            passwordField.Draw();

            registerButton.Draw();
            loginButton.Draw();
            Ducktions.Draw();

            // Draw logo & version text
            Raylib.DrawTextureEx(logo, new Vector2(logoX, logoY), 0, logoScale, Color.White);
            Raylib.DrawText("DuckLord v.0.0.2", 10, (int)(screenHeight - 20), 10, Colors.TextColor);
            Raylib.EndDrawing();
        }
    }
}