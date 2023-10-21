using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Card.Commands
{
    public class DeleteCardCommandHandler : DeleteModelCommandHandler<CardModel, int>
    {
        public DeleteCardCommandHandler(ICardRepository repository) : base(repository)
        {
        }
    }
}
