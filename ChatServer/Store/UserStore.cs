namespace ChatServer.Store;

public class UserStore
{
  // Dictionaries for storing and looking up users
  private readonly Dictionary<string, User> usersByUsername = [];
  private readonly Dictionary<int, User> usersById = [];

  // User ID counter
  private int nextId = 1;

  #region ADD USER
  /// <summary>
  /// Adds a new user to the store. The method assigns a unique ID and registers
  /// the user in both UserStore dictionaries (by username and by ID).
  /// </summary>
  /// <param name="username">
  /// The identifier the caller wants to use when referring to the user.
  /// </param>
  /// <param name="password">
  /// The secret credential stored for authentication.
  /// </param>
  /// <returns>
  /// True when creation succeeds. False when a user with the same username already exists.
  /// </returns>
  #endregion
  public bool Add(string username, string password)
  {
    if (usersByUsername.ContainsKey(username))
    {
      return false;
    }

    User newUser = new(username, password)
    {
      Id = nextId++
    };

    usersByUsername.Add(username, newUser);
    usersById.Add(newUser.Id, newUser);
    return true;
  }

  // REMOVE USER
  public bool Remove(string username)
  {
    if (!usersByUsername.TryGetValue(username, out var user))
      return false;

    usersByUsername.Remove(username);
    usersById.Remove(user.Id);

    return true;
  }

  public bool Remove(int id)
  {
    if (!usersById.TryGetValue(id, out var user))
      return false;

    usersById.Remove(id);
    usersByUsername.Remove(user.Username);

    return true;
  }

  // UPDATE USER
  public bool Update(string oldUsername, string newUsername, string? newPassword = null)
  {
    // TODO: Implement logic
    return false;
  }

  // GET USER
  public User? GetById(int id)
  {
    // TODO: Implement logic
    return null;
  }

  public User? GetByUsername(string username)
  {
    // TODO: Implement logic
    return null;
  }

  // GET ALL USERNAMES
  public IEnumerable<string> GetAllUsernames()
  {
    // TODO: Implement logic
    return [];
  }
}
