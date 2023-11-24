namespace ClashRoyaleRestAPI.Domain.Exceptions.Auth;

public class DuplicationUsernameException : Exception
{
    public DuplicationUsernameException() : base("Usernanme already exists")
    { }
}
