using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Player.Commands.AddCard
{
    public class AddCardCommandHandler : ICommandHandler<AddCardCommand>
    {
        private readonly IPlayerRepository _repository;

        public AddCardCommandHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(AddCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.AddCard(request.PlayerId, request.CardId);
            }
            catch (DuplicationIdException)
            {
                return Result.Failure(ErrorTypes.Models.DuplicateId);
            }

            return Result.Success();
        }
    }
}
