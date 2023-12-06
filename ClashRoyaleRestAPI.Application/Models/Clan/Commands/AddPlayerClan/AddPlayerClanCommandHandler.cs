using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddPlayerClan;

internal class AddPlayerClanCommandHandler : ICommandHandler<AddPlayerClanCommand>
{
    private readonly IClanRepository _repository;

    public AddPlayerClanCommandHandler(IClanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(AddPlayerClanCommand request, CancellationToken cancellationToken)
    {
        await _repository.AddPlayer(request.ClanId, request.PlayerId);

        return Result.Success();
    }
}
