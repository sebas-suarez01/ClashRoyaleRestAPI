using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddDonation
{
    internal class AddDonationCommandHandler : ICommandHandler<AddDonationCommand>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddDonationCommandHandler(IPlayerRepository playerRepository, IUnitOfWork unitOfWork)
        {
            _playerRepository = playerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddDonationCommand request, CancellationToken cancellationToken = default)
        {
            await _playerRepository.AddDonation(request.PlayerId,
                                                request.ClanId,
                                                request.CardId,
                                                request.Amount,
                                                request.Date);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
