namespace ClashRoyaleRestAPI.Domain.Primitives;

public abstract class Entity<TId> : IEntity<TId>, IAggregateRoot, IAuditableEntity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public TId Id { get; protected set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }

    public ICollection<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();
    public void ClearDomainEvents()=> _domainEvents.Clear();
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
