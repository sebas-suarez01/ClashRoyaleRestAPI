using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllClanWithRequirements
{
    internal class GetAllClanWithRequirementsQueryHandler : IQueryHandler<GetAllClanWithRequirementsQuery, IEnumerable<ClanModel>>
    {
        private readonly IClanRepository _clanRepository;

        public GetAllClanWithRequirementsQueryHandler(IClanRepository clanRepository)
        {
            _clanRepository = clanRepository;
        }

        public async Task<Result<IEnumerable<ClanModel>>> Handle(GetAllClanWithRequirementsQuery request, CancellationToken cancellationToken)
        {
            var results = await _clanRepository.GetAllAsync(request.Name,
                                                            request.Region,
                                                            request.MinTrophies,
                                                            request.TrophiesInWar,
                                                            request.Availables,
                                                            request.SortColumn,
                                                            request.SortOrder);

            return Result.Create(results);
        }
    }
}
