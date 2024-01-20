namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public class PlayerId : ValueObject
{
    public Guid Value { get; set; }

    private PlayerId(Guid value)
    {
        Value = value;
    }
    private PlayerId() { }

    public static PlayerId CreateUnique() => new(Guid.NewGuid());
    public static PlayerId Create(Guid value) => new(value);
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value!;
    }
    public override string ToString()
    {
        return Value.ToString();
    }
}
