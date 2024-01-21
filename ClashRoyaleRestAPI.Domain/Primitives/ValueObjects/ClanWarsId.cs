namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public sealed class ClanWarsId : ValueObjectId
{
    public ClanWarsId(Guid id) : base(id)
    { }
    public static ClanWarsId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ClanWarsId Create(Guid value)
    {
        return new(value);
    }
}
