using ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers
{
    [Route("api/cards")]
    public class CardController : ApiController
    {
        private readonly IMediator _sender;
        public CardController(IMediator sender)
        {
            _sender = sender;
        }

        // GET api/cards/{id:int}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetModelByIdQuery<CardModel, int>(id);

            ErrorOr<CardModel> response = await _sender.Send(query);

            return response.Match(
                response => Ok(response),
                errors => Problem(errors));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllModelQuery<CardModel, int>();

            IEnumerable<CardModel> cards = await _sender.Send(query);

            return Ok(cards);
        }
    }
}
