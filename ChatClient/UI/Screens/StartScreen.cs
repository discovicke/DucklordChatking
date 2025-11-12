using System.Numerics;
using ChatClient.Core;
using ChatClient.UI.Components;
using Raylib_cs;

namespace ChatClient.UI.Screens
{
    public class StartScreen
    {
        private static Texture2D logo = Raylib.LoadTexture(@"Bilder/DuckLord1.0.png");

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

        private static bool initialized = false;
        private static Rectangle userRect;
        private static Rectangle passRect;
        private static float logoX;
        private static float logoY;
        private static float logoScale;
        private static float screenHeight;

        public static void Run()
        {
            if (!initialized)
            {
                InitializeUI();
                initialized = true;
            }

            UpdateAndDraw();
        }

        private static void InitializeUI()
        {
            float screenWidth = Raylib.GetScreenWidth();
            screenHeight = Raylib.GetScreenHeight();

            var uiWrapper = new UIWrapper();
            uiWrapper.SetToFullWindow();

            float fieldWidth = screenWidth * 0.3f;
            float fieldHeight = screenHeight * 0.05f;
            float buttonWidth = screenWidth * 0.125f;
            float buttonHeight = screenHeight * 0.05f;
            float gap = screenHeight * 0.02f;

            float colTop = screenHeight * 0.45f;

            userRect = uiWrapper.CenterHoriz(fieldWidth, fieldHeight, colTop);
            passRect = uiWrapper.CenterHoriz(fieldWidth, fieldHeight, colTop + fieldHeight + gap);
            var loginRect = uiWrapper.CenterHoriz(buttonWidth, buttonHeight, colTop + 2 * (fieldHeight + gap));
            var registerRect = uiWrapper.CenterHoriz(buttonWidth, buttonHeight, colTop + 3 * (fieldHeight + gap));
            var optionsRect = uiWrapper.CenterHoriz(buttonWidth, buttonHeight, colTop + 4 * (fieldHeight + gap));

            // Use the safe setter
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

        public static void UpdateAndDraw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Colors.BackgroundColor);

            int labelFont = 15;
            int labelYUser = (int)(userRect.Y + (userRect.Height - labelFont) / 2f);
            int labelYPass = (int)(passRect.Y + (passRect.Height - labelFont) / 2f);
            Raylib.DrawText("Username:", (int)(userRect.X - 110), labelYUser, labelFont, Colors.TextFieldColor);
            Raylib.DrawText("Password:", (int)(passRect.X - 110), labelYPass, labelFont, Colors.TextFieldColor);

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

            userField.Update();
            userField.Draw();

            passwordField.Update();
            passwordField.Draw();

            registerButton.Draw();
            loginButton.Draw();
            Ducktions.Draw();

            Raylib.DrawTextureEx(logo, new Vector2(logoX, logoY), 0, logoScale, Color.White);

            Raylib.DrawText("DuckLord v.0.0.2", 10, (int)(screenHeight - 20), 10, Colors.TextColor);
            Raylib.EndDrawing();
        }
    }
}