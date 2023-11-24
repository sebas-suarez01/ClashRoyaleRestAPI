namespace ClashRoyaleRestAPI.Domain.Exceptions;

public class DuplicationIdException : Exception
{
    public DuplicationIdException(params int[] ids) : base("Ids " + string.Join(",", ids) + " already exist. You are trying to add an existing key") { }
}
