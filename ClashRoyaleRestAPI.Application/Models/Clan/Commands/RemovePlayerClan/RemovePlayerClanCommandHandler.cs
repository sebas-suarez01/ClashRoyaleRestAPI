using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.RemovePlayerClan;

internal class RemovePlayerClanCommandHandler : ICommandHandler<RemovePlayerClanCommand>
{
    private readonly IClanRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public RemovePlayerClanCommandHandler(IClanRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RemovePlayerClanCommand request, CancellationToken cancellationToken = default)
    {
        await _repository.RemovePlayer(request.ClanId, request.PlayerId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
