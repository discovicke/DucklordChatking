using ChatClient.Core;
using ChatClient.Data;
using ChatClient.UI.Components;
using Raylib_cs;

namespace ChatClient.UI.Screens
{
    // "How should all fields and buttons behave?"
    public class StartScreenLogic(
        TextField userField,
        TextField passwordField,
        Button loginButton,
        Button registerButton,
        OptionsButton optionsButton) : IScreenLogic
    {
        // DEV MODE: Set to false before production release
        private const bool DEV_MODE_ENABLED = true;
        
        private readonly UserAuth userAuth = new UserAuth(ServerConfig.CreateHttpClient());
        public readonly FeedbackBox FeedbackBox = new();

        
        // Feedback state
        public string FeedbackMessage { get; private set; } = "";
        public bool IsFeedbackSuccess { get; private set; } = false;
        private double feedbackStartTime = 0;
        private const double FeedbackDisplayDuration = 3.0; // Show feedback for 3 seconds
        
        public void HandleInput()
        {
            // Clear feedback after duration
            if (!string.IsNullOrEmpty(FeedbackMessage) && Raylib.GetTime() - feedbackStartTime > FeedbackDisplayDuration)
            {
                FeedbackMessage = "";
            }
            
            // DEV MODE: Ctrl+Shift+D for instant dev login
            if (DEV_MODE_ENABLED && 
                Raylib.IsKeyDown(KeyboardKey.LeftControl) && 
                Raylib.IsKeyDown(KeyboardKey.LeftShift) && 
                Raylib.IsKeyPressed(KeyboardKey.D))
            {
                DevLogin();
                return;
            }

            userField.Update();
            passwordField.Update();

            if (MouseInput.IsLeftClick(loginButton.Rect) || Raylib.IsKeyPressed(KeyboardKey.Enter))
            {
                Login();
            }

            if (MouseInput.IsLeftClick(registerButton.Rect))
            {
                NavigateToRegister();
            }

            if (MouseInput.IsLeftClick(optionsButton.Rect))
            {
                NavigateToOptions();
            }
        }

        private void Login()
        {
            string username = userField.Text.Trim();
            string password = passwordField.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                FeedbackBox.Show("Please enter duckname and password!", false);
                Log.Info("[StartScreenLogic] Login failed - duckname or password empty");
                return;
            }

            Log.Info($"[StartScreenLogic] Login attempt - duckname: '{username}'");

            // Authenticate with server
            bool success = userAuth.Login(username, password);

            if (success)
            {
                Log.Success($"[StartScreenLogic] Login successful for duck '{username}'");
                AppState.LoggedInUsername = username;
                FeedbackBox.Show($"Welcome back, {username}!", true);

                Task.Delay(3000).ContinueWith(_ =>
                {
                    AppState.CurrentScreen = Screen.Chat;
                    ClearFields();
                });
            }
            else
            {
                Log.Error($"[StartScreenLogic] Login failed for duck '{username}' - Invalid credentials");
                FeedbackBox.Show("DUCK! Login failed, check your credentials.", false);
            }
        }

        private void ShowFeedback(string message, bool isSuccess)
        {
            FeedbackMessage = message;
            IsFeedbackSuccess = isSuccess;
            feedbackStartTime = Raylib.GetTime();
        }

        // DEV MODE: Quick login for development (bypasses server authentication)
        private void DevLogin()
        {
            Log.Info("[StartScreenLogic] DEV MODE: Quack login activated (Ctrl+Shift+D)");
            AppState.LoggedInUsername = "DevUser";
            AppState.CurrentScreen = Screen.Chat;
            ClearFields();
        }

        private void NavigateToRegister()
        {
            Log.Info("[StartScreenLogic] Navigating to register screen");
            AppState.CurrentScreen = Screen.Register;
            ClearFields();
            FeedbackMessage = "";
        }

        private void NavigateToOptions()
        {
            Log.Info("[StartScreenLogic] Navigating to options screen");
            AppState.CurrentScreen = Screen.Options;
            ClearFields();
            FeedbackMessage = "";
        }

        private void ClearFields()
        {
            Log.Info("[StartScreenLogic] Clearing all fields");
            userField.Clear();
            passwordField.Clear();
        }
    }
}
