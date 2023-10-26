using ClashRoyaleRestAPI.Application.Common.Queries.ExistsModelId;
using ClashRoyaleRestAPI.Application.Interfaces.Repositories;
using ClashRoyaleRestAPI.Domain.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashRoyaleRestAPI.Application.Models.Player.Queries
{
    public class ExistsPlayerId : ExistsModelIdQueryHandler<PlayerModel, int>
    {
        public ExistsPlayerId(IPlayerRepository repository) : base(repository)
        {
        }
    }
}
