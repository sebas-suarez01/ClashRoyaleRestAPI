using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddCard
{
    internal class AddCardCommandHandler : ICommandHandler<AddCardCommand>
    {
        private readonly IPlayerRepository _repository;

        public AddCardCommandHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(AddCardCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddCard(request.PlayerId, request.CardId);

            return Result.Success();
        }
    }
}
