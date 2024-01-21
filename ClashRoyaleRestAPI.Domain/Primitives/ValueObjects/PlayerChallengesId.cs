namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public sealed class PlayerChallengesId : ValueObjectId
{
    public PlayerChallengesId(Guid id) : base(id)
    { }
    public static PlayerChallengesId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static PlayerChallengesId Create(Guid value)
    {
        return new(value);
    }
}
