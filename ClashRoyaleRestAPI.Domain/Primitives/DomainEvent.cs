namespace ClashRoyaleRestAPI.Domain.Primitives;

public record DomainEvent : IDomainEvent
{
    public Guid Id { get; protected set; }

    public DomainEvent()
    {
        Id = Guid.NewGuid();
    }
}
