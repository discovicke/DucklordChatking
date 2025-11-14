namespace ChatServer.Models;

public class User(string username, string password, bool isAdmin)
{
  public int Id { get; set; }
  public string Username { get; set; } = username;
  public string Password { get; set; } = password;
  public bool IsAdmin { get; set; } = isAdmin;
  public string SessionAuthToken { get; set; } = Guid.NewGuid().ToString();
}
