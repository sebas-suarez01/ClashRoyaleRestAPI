namespace ClashRoyaleRestAPI.Domain.Exceptions;

public class DuplicationIndexException : Exception
{
    public DuplicationIndexException(string message) : base("Index " + message + " already exists")
    {
    }
}
