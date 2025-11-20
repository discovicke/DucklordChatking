using ChatClient.Core.Application;
using ChatClient.Core.Infrastructure;
using ChatClient.Core.Input;
using ChatClient.Data;
using ChatClient.Data.Services;
using ChatClient.UI.Components.Base;
using ChatClient.UI.Components.Specialized;
using ChatClient.UI.Screens.Common;
using Raylib_cs;

namespace ChatClient.UI.Screens.Register;

/// <summary>
/// Responsible for: handling user registration logic including validation and server communication.
/// Manages password confirmation matching, field validation, and feedback display for registration success/failure.
/// </summary>
public class RegisterScreenLogic : ScreenLogicBase
{
    private readonly TextField userField;
    private readonly TextField passField;
    private readonly TextField passConfirmField;
    private readonly Button registerButton;
    private readonly BackButton backButton;
    private readonly IFeedbackService feedback;
    private readonly UserAuth userAuth;

    public FeedbackBox FeedbackBox { get; }

    public RegisterScreenLogic(
        TextField userField,
        TextField passField,
        TextField passConfirmField,
        Button registerButton,
        BackButton backButton)
    {
        this.userField = userField;
        this.passField = passField;
        this.passConfirmField = passConfirmField;
        this.registerButton = registerButton;
        this.backButton = backButton;
        
        this.FeedbackBox = new FeedbackBox();
        this.feedback = new FeedbackService(FeedbackBox);
        this.userAuth = new UserAuth(ServerConfig.CreateHttpClient());

        // Register fields for automatic tab navigation
        RegisterField(userField);
        RegisterField(passField);
        RegisterField(passConfirmField);
    }

    protected override void UpdateComponents()
    {
        base.UpdateComponents(); // Updates all registered fields with tab navigation
        feedback.Update();
    }

    protected override void HandleActions()
    {
        if (MouseInput.IsLeftClick(registerButton.Rect) || Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            TryRegister();
        }

        backButton.Update();
        if (backButton.IsClicked())
        {
            ClearFields();
            Navigation.NavigateBack();
        }
    }

    private void TryRegister()
    {
        string username = userField.Text.Trim();
        string password = passField.Text;
        string passwordConfirm = passConfirmField.Text;

        // Validate username
        var usernameValidation = InputValidator.ValidateUsername(username);
        if (!usernameValidation.IsValid)
        {
            Raylib.PlaySound(ResourceLoader.FailedSound);
            feedback.ShowError(usernameValidation.ErrorMessage);
            return;
        }

        // Validate password
        var passwordValidation = InputValidator.ValidatePassword(password);
        if (!passwordValidation.IsValid)
        {
            Raylib.PlaySound(ResourceLoader.FailedSound);
            feedback.ShowError(passwordValidation.ErrorMessage);
            return;
        }

        // Validate password match
        var matchValidation = InputValidator.ValidatePasswordMatch(password, passwordConfirm);
        if (!matchValidation.IsValid)
        {
            Raylib.PlaySound(ResourceLoader.FailedSound);
            feedback.ShowError(matchValidation.ErrorMessage);
            return;
        }

        bool success = userAuth.Register(username, password);

        if (success)
        {
            Raylib.PlaySound(ResourceLoader.LoginSound);
            feedback.ShowSuccess($"Duckount created! Welcome, {username}!");
            
            Task.Delay(3000).ContinueWith(_ =>
            {
                ClearFields();
                Navigation.NavigateTo(Screen.Start);
            });
        }
        else
        {
            Raylib.PlaySound(ResourceLoader.FailedSound);
            feedback.ShowError("Registration failed! Quackername may be taken.");
        }
    }
}
