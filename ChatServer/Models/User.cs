namespace ChatServer.Models;

public class User(string username, string password)
{
  public int Id { get; set; }
  public string Username { get; set; } = username.ToLower(); // Store usernames in lowercase for consistency to make it case-insensitive, but displays as entered on client-side.
  public string Password { get; set; } = password;
}
