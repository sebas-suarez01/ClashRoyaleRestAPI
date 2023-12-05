using ClashRoyaleRestAPI.Domain.Models;
using EntityFrameworkCore.Triggered;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Triggers;

internal class UpdateAmountMemberDeletePlayerTrigger : IBeforeSaveTrigger<PlayerModel>
{
    private readonly ClashRoyaleDbContext _context;

    public UpdateAmountMemberDeletePlayerTrigger(ClashRoyaleDbContext context)
    {
        _context = context;
    }

    public async Task BeforeSave(ITriggerContext<PlayerModel> context, CancellationToken cancellationToken)
    {
        if (context.ChangeType == ChangeType.Deleted)
        {
            var clanPlayer = await _context.ClanPlayers
                                .Include(cp=> cp.Clan)
                                .Where(p => p.Player!.Id == context.Entity.Id)
                                .FirstOrDefaultAsync();
            if(clanPlayer != null)
            {
                clanPlayer.Clan!.RemoveAmountMember();
            }
        }
    }
}
