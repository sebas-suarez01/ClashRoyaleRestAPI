namespace ClashRoyaleRestAPI.Domain.Exceptions.Auth;

public class UserCreationException : Exception
{
    public UserCreationException(string message) : base(message)
    { }
}
