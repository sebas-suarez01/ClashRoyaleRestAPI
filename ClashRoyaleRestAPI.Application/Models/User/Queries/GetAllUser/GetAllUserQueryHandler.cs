using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.User.Queries.GetAllUser;

internal class GetAllUserQueryHandler : IQueryHandler<GetAllModelQuery<UserModel, string>, PageList<UserModel>>
{
    private readonly IUserRepository _repository;

    public GetAllUserQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PageList<UserModel>>> Handle(GetAllModelQuery<UserModel, string> request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllAsync(request.Page, request.PageSize);

        return Result.Create(users);
    }
}
