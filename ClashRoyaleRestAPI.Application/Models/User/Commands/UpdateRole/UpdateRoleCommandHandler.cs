using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Auth;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.User.Commands.UpdateRole;

internal class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand>
{
    private readonly IUserRepository _userRepository;

    public UpdateRoleCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.UpdateRole(request.Id, request.Role);

        return Result.Success();
    }
}
