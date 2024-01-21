namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public sealed class ClanId : ValueObjectId
{
    public ClanId(Guid id) : base(id)
    { }
    public static ClanId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ClanId Create(Guid value)
    {
        return new(value);
    }
}
