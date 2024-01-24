using ClashRoyaleRestAPI.API.Common.Requests;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Abstractions.PageQuery;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddCard;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddDonation;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddPlayerChallenge;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdateAlias;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdatePlayerChallengeResult;
using ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllCardOfPlayer;
using ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllPlayerByAlias;
using ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllPlayerWithRequirements;
using ClashRoyaleRestAPI.Application.Models.Player.Queries.GetPlayerByIdWithIncludes;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using ClashRoyaleRestAPI.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers;

[Route("api/players")]
public class PlayerController : ApiController
{
    public PlayerController(ISender sender) : base(sender)
    {
    }

    // GET: api/players
    [HttpGet]
    public async Task<IActionResult> GetAll(
        string? name, int? elo, string? sortColumn, string? sortOrder, int? page, int? pageSize)
    {
        Result<PageList<PlayerModel>> result;

        if (name is not null || elo is not null)
        {
            PlayerPageQuery pageQuery = new(name,
                                            elo,
                                            sortColumn,
                                            sortOrder,
                                            page.GetValueOrDefault(1),
                                            pageSize.GetValueOrDefault(10));

            var query = new GetAllPlayerWithRequirementsQuery(pageQuery);
            result = await _sender.Send(query);
        }
        else
        {
            var query = new GetAllModelQuery<PlayerModel, PlayerId>(sortOrder,
                                                               page.GetValueOrDefault(1),
                                                               pageSize.GetValueOrDefault(10));
            result = await _sender.Send(query);
        }
        return Ok(result.Value);
    }

    // GET api/players/{id:Guid}
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var playerId = ValueObjectId.Create<PlayerId>(id);

        var query = new GetPlayerByIdWithIncludesQuery(playerId);

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/players/{alias}
    [HttpGet("{alias}")]
    public async Task<IActionResult> GetAllByAlias(string alias)
    {
        var query = new GetAllPlayerByAliasQuery(alias);

        var result = await _sender.Send(query);

        return result.IsSuccess ?
            Ok(result.Value)
            : Problem(result.Errors);
    }

    // POST api/players
    [HttpPost]
    public async Task<IActionResult> Post(AddPlayerRequest playerRequest)
    {
        var player = PlayerModel.Create(playerRequest.Alias!, playerRequest.Elo, playerRequest.Level);

        var command = new AddModelCommand<PlayerModel, PlayerId>(player);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            Created($"api/players/{result.Value}", result.Value)
            : Problem(result.Errors);

    }

    // PUT api/players/{id:Guid}
    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePlayerRequest playerRequest)
    {
        if (id != playerRequest.Id)
            return Problem(ErrorTypes.Models.IdsNotMatch());

        var player = PlayerModel.Create(playerRequest.Id, playerRequest.Alias!, playerRequest.Elo,
                                        playerRequest.Level);

        var command = new UpdateModelCommand<PlayerModel, PlayerId>(player);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            NoContent()
            : Problem(result.Errors);
    }

    // DELETE api/players/{id:Guid}
    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var playerId = ValueObjectId.Create<PlayerId>(id);

        var commandDelete = new DeleteModelCommand<PlayerModel, PlayerId>(playerId);

        var result = await _sender.Send(commandDelete);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // GET api/players/{id:Guid}/cards
    [HttpGet("{id:Guid}/cards")]
    public async Task<IActionResult> GetCards(Guid id)
    {
        var playerId = ValueObjectId.Create<PlayerId>(id);

        var query = new GetAllCardOfPlayerQuery(playerId);

        var result = await _sender.Send(query);

        return result.IsSuccess ?
            Ok(result.Value)
            : Problem(result.Errors);
    }

    // POST api/players/{playerId:Guid}/cards/{cardId:int}
    [HttpPost("{playerId:Guid}/cards/{cardId:int}")]
    public async Task<IActionResult> AddCard(Guid playerId, int cardId)
    {
        var playerIdInstance = ValueObjectId.Create<PlayerId>(playerId);

        var command = new AddCardCommand(playerIdInstance, cardId);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            NoContent()
            : Problem(result.Errors);
    }

    // PATCH api/players/{playerId:Guid}/{alias}
    [HttpPatch("{playerId:Guid}/{alias}")]
    public async Task<IActionResult> UpdateAlias(Guid playerId, string alias)
    {
        var playerIdInstance = ValueObjectId.Create<PlayerId>(playerId);

        var query = new UpdatePlayerAliasCommand(playerIdInstance, alias);

        var result = await _sender.Send(query);

        return result.IsSuccess ?
            Ok()
            : Problem(result.Errors);
    }

    // PUT api/players/{playerId:Guid}/challenge/{challengeId:Guid}
    [HttpPut("{playerId:Guid}/challenge/{challengeId:Guid}")]
    public async Task<IActionResult> UpdateChallengeResult(Guid playerId, Guid challengeId, [FromBody] AddChallengeResultRequest addChallengeResult)
    {
        var playerIdInstance = ValueObjectId.Create<PlayerId>(playerId);

        var challengeIdInstance = ValueObjectId.Create<ChallengeId>(challengeId);

        var command = new UpdateChallengeResultCommand(playerIdInstance,
                                                       challengeIdInstance,
                                                       addChallengeResult.Reward);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // PUT api/players/{playerId:Guid}/challenge/{challengeId:Guid}
    [HttpPost("{playerId:Guid}/challenge/{challengeId:Guid}")]
    public async Task<IActionResult> PostPlayerChallenge(Guid playerId, Guid challengeId)
    {
        var playerIdInstance = ValueObjectId.Create<PlayerId>(playerId);

        var challengeIdInstance = ValueObjectId.Create<ChallengeId>(challengeId);

        var command = new AddPlayerChallengeCommand(playerIdInstance, challengeIdInstance);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // POST api/players/{playerId:Guid}/donate
    [HttpPost("{playerId:Guid}/donate")]
    public async Task<IActionResult> MakeDonation(Guid playerId, [FromBody] AddDonationRequest addDonationRequest)
    {
        var playerIdInstance = ValueObjectId.Create<PlayerId>(playerId);

        var clanIdInstance = ValueObjectId.Create<ClanId>(addDonationRequest.ClanId);

        var command = new AddDonationCommand(playerIdInstance,
                                             clanIdInstance,
                                             addDonationRequest.CardId,
                                             addDonationRequest.Amount,
                                             DateTime.Now);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

}
