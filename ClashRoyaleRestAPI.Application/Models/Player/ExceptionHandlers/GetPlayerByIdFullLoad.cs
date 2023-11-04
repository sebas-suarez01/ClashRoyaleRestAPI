using ClashRoyaleRestAPI.Application.Common.ExceptionHandlers;
using ClashRoyaleRestAPI.Application.Models.Player.Queries.GetPlayerByIdFullLoad;
using ClashRoyaleRestAPI.Domain.Models;

namespace ClashRoyaleRestAPI.Application.Models.Player.ExceptionHandlers
{
    internal class GetPlayerByIdFullLoad
        : RequestExceptionHandler<GetPlayerByIdFullLoadQuery, PlayerModel, int>
    {
    }
}
