namespace ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;

public sealed class DonationId : ValueObjectId
{
    public DonationId(Guid id) : base(id)
    { }
    public static DonationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static DonationId Create(Guid value)
    {
        return new(value);
    }
}
