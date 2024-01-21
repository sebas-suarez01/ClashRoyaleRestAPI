namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public sealed class PlayerId : ValueObjectId
{
    public PlayerId(Guid id) : base(id)
    { }
    public static PlayerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static PlayerId Create(Guid value)
    {
        return new(value);
    }
}
