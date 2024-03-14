using ClashRoyaleRestAPI.API.Common.Requests;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddClan;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddPlayerClan;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.RemovePlayerClan;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdatePlayerRank;
using ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllClanByName;
using ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllClanWithRequirements;
using ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllPlayers;
using ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanAvailables;
using ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanByIdWithIncludes;
using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers;

[Route("api/clans")]
public class ClanController : ApiController
{
    public ClanController(ISender sender) : base(sender)
    {
    }

    // GET: api/clans
    [HttpGet]
    public async Task<IActionResult> GetAll(string? name, string? region, int? minTrophies, int? trophiesInWar,
                                            bool? availables, string? sortColumn, string? sortOrder, int? page,
                                            int? pageSize)
    {
        Result<PageList<ClanModel>> result;
        if (name is not null || region is not null || minTrophies is not null || trophiesInWar is not null ||
            availables is not null || sortColumn is not null)
        {
            var query = new GetAllClanWithRequirementsQuery(name,
                                                            region,
                                                            minTrophies,
                                                            trophiesInWar,
                                                            availables,
                                                            sortColumn,
                                                            sortOrder,
                                                            page.GetValueOrDefault(1),
                                                            pageSize.GetValueOrDefault(10));

            result = await _sender.Send(query);

        }
        else
        {
            var query = new GetAllModelQuery<ClanModel, ClanId>(sortOrder,
                                                             page.GetValueOrDefault(1),
                                                             pageSize.GetValueOrDefault(10));

            result = await _sender.Send(query);
        }

        return Ok(result.Value);
    }

    // GET api/clans/{id:Guid}
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var clanId = ValueObjectId.Create<ClanId>(id);

        var query = new GetClanByIdWithIncludesQuery(clanId);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // POST api/clans/{playerId:Guid}
    [HttpPost("{playerId:Guid}")]
    public async Task<IActionResult> Post(Guid playerId, [FromBody] AddClanRequest clanRequest)
    {
        var clan = ClanModel.Create(clanRequest.Name!, clanRequest.Description!, clanRequest.Region!,
            clanRequest.TypeOpen, clanRequest.TrophiesInWar, clanRequest.MinTrophies);

        var playerIdInstance = ValueObjectId.Create<PlayerId>(playerId);

        var command = new AddClanCommand(playerIdInstance, clan);

        var result = await _sender.Send(command);

        return result.IsSuccess
            ? Created($"api/clans/{result.Value}", result.Value)
            : Problem(result.Errors);
    }

    // PUT api/clans/{clanId:Guid}
    [HttpPut("{clanId:Guid}")]
    public async Task<IActionResult> Put(Guid clanId, [FromBody] UpdateClanRequest clanRequest)
    {
        if (clanId != clanRequest.Id)
            return Problem(ErrorTypes.Models.IdsNotMatch());

        var clan = ClanModel.Create(clanRequest.Id, clanRequest.Name!, clanRequest.Description!,
                                    clanRequest.Region!, clanRequest.TypeOpen, clanRequest.TrophiesInWar,
                                    clanRequest.MinTrophies);

        var command = new UpdateModelCommand<ClanModel, ClanId>(clan);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // DELETE api/clans/{clanId:Guid}
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var clanId = ValueObjectId.Create<ClanId>(id);

        var command = new DeleteModelCommand<ClanModel, ClanId>(clanId);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // GET api/clans/availables/{trophies:int}
    [HttpGet("availables/{trophies:int}")]
    public async Task<IActionResult> GetClanAvailables(int trophies)
    {
        var query = new GetClanAvailablesQuery(trophies);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/clans/name/{clanName}
    [HttpGet("name/{clanName}")]
    public async Task<IActionResult> GetClansByName(string clanName)
    {
        var query = new GetAllClanByNameQuery(clanName);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/clans/{id:int}/players
    [HttpGet("{id:Guid}/players")]
    public async Task<IActionResult> GetPlayers(Guid id)
    {
        var clanId = ValueObjectId.Create<ClanId>(id);

        var query = new GetAllPlayersQuery(clanId);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // POST api/clans/{clanId:Guid}/players/{playerId:Guid}
    [HttpPost("{clanId:Guid}/players/{playerId:Guid}")]
    public async Task<IActionResult> AddPlayer(Guid clanId, Guid playerId)
    {
        var clanIdInstance = ValueObjectId.Create<ClanId>(clanId);

        var playerIdInstance = ValueObjectId.Create<PlayerId>(playerId);

        var command = new AddPlayerClanCommand(clanIdInstance, playerIdInstance);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // DELETE api/clans/{clanId:Guid}/players/{playerId:Guid}
    [HttpDelete("{clanId:Guid}/players/{playerId:Guid}")]
    public async Task<IActionResult> RemovePlayer(Guid clanId, Guid playerId)
    {
        var clanIdInstance = ValueObjectId.Create<ClanId>(clanId);

        var playerIdInstance = ValueObjectId.Create<PlayerId>(playerId);

        var command = new RemovePlayerClanCommand(clanIdInstance, playerIdInstance);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // PATCH api/clans/{clanId:Guid}/players/{playerId:Guid}/rank/{rank:int}
    [HttpPatch("{clanId:Guid}/players/{playerId:Guid}/rank/{rank:int}")]
    public async Task<IActionResult> UpdatePlayerRank(Guid clanId, Guid playerId, RankClan rank)
    {
        var clanIdInstance = ValueObjectId.Create<ClanId>(clanId);

        var playerIdInstance = ValueObjectId.Create<PlayerId>(playerId);

        var command = new UpdatePlayerRankCommand(clanIdInstance, playerIdInstance, rank);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }
}
