using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.User.Queries.GetUserById
{
    internal class GetUserByIdQueryHandler : IQueryHandler<GetModelByIdQuery<UserModel, string>, UserModel>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<UserModel>> Handle(GetModelByIdQuery<UserModel, string> request, CancellationToken cancellationToken)
        {
            UserModel user = await _repository.GetUserByIdAsync(request.Id);

            return user;
        }
    }
}
