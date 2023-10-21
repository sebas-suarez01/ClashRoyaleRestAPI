using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Models.Clan;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Clan.Queries.GetClanByIdFullLoad
{
    public class GetClanByIdFullLoadQueryHandler : IQueryHandler<GetClanByIdFullLoadQuery, ClanModel>
    {
        private readonly IClanRepository _repository;

        public GetClanByIdFullLoadQueryHandler(IClanRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<ClanModel>> Handle(GetClanByIdFullLoadQuery request, CancellationToken cancellationToken)
        {
            var clan = await _repository.GetSingleByIdAsync(request.Id, true);

            if (clan is null)
                return Result.Failure<ClanModel>(ErrorTypes.Models.IdNotFound);

            return clan;
        }
    }
}
