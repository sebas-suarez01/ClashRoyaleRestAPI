namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public sealed class BattleId : ValueObjectId
{
    public BattleId(Guid id):base(id) 
    { }
    public static BattleId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static BattleId Create(Guid value)
    {
        return new(value);
    }
}
