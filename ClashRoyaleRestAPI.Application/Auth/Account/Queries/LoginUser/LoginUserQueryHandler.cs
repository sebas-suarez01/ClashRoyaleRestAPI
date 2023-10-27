using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Auth.Response;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions.Auth;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Auth.Account.Queries.LoginUser
{
    internal class LoginUserQueryHandler : IQueryHandler<LoginUserQuery, LoginResponse>
    {
        private readonly IAccountRepository _repository;

        public LoginUserQueryHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<LoginResponse>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            LoginResponse response;

            try
            {
                response = await _repository.LoginUserAsync(request.LoginModel);
            }
            catch (UsernameNotFoundException)
            {
                return Result.Failure<LoginResponse>(ErrorTypes.Auth.UsernameNotFound());
            }
            catch (InvalidPasswordException)
            {
                return Result.Failure<LoginResponse>(ErrorTypes.Auth.InvalidPassword());
            }

            return response;
        }
    }
}
