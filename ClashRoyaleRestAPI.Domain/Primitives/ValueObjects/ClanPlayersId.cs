namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public sealed class ClanPlayersId : ValueObjectId
{
    public ClanPlayersId(Guid id) : base(id)
    { }
    public static ClanPlayersId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ClanPlayersId Create(Guid value)
    {
        return new(value);
    }
}
