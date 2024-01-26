using ClashRoyaleRestAPI.Application.Interfaces;
using MediatR;
using System.Transactions;

namespace ClashRoyaleRestAPI.Application.Behaviors;

internal class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request,
                                  RequestHandlerDelegate<TResponse> next,
                                  CancellationToken cancellationToken)
    {
        if (IsNotCommand())
        {
            return await next();
        }

        using var transaction = _unitOfWork.BeginTransaction();
        
        var response = await next();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        transaction.Commit();

        return response;
    }

    private static bool IsNotCommand()
    {
        return !typeof(TRequest).Name.Contains("Command");
    }
}
