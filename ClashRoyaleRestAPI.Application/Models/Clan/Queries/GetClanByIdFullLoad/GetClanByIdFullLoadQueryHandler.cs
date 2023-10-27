using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Exceptions;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanByIdFullLoad
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
            ClanModel clan;
            try
            {
                clan = await _repository.GetSingleByIdAsync(request.Id, true);
            }
            catch (IdNotFoundException<int> e)
            {
                return Result.Failure<ClanModel>(ErrorTypes.Models.IdNotFound(e.Message));
            }

            return clan!;
        }
    }
}
