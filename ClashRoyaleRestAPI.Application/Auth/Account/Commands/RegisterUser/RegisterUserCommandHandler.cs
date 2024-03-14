using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Auth.Response;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Application.Messaging;
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
            UserResponse response = await _repository.RegisterUserAsync(request.RegisterModel, request.Role);

            return response.Id!;
        }
    }
}
