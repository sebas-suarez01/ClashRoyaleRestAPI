using ClashRoyaleRestAPI.API.Common.Requests;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Models.War.Commands.AddClanWar;
using ClashRoyaleRestAPI.Application.Models.War.Queries.GetUpCommingWars;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers;

[Route("api/wars")]
public class WarController : ApiController
{
    public WarController(ISender sender) : base(sender)
    {
    }

    // GET: api/wars
    [HttpGet]
    public async Task<IActionResult> GetAll(string? sortOrder, int? page, int? pageSize)
    {
        var query = new GetAllModelQuery<WarModel, WarId>(sortOrder,
                                                        page.GetValueOrDefault(1),
                                                        pageSize.GetValueOrDefault(10));

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/wars/{warId:Guid}
    [HttpGet("{warId:Guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var warId = ValueObjectId.Create<WarId>(id);

        var query = new GetModelByIdQuery<WarModel, WarId>(warId);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // POST api/wars
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddWarRequest warRequest)
    {
        var war = WarModel.Create(warRequest.StartDate);

        var command = new AddModelCommand<WarModel, WarId>(war);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            Created($"api/wars/{result.Value}", result.Value)
            : Problem(result.Errors);
    }

    // DELETE api/wars/{id:Guid}
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var warId = ValueObjectId.Create<WarId>(id);

        var command = new DeleteModelCommand<WarModel, WarId>(warId);

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

    // POST api/wars/{warId:Guid}/{clanId:Guid}
    [HttpPost("{warId:Guid}/{clanId:Guid}")]
    public async Task<IActionResult> AddClanToWar(Guid warId, Guid clanId, int prize)
    {
        var warIdInstance = ValueObjectId.Create<WarId>(warId);
        
        var clanIdInstance = ValueObjectId.Create<ClanId>(clanId);


        var command = new AddClanWarCommand(clanIdInstance, warIdInstance, prize);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }
}
