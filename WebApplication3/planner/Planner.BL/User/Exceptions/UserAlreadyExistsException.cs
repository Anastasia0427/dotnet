namespace Planner.BL.User.Exceptions;

public class UserAlreadyExistsException : ApplicationException
{
    public UserAlreadyExistsException(string message) : base(message) { }
}