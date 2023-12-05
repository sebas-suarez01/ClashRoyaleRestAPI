using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddDonation
{
    internal class AddDonationCommandHandler : ICommandHandler<AddDonationCommand>
    {
        private readonly IPlayerRepository _playerRepository;

        public AddDonationCommandHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Result> Handle(AddDonationCommand request, CancellationToken cancellationToken)
        {
            await _playerRepository.AddDonation(request.PlayerId,
                                                request.ClanId,
                                                request.CardId,
                                                request.Amount,
                                                request.Date);

            return Result.Success();
        }
    }
}
