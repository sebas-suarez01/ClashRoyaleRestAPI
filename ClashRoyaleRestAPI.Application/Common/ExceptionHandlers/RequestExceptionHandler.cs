using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Exceptions.Models;
using ClashRoyaleRestAPI.Domain.Shared;
using MediatR;
using MediatR.Pipeline;

namespace ClashRoyaleRestAPI.Application.Common.ExceptionHandlers
{
    public class RequestExceptionHandler<TRequest, TResponse, UId> : IRequestExceptionHandler<TRequest, Result<TResponse>, Exception>
        where TRequest : IRequest<Result<TResponse>>
    {
        public Task Handle(TRequest request, Exception exception, RequestExceptionHandlerState<Result<TResponse>> state, CancellationToken cancellationToken)
        {
            if (exception as IdNotFoundException<UId> is not null)
                state.SetHandled(Result.Failure<TResponse>(ErrorTypes.Models.IdNotFound(exception.Message)));

            else if(exception as DuplicationIdException is not null)
                Result.Failure(ErrorTypes.Models.DuplicateId(exception.Message));

            return Task.CompletedTask;
        }
    }

    public class RequestExceptionHandler<TRequest, UId> : IRequestExceptionHandler<TRequest, Result, Exception>
        where TRequest : IRequest<Result>
    {
        public Task Handle(TRequest request, Exception exception, RequestExceptionHandlerState<Result> state, CancellationToken cancellationToken)
        {
            if (exception as IdNotFoundException<UId> is not null)
                state.SetHandled(Result.Failure(ErrorTypes.Models.IdNotFound(exception.Message)));

            else if (exception as DuplicationIdException is not null)
                Result.Failure(ErrorTypes.Models.DuplicateId(exception.Message));

            else if(exception as ChallengeClosedException is not null)
                Result.Failure(ErrorTypes.Models.ChallengeClosed());

            else if (exception as PlayerNotHaveCardException is not null)
                Result.Failure(ErrorTypes.Models.PlayerNotHaveCard());

            return Task.CompletedTask;
        }
    }
}
