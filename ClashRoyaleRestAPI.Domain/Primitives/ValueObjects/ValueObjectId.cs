namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public abstract class ValueObjectId : ValueObject
{
    public Guid Value { get; protected set; }

    public ValueObjectId(Guid value)
    {
        Value = value;
    }
    public ValueObjectId() { }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value!;
    }
    public override string ToString()
    {
        return Value.ToString();
    }
}
