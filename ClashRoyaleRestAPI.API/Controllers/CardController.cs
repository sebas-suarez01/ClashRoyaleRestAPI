using AutoMapper;
using ClashRoyaleRestAPI.API.Common.Mapping.Objects;
using ClashRoyaleRestAPI.API.Common.Mapping.Utils;
using ClashRoyaleRestAPI.Application.Card.Queries.GetCardsByName;
using ClashRoyaleRestAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleRestAPI.Domain.Common.Errors;
using ClashRoyaleRestAPI.Domain.Models.Card;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers
{
    [Route("api/cards")]
    public class CardController : ApiController
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        public CardController(IMediator sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
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

        // GET api/cards/{name:string}
        [HttpGet("{name}")]
        public async Task<IActionResult> GetCardsByName(string name)
        {
            var query = new GetCardsByNameQuery(name);

            IEnumerable<CardModel> cards = await _sender.Send(query);

            return Ok(cards);
        }

        // PUT api/cards/{id:int}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] CardRequest cardRequest)
        {
            if (id != cardRequest.Id)
                return Problem(Errors.Models.IdsNotMatch);

            var card = MapCardFromTypeEnum.MapCard(cardRequest, _mapper);

            if (card == null)
                return Problem();

            var command = new UpdateModelCommand<CardModel, int>(card);

            await _sender.Send(command);

            return NoContent();
        }
    }
}
