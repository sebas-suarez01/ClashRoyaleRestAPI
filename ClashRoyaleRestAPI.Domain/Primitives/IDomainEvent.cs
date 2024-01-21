using MediatR;

namespace ClashRoyaleRestAPI.Domain.Primitives;

public interface IDomainEvent : INotification
{
    public Guid Id { get; }
}
