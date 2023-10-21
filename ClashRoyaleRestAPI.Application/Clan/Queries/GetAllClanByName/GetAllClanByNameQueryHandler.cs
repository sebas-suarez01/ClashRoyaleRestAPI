﻿using ClashRoyaleRestAPI.Application.Abstractions.CQRS;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Clan;
using ClashRoyaleRestAPI.Domain.Shared;

namespace ClashRoyaleRestAPI.Application.Clan.Queries.GetAllClanByName
{
    public class GetAllClanByNameQueryHandler : IQueryHandler<GetAllClanByNameQuery, IEnumerable<ClanModel>>
    {
        private readonly IClanRepository _repository;

        public GetAllClanByNameQueryHandler(IClanRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IEnumerable<ClanModel>>> Handle(GetAllClanByNameQuery request, CancellationToken cancellationToken)
        {
            var clans = await _repository.GetAllByName(request.Name);

            return Result.Create(clans);
        }
    }
}
