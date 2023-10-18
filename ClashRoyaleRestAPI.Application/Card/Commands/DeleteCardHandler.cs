using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;

namespace ClashRoyaleRestAPI.Application.Card.Commands
{
    public class DeleteCardHandler : DeleteModelCommandHandler<DeleteModelCommand<CardModel, int>, CardModel, int>
    {
        public DeleteCardHandler(ICardRepository repository) : base(repository)
        {
        }
    }
}
