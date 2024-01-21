namespace ClashRoyaleRestAPI.Domain.Primitives;

public interface IAggregateRoot
{
    public ICollection<IDomainEvent> GetDomainEvents();
    public void ClearDomainEvents();
}
