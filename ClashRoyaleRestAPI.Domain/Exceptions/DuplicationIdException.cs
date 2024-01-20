namespace ClashRoyaleRestAPI.Domain.Exceptions;

public class DuplicationIdException<T> : Exception
{
    public DuplicationIdException(params T[] ids) : base("Ids " + string.Join(",", ids) + " already exist. You are trying to add an existing key") { }
}
