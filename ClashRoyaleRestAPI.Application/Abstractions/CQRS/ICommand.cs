using ClashRoyaleRestAPI.Domain.Shared;
using MediatR;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
