using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.War.Commands.AddClanWar;

internal class AddClanWarCommandHandler : ICommandHandler<AddClanWarCommand>
{
    private readonly IWarRepository _warRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddClanWarCommandHandler(IWarRepository warRepository, IUnitOfWork unitOfWork)
    {
        _warRepository = warRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddClanWarCommand request, CancellationToken cancellationToken = default)
    {
        var warId = WarId.Create(request.ClanId);
        var clanId = ClanId.Create(request.ClanId);

        await _warRepository.AddClanToWar(warId, clanId, request.Prize);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
