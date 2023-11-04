using ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllPlayer
{
    internal class GetAllPlayerQueryHandler : GetAllModelQueryHandler<PlayerModel, int>
    {
        public GetAllPlayerQueryHandler(IPlayerRepository repository) : base(repository)
        {
        }
    }
}
