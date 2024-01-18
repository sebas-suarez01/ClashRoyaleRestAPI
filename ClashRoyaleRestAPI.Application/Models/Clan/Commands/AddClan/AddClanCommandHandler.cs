using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddClan;

internal class AddClanCommandHandler : ICommandHandler<AddClanCommand, int>
{
    private readonly IClanRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AddClanCommandHandler(IClanRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(AddClanCommand request, CancellationToken cancellationToken = default)
    {
        await _repository.Add(request.PlayerId, request.Clan);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return request.Clan.Id;
    }
}
