using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers
{
    [Route("api/battles")]
    public class BattleController : ApiController
    {
        private readonly ISender _sender;
        public BattleController(ISender sender)
        {
            _sender = sender;
        }
    }
}
