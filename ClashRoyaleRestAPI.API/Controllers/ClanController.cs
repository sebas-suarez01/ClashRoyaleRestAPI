using ClashRoyaleRestAPI.API.Common.Requests;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddClan;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.AddPlayerClan;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.RemovePlayerClan;
using ClashRoyaleRestAPI.Application.Models.Clan.Commands.UpdatePlayerRank;
using ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllClanByName;
using ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllClanWithRequirements;
using ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetAllPlayers;
using ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanAvailables;
using ClashRoyaleRestAPI.Application.Models.Clan.Queries.GetClanByIdFullLoad;
using ClashRoyaleRestAPI.Domain.Enum;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Models;
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
            var query = new GetAllModelQuery<ClanModel, int>(sortOrder,
                                                             page.GetValueOrDefault(1),
                                                             pageSize.GetValueOrDefault(10));

            result = await _sender.Send(query);
        }

        return Ok(result.Value);
    }

    // GET api/clans/{clanId:int}
    [HttpGet("{clanId:int}")]
    public async Task<IActionResult> Get(int clanId)
    {
        var query = new GetClanByIdFullLoadQuery(clanId, true);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // POST api/clans/{playerId:int}
    [HttpPost("{playerId:int}")]
    public async Task<IActionResult> Post(int playerId, [FromBody] AddClanRequest clanRequest)
    {
        var clan = ClanModel.Create(clanRequest.Name!, clanRequest.Description!, clanRequest.Region!,
                                    clanRequest.TypeOpen, clanRequest.TrophiesInWar, clanRequest.MinTrophies);

        var command = new AddClanCommand(playerId, clan);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            Created($"api/clans/{result.Value}", result.Value)
            : Problem(result.Errors);
    }

    // PUT api/clans/{clanId:int}
    [HttpPut("{clanId:int}")]
    public async Task<IActionResult> Put(int clanId, [FromBody] UpdateClanRequest clanRequest)
    {
        if (clanId != clanRequest.Id)
            return Problem(ErrorTypes.Models.IdsNotMatch());

        var clan = ClanModel.Create(clanRequest.Id, clanRequest.Name!, clanRequest.Description!,
                                    clanRequest.Region!, clanRequest.TypeOpen, clanRequest.TrophiesInWar, 
                                    clanRequest.MinTrophies);

        var command = new UpdateModelCommand<ClanModel, int>(clan);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // DELETE api/clans/{clanId:int}
    [HttpDelete("{clanId:int}")]
    public async Task<IActionResult> Delete(int clanId)
    {
        var command = new DeleteModelCommand<ClanModel, int>(clanId);

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

    // GET api/clans/{clanId:int}/players
    [HttpGet("{clanId:int}/players")]
    public async Task<IActionResult> GetPlayers(int clanId)
    {
        var query = new GetAllPlayersQuery(clanId);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // POST api/clans/{clanId:int}/players/{playerId:int}
    [HttpPost("{clanId:int}/players/{playerId:int}")]
    public async Task<IActionResult> AddPlayer(int clanId, int playerId)
    {
        var command = new AddPlayerClanCommand(clanId, playerId);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // DELETE api/clans/{clanId:int}/players/{playerId:int}
    [HttpDelete("{clanId:int}/players/{playerId:int}")]
    public async Task<IActionResult> RemovePlayer(int clanId, int playerId)
    {
        var command = new RemovePlayerClanCommand(clanId, playerId);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // PATCH api/clans/{clanId:int}/players/{playerId}/rank/{rank:int}
    [HttpPatch("{clanId:int}/players/{playerId:int}/rank/{rank:int}")]
    public async Task<IActionResult> UpdatePlayerRank(int clanId, int playerId, RankClan rank)
    {
        var command = new UpdatePlayerRankCommand(clanId, playerId, rank);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }
}
