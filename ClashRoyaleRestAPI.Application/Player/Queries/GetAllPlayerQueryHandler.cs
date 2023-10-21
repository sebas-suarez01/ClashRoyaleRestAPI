using ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Player;

namespace ClashRoyaleRestAPI.Application.Player.Queries
{
    public class GetAllPlayerQueryHandler : GetAllModelQueryHandler<PlayerModel, int>
    {
        public GetAllPlayerQueryHandler(IPlayerRepository repository) : base(repository)
        {
        }
    }
}
