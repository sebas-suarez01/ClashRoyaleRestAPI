using MediatR;

namespace ClashRoyaleRestAPI.Domain.Primitives;

public record DomainEvent(Guid Id) : INotification
{
}
