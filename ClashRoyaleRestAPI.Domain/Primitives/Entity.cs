namespace ClashRoyaleRestAPI.Domain.Primitives;

public abstract class Entity<TId> : IEntity<TId>, IAuditableEntity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public TId Id { get; protected set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
