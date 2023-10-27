using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Auth.Response;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions.Auth;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Auth.User.Queries.GetUserByName
{
    internal class GetUserByNameQueryHandler : IQueryHandler<GetUserByNameQuery, UserResponse>
    {
        private readonly IUserRepository _repository;

        public GetUserByNameQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<UserResponse>> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            UserResponse response;

            try
            {
                response = await _repository.GetUserByNameAsync(request.Name);
            }
            catch (UsernameNotFoundException)
            {
                return Result.Failure<UserResponse>(ErrorTypes.Auth.UsernameNotFound());
            }

            return response;
        }
    }
}
