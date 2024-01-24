namespace ClashRoyaleRestAPI.Domain.Primitives;

public abstract class Entity<TId> : IEntity<TId>, IDomainEventContainer, IAuditableEntity
{
    private readonly List<DomainEvent> _domainEvents = new();
    public TId Id { get; protected set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }

    public ICollection<DomainEvent> GetDomainEvents() => _domainEvents.ToList();
    public void ClearDomainEvents()=> _domainEvents.Clear();
    protected void RaiseDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
