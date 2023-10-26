using ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Clan;

namespace ClashRoyaleRestAPI.Application.Models.Clan.Queries
{
    public class GetAllClanQueryHandler : GetAllModelQueryHandler<ClanModel, int>
    {
        public GetAllClanQueryHandler(IClanRepository repository) : base(repository)
        {
        }
    }
}
