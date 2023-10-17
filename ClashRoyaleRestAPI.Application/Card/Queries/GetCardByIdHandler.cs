using ClashRoyaleRestAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Card.Queries
{
    public class GetCardByIdHandler : GetModelByIdHandler<GetModelByIdQuery<CardModel, int>, CardModel, int>
    {
        public GetCardByIdHandler(ICardRepository repository) : base(repository)
        {
        }
    }
}
