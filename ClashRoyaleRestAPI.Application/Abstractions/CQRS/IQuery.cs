using ClashRoyaleRestAPI.Domain.Shared;
using MediatR;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
