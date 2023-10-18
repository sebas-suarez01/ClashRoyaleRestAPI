using ClashRoyaleRestAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Card.Commands
{
    public class UpdateCardHandler : UpdateModelCommandHandler<UpdateModelCommand<CardModel, int>, CardModel, int>
    {
        public UpdateCardHandler(ICardRepository repository) : base(repository)
        {
        }
    }
}
