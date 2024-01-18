using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Relationships;
using EntityFrameworkCore.Triggered;

namespace ClashRoyaleRestAPI.Infrastructure.Persistance.Triggers;

public class UpdateCardAmountTrigger : IAfterSaveTrigger<CollectionModel>
{
    private readonly IPlayerRepository _playerService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCardAmountTrigger(IPlayerRepository playerService, IUnitOfWork unitOfWork)
    {
        _playerService = playerService;
        _unitOfWork = unitOfWork;
    }
    public async Task AfterSave(ITriggerContext<CollectionModel> context, CancellationToken cancellationToken = default)
    {

        if (context.ChangeType == ChangeType.Added && context.Entity.Player is not null)
        {
            var player = await _playerService.GetSingleByIdAsync(context.Entity.Player.Id);
            player!.AddCardAmount();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
