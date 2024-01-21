namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public sealed class WarId : ValueObjectId
{
    public WarId(Guid id) : base(id)
    { }
    public static WarId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static WarId Create(Guid value)
    {
        return new(value);
    }
}
