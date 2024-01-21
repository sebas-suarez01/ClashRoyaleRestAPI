namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public sealed class ChallengeId : ValueObjectId
{
    public ChallengeId(Guid id) : base(id)
    { }
    public static ChallengeId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ChallengeId Create(Guid value)
    {
        return new(value);
    }
}
