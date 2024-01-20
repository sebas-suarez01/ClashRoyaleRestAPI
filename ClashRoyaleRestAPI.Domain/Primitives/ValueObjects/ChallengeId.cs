namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public class ChallengeId : ValueObject
{
    public Guid Value { get; set; }

    private ChallengeId(Guid value)
    {
        Value = value;
    }
    private ChallengeId() { }

    public static ChallengeId CreateUnique() => new(Guid.NewGuid());
    public static ChallengeId Create(Guid value) => new(value);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value!;
    }
    public override string ToString()
    {
        return Value.ToString();
    }
}
