using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Models.Card.Commands
{
    internal class UpdateCardCommandHandler : UpdateModelCommandHandler<CardModel, int>
    {
        public UpdateCardCommandHandler(ICardRepository repository) : base(repository)
        {
        }
    }
}
