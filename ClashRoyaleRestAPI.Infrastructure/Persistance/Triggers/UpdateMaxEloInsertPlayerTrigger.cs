using ClashRoyaleRestAPI.Domain.Models.Player;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Triggers
{
    public class UpdateMaxEloInsertPlayerTrigger : IBeforeSaveTrigger<PlayerModel>
    {
        public Task BeforeSave(ITriggerContext<PlayerModel> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added)
            {
                context.Entity.MaxElo = context.Entity.Elo;
            }
            return Task.CompletedTask;
        }
    }
}
