using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddClan;

internal class AddClanCommandHandler : ICommandHandler<AddClanCommand, int>
{
    private readonly IClanRepository _repository;

    public AddClanCommandHandler(IClanRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<int>> Handle(AddClanCommand request, CancellationToken cancellationToken)
    {
        await _repository.Add(request.PlayerId, request.Clan);

        return request.Clan.Id;
    }
}
