using ClashRoyaleRestAPI.API.Common.Requests;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Models.War.Commands.AddClanWar;
using ClashRoyaleRestAPI.Application.Models.War.Queries.GetUpCommingWars;
using ClashRoyaleRestAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers;

[Route("api/wars")]
public class WarController : ApiController
{
    public WarController(IMediator sender) : base(sender)
    {
    }

    // GET: api/wars
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllModelQuery<WarModel, int>();

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/wars/{warId:int}
    [HttpGet("{warId:int}")]
    public async Task<IActionResult> Get(int warId)
    {
        var query = new GetModelByIdQuery<WarModel, int>(warId);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // POST api/wars
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddWarRequest warRequest)
    {
        var war = WarModel.Create(warRequest.StartDate);

        var command = new AddModelCommand<WarModel, int>(war);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            Created($"api/wars/{result.Value}", result.Value)
            : Problem(result.Errors);
    }

    // DELETE api/wars/{warId:int}
    [HttpDelete("{warId:int}")]
    public async Task<IActionResult> Delete(int warId)
    {
        var command = new DeleteModelCommand<WarModel, int>(warId);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // GET: api/wars/date/{date:DateTime}
    [HttpGet("date/{date:DateTime}")]
    public async Task<IActionResult> GetUpComingWars(DateTime date)
    {
        var query = new GetUpComingWarsQuery(date);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // POST api/wars/{warId:int}/{clanId:int}
    [HttpPost("{warId:int}/{clanId:int}")]
    public async Task<IActionResult> AddClanToWar(int warId, int clanId, int prize)
    {
        var command = new AddClanWarCommand(clanId, warId, prize);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }
}
