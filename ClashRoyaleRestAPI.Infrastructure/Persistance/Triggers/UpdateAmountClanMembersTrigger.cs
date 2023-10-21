using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Relationships;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Triggers
{
    public class UpdateAmountClanMembersTrigger : IBeforeSaveTrigger<ClanPlayersModel>
    {
        private readonly IClanRepository _clanRepository;

        public UpdateAmountClanMembersTrigger(IClanRepository clanRepository)
        {
            _clanRepository = clanRepository;
        }
        public async Task BeforeSave(ITriggerContext<ClanPlayersModel> context, CancellationToken cancellationToken)
        {
            if (context.Entity.Clan is null)
                return;

            var clan = await _clanRepository.GetSingleByIdAsync(context.Entity.Clan.Id);

            if (context.ChangeType == ChangeType.Added)
            {
                clan!.AmountMembers += 1;
            }
            else if (context.ChangeType == ChangeType.Deleted)
            {
                clan!.AmountMembers -= 1;
            }
            await _clanRepository.Save();
        }
    }
}
