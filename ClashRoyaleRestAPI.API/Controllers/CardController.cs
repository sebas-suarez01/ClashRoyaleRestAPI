using AutoMapper;
using ClashRoyaleRestAPI.API.Common.Mapping.Objects;
using ClashRoyaleRestAPI.API.Common.Mapping.Utils;
using ClashRoyaleRestAPI.Application.Auth.Utils;
using ClashRoyaleRestAPI.Application.Common.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Common.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Common.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Common.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Models.Card.Queries.GetCardsByName;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Models.Card;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers;

[Route("api/cards")]
public class CardController : ApiController
{
    private readonly IMapper _mapper;
    public CardController(ISender sender, IMapper mapper) : base(sender)
    {
        _mapper = mapper;
    }

    // GET api/cards/{id:int}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetModelByIdQuery<CardModel, int>(id);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);

    }

    // GET api/cards
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllModelQuery<CardModel, int>();

        var result = await _sender.Send(query);

        return Ok(result.Value);
    }

    // GET api/cards/{name:string}
    [HttpGet("{name}")]
    public async Task<IActionResult> GetCardsByName(string name)
    {
        var query = new GetCardsByNameQuery(name);

        var result = await _sender.Send(query);

        return Ok(result.Value);
    }

    // PUT api/cards/{id:int}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] CardRequest cardRequest)
    {
        if (id != cardRequest.Id)
            return Problem(ErrorTypes.Models.IdsNotMatch());

        var card = MapCardFromTypeEnum.MapCard(cardRequest, _mapper);

        if (card == null)
            return Problem();

        var command = new UpdateModelCommand<CardModel, int>(card);

        await _sender.Send(command);

        return NoContent();
    }

    // DELETE api/cards/{id:int}
    [Authorize(Roles = UserRoles.SUPERADMIN)]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var commandDelete = new DeleteModelCommand<CardModel, int>(id);

        var result = await _sender.Send(commandDelete);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }
}
