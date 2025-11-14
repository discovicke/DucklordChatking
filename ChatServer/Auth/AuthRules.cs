using System;
using ChatServer.Models;

namespace ChatServer.Auth;

public static class AuthRules
{
  /// <summary>
  /// Determines whether an authenticated caller has permission to act on a target user.
  /// The caller is authorized when they are acting on their own account or when they
  /// possess administrator privileges.
  /// </summary>
  /// <param name="caller">
  /// The authenticated user attempting to perform the action. When null, authorization fails.
  /// </param>
  /// <param name="targetUsername">
  /// The username of the account that the caller intends to modify or delete.
  /// </param>
  /// <returns>
  /// <c>true</c> when the caller is the same user as the target or has administrator status;
  /// otherwise <c>false</c>.
  /// </returns>
  public static bool IsSelfOrAdmin(User caller, string targetUsername)
  {
    if (caller == null)
      return false;

    bool isSelf = caller.Username.Equals(targetUsername, StringComparison.OrdinalIgnoreCase);
    bool isAdmin = caller.IsAdmin;

    return isSelf || isAdmin;
  }

}
