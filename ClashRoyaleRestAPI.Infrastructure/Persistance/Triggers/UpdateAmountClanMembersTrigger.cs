using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Relationships;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Triggers;

public class UpdateAmountClanMembersTrigger : IAfterSaveTrigger<ClanPlayersModel>
{
    private readonly IClanRepository _clanRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAmountClanMembersTrigger(IClanRepository clanRepository, IUnitOfWork unitOfWork)
    {
        _clanRepository = clanRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task AfterSave(ITriggerContext<ClanPlayersModel> context, CancellationToken cancellationToken = default)
    {
        if (context.Entity.Clan is null)
            return;

        var clan = await _clanRepository.GetSingleByIdAsync(context.Entity.Clan.Id);

        if (context.ChangeType == ChangeType.Added)
        {
            clan!.AddAmountMember();
        }
        else if (context.ChangeType == ChangeType.Deleted)
        {
            clan!.RemoveAmountMember();
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
