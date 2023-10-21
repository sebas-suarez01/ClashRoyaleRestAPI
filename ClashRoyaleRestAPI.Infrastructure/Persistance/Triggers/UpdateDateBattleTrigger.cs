using ClashRoyaleRestAPI.Domain.Models.Battle;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Triggers
{
    public class UpdateDateBattleTrigger : IBeforeSaveTrigger<BattleModel>
    {
        public Task BeforeSave(ITriggerContext<BattleModel> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added)
            {
                context.Entity.Date = DateTime.UtcNow;
            }

            return Task.CompletedTask;
        }
    }
}
