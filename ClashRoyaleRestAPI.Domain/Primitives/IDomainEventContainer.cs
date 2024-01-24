namespace ClashRoyaleRestAPI.Domain.Primitives;

public interface IDomainEventContainer
{
    public ICollection<DomainEvent> GetDomainEvents();
    public void ClearDomainEvents();
}
