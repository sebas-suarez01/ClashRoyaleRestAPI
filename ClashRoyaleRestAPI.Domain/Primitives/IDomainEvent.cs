namespace ClashRoyaleRestAPI.Domain.Primitives;

public interface IDomainEvent
{
    public Guid Id { get; }
}
