namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public sealed class CollectionId : ValueObjectId
{
    public CollectionId(Guid id) : base(id)
    { }
    public static CollectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static CollectionId Create(Guid value)
    {
        return new(value);
    }
}
