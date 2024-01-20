namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public class ValueObjectId : ValueObject
{
    public Guid Value { get; protected set; }

    public ValueObjectId(Guid value)
    {
        Value = value;
    }
    protected ValueObjectId() { }
    public static T CreateUnique<T>() where T : ValueObjectId
    {
        return (T)new ValueObjectId(Guid.NewGuid());
    }
    
    public static T Create<T>(Guid value) where T : ValueObjectId
    {
        return (T)new ValueObjectId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value!;
    }
    public override string ToString()
    {
        return Value.ToString();
    }
}
