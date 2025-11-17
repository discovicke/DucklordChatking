namespace ChatClient.Data.Models;

/// <summary>
/// Responsible for: managing current user account credentials and login state.
/// Stores username and password in memory for the current session.
/// </summary>
public class UserAccount
{
    public static string? Username { get; private set; }
    public static string? Password { get; private set; }

    public static bool IsLoggedIn => !string.IsNullOrEmpty(Username);

    public static void SetUser(string username, string? password = null)
    {
        Username = username;
        Password = password;
    }

    public static void Clear()
    {
        Username = null;
        Password = null;
    }
}