using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Auth.User;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.User.Commands.DeleteUser
{
    internal class DeleteUserCommandHandler : ICommandHandler<DeleteModelCommand<UserModel, string>>
    {
        private readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(DeleteModelCommand<UserModel, string> request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);

            return Result.Success();
        }
    }
}
