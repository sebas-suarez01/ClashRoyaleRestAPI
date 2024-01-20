namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public class WarId : ValueObject
{
    public Guid Value { get; set; }

    private WarId(Guid value)
    {
        Value = value;
    }
    private WarId() { }

    public static WarId CreateUnique() => new(Guid.NewGuid());
    public static WarId Create(Guid value) => new(value);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value!;
    }
    public override string ToString()
    {
        return Value.ToString();
    }
}
