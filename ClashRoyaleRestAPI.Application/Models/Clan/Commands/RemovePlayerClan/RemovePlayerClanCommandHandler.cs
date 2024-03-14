using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Application.Messaging;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.RemovePlayerClan;

internal class RemovePlayerClanCommandHandler : ICommandHandler<RemovePlayerClanCommand>
{
    private readonly IClanRepository _repository;

    public RemovePlayerClanCommandHandler(IClanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(RemovePlayerClanCommand request, CancellationToken cancellationToken = default)
    {
        await _repository.RemovePlayer(request.ClanId, request.PlayerId);

        return Result.Success();
    }
}
