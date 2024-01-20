using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddClan;

internal class AddClanCommandHandler : ICommandHandler<AddClanCommand, Guid>
{
    private readonly IClanRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AddClanCommandHandler(IClanRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(AddClanCommand request, CancellationToken cancellationToken = default)
    {
        var playerId = PlayerId.Create(request.PlayerId);
        await _repository.Add(playerId, request.Clan);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return request.Clan.Id.Value;
    }
}
