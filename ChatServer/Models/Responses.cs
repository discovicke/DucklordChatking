using System;
using Shared;

namespace ChatServer.Models;

public class Responses
{
    public record ApiSuccessResponseWithUsername(string Username, string SuccessMessage);
    public record ApiSuccessResponseWithUsernameList(IEnumerable<string> ListOfUsernames, string SuccessMessage);
    public record ApiSuccessResponseWithMessageList(IEnumerable<MessageDTO> Messages, string SuccessMessage);
    public record ApiSuccessResponse(string SuccessMessage);
    public record ApiFailResponse(string FailMessage);

}
