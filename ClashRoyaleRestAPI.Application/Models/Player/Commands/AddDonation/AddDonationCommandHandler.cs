using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Shared;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions.Models;

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
            try
            {
                await _playerRepository.AddDonation(request.PlayerId, request.ClanId, request.CardId, request.Amount);
            }
            catch (IdNotFoundException<int> e)
            {
                return Result.Failure(ErrorTypes.Models.IdNotFound(e.Message));
            }
            catch (PlayerNotHaveCardException)
            {
                return Result.Failure(ErrorTypes.Models.PlayerNotHaveCard());
            }

            return Result.Success();
        }
    }
}
