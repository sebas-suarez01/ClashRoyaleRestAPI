using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Auth.User;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.User.Queries.GetUserByName
{
    internal class GetUserByNameQueryHandler : IQueryHandler<GetUserByNameQuery, UserModel>
    {
        private readonly IUserRepository _repository;

        public GetUserByNameQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<UserModel>> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            UserModel user = await _repository.GetUserByNameAsync(request.Name);

            return user;
        }
    }
}
