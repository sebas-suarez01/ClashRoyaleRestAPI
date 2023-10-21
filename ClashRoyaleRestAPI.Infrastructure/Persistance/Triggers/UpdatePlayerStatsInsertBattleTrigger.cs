using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Battle;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Triggers
{
    public class UpdatePlayerStatsInsertBattleTrigger : IBeforeSaveTrigger<BattleModel>
    {
        private readonly IPlayerRepository _repository;

        public UpdatePlayerStatsInsertBattleTrigger(IPlayerRepository repository)
        {
            _repository = repository;
        }
        public async Task BeforeSave(ITriggerContext<BattleModel> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added && context.Entity.Winner is not null && context.Entity.Loser is not null)
            {
                var winner = await _repository.GetSingleByIdAsync(context.Entity.Winner.Id);
                var loser = await _repository.GetSingleByIdAsync(context.Entity.Loser.Id);

                winner!.Victories += 1;

                loser!.Elo += context.Entity.AmountTrophies;
                winner.Elo += context.Entity.AmountTrophies;
                if (winner.Elo > winner.MaxElo)
                    winner.MaxElo = winner.Elo;
            }
        }
    }
}
