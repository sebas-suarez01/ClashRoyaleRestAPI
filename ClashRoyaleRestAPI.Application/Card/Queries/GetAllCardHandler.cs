using ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Card.Queries
{
    public class GetAllCardHandler : GetAllModelQueryHandler<CardModel, int>
    {
        public GetAllCardHandler(ICardRepository repository) : base(repository)
        {
        }
    }
}
