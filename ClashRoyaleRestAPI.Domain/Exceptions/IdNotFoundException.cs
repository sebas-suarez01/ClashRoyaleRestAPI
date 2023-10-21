namespace ClashRoyaleRestAPI.Domain.Exceptions
{
    public class IdNotFoundException : Exception
    {
        public IdNotFoundException() : base("Id do not exist")
        { }

    }
}
