using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static ClashRoyaleRestAPI.Domain.Common.Errors.Errors;

namespace ClashRoyaleRestAPI.Application.Card.Queries.GetCardsByName
{
    public class GetCardsByNameQueryHandler : IRequestHandler<GetCardsByNameQuery, IEnumerable<CardModel>>
    {
        private readonly ICardRepository _repository;
        public GetCardsByNameQueryHandler(ICardRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<CardModel>> Handle(GetCardsByNameQuery request, CancellationToken cancellationToken) =>
            await _repository.GetCardsByNameAsync(request.Name);
    }
}
