using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers
{
    [Route("api/players")]
    public class PlayerController : ApiController
    {
        private readonly ISender _sender;
        public PlayerController(ISender sender)
        {
            _sender = sender;
        }
    }
}
