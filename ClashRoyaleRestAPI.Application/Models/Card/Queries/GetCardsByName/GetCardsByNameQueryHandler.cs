using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Card.Queries.GetCardsByName
{
    internal class GetCardsByNameQueryHandler : IQueryHandler<GetCardsByNameQuery, IEnumerable<CardModel>>
    {
        private readonly ICardRepository _repository;
        public GetCardsByNameQueryHandler(ICardRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<CardModel>>> Handle(GetCardsByNameQuery request, CancellationToken cancellationToken)
        {
            //var cards = await _repository.GetModelDataAsync(new GetCardsByNameSpecification(request.Name));
            var cards = await _repository.GetCardsByNameAsync(request.Name);

            return Result.Create(cards);
        }
    }
}
