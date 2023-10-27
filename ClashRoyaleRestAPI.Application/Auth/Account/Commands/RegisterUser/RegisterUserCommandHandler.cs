using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Auth.Response;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions.Auth;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Auth.Account.Commands.RegisterUser
{
    internal class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, string>
    {
        private readonly IAccountRepository _repository;

        public RegisterUserCommandHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            UserResponse response;
            try
            {
                response = await _repository.RegisterUserAsync(request.RegisterModel, request.Role);
            }
            catch (DuplicationUsernameException)
            {
                return Result.Failure<string>(ErrorTypes.Auth.DuplicateUsername());
            }
            catch (UserCreationException)
            {
                return Result.Failure<string>(ErrorTypes.Auth.InvalidCredentials());
            }

            return response.Id!;
        }
    }
}
