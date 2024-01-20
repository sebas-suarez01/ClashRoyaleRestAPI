namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public class ClanId : ValueObject
{
    public Guid Value { get; set; }

    private ClanId(Guid value)
    {
        Value = value;
    }
    private ClanId() { }

    public static ClanId CreateUnique() => new(Guid.NewGuid());
    public static ClanId Create(Guid value) => new(value);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value!;
    }
    public override string ToString()
    {
        return Value.ToString();
    }
}
