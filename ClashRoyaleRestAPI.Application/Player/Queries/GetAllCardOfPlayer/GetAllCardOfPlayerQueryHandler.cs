using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Models.Player;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Player.Queries.GetAllCardOfPlayer
{
    public class GetAllCardOfPlayerQueryHandler : IQueryHandler<GetAllCardOfPlayerQuery, IEnumerable<CardModel>>
    {
        private readonly IPlayerRepository _repository;

        public GetAllCardOfPlayerQueryHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<CardModel>>> Handle(GetAllCardOfPlayerQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<CardModel> cards;

            try
            {
                cards = await _repository.GetAllCardsOfPlayerAsync(request.Id);
            }
            catch (IdNotFoundException)
            {
                return Result.Failure<IEnumerable<CardModel>>(ErrorTypes.Models.IdNotFound);
            }

            return Result.Create(cards);
        }
    }
}
