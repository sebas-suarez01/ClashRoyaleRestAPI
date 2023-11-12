using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands.AddClanWar;

internal class AddClanWarCommandHandler : ICommandHandler<AddClanWarCommand>
{
    private readonly IWarRepository _warRepository;

    public AddClanWarCommandHandler(IWarRepository warRepository)
    {
        _warRepository = warRepository;
    }

    public async Task<Result> Handle(AddClanWarCommand request, CancellationToken cancellationToken)
    {
        await _warRepository.AddClanToWar(request.warId, request.clanId, request.prize);

        return Result.Success();
    }
}
