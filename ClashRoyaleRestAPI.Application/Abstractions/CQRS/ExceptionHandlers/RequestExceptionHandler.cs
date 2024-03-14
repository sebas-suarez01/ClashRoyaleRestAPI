using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Exceptions.Auth;
using ClashRoyaleRestAPI.Domain.Exceptions.Models;
using ClashRoyaleRestAPI.Domain.Shared;
using MediatR;
using MediatR.Pipeline;

namespace ClashRoyaleRestAPI.Application.Abstractions.CQRS.ExceptionHandlers;

public class RequestExceptionHandler<TRequest, TResponse, UId> : IRequestExceptionHandler<TRequest, Result<TResponse>, Exception>
    where TRequest : IRequest<Result<TResponse>>
{
    public Task Handle(TRequest request, Exception exception, RequestExceptionHandlerState<Result<TResponse>> state, CancellationToken cancellationToken)
    {
        if (exception as IdNotFoundException<UId> is not null)
            state.SetHandled(Result.Failure<TResponse>(ErrorTypes.Models.IdNotFound(exception.Message)));

        else if (exception as DuplicationIdException<UId> is not null)
            state.SetHandled(Result.Failure<TResponse>(ErrorTypes.Models.DuplicateId(exception.Message)));

        else if (exception as DuplicationIndexException is not null)
            state.SetHandled(Result.Failure<TResponse>(ErrorTypes.Models.DuplicateIndex(exception.Message)));

        else if (exception as DuplicationUsernameException is not null)
            state.SetHandled(Result.Failure<TResponse>(ErrorTypes.Auth.DuplicateUsername()));

        else if (exception as UserCreationException is not null)
            state.SetHandled(Result.Failure<TResponse>(ErrorTypes.Auth.InvalidCredentials()));

        else if (exception as UsernameNotFoundException is not null)
            state.SetHandled(Result.Failure<TResponse>(ErrorTypes.Auth.UsernameNotFound()));

        else if (exception as InvalidPasswordException is not null)
            state.SetHandled(Result.Failure<TResponse>(ErrorTypes.Auth.InvalidPassword()));


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

        else if (exception as DuplicationIdException<UId> is not null)
            state.SetHandled(Result.Failure(ErrorTypes.Models.DuplicateId(exception.Message)));

        else if (exception as PlayerNotHaveCardException is not null)
            state.SetHandled(Result.Failure(ErrorTypes.Models.PlayerNotHaveCard()));

        else if (exception as ChallengeClosedException is not null)
            state.SetHandled(Result.Failure(ErrorTypes.Models.ChallengeClosed()));

        return Task.CompletedTask;
    }
}
