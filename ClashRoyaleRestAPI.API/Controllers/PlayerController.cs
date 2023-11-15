using ClashRoyaleRestAPI.API.Common.Requests;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddCard;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddDonation;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.AddPlayerChallenge;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdateAlias;
using ClashRoyaleRestAPI.Application.Models.Player.Commands.UpdatePlayerChallengeResult;
using ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllCardOfPlayer;
using ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllPlayerByAlias;
using ClashRoyaleRestAPI.Application.Models.Player.Queries.GetAllPlayerWithRequirements;
using ClashRoyaleRestAPI.Application.Models.Player.Queries.GetPlayerByIdFullLoad;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers;

[Route("api/players")]
public class PlayerController : ApiController
{
    public PlayerController(IMediator sender) : base(sender)
    {
    }

    // GET: api/players
    [HttpGet]
    public async Task<IActionResult> GetAll(
        string? name, int? elo, string? sortColumn, string? sortOrder, int page = 1, int pageSize = 10)
    {
        Result<PageList<PlayerModel>> result;

        if(name is not null || elo is not null || sortColumn is not null || sortOrder is not null)
        {
            var query = new GetAllPlayerWithRequirementsQuery(name, elo, sortColumn, sortOrder, page, pageSize); 
            result = await _sender.Send(query);
        }
        else
        {
            var query = new GetAllModelQuery<PlayerModel, int>();
            result = await _sender.Send(query);
        }
        return Ok(result.Value);
    }

    // GET api/players/{id:int}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetPlayerByIdFullLoadQuery(id, true);

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

        var command = new AddModelCommand<PlayerModel, int>(player);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            Created($"api/players/{result.Value}", result.Value)
            : Problem(result.Errors);

    }

    // PUT api/players/{id:int}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdatePlayerRequest playerRequest)
    {
        if (id != playerRequest.Id)
            return Problem(ErrorTypes.Models.IdsNotMatch());

        var player = PlayerModel.Create(playerRequest.Id, playerRequest.Alias!, playerRequest.Elo,
                                        playerRequest.Level);

        var command = new UpdateModelCommand<PlayerModel, int>(player);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            NoContent()
            : Problem(result.Errors);
    }

    // DELETE api/players/{id:int}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var commandDelete = new DeleteModelCommand<PlayerModel, int>(id);

        var result = await _sender.Send(commandDelete);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // GET api/players/{id:int}/cards
    [HttpGet("{id:int}/cards")]
    public async Task<IActionResult> GetCards(int id)
    {
        var query = new GetAllCardOfPlayerQuery(id);

        var result = await _sender.Send(query);

        return result.IsSuccess ?
            Ok(result.Value)
            : Problem(result.Errors);
    }

    // POST api/players/{playerId:int}/cards/{cardId:int}
    [HttpPost("{playerId:int}/cards/{cardId:int}")]
    public async Task<IActionResult> AddCard(int playerId, int cardId)
    {
        var command = new AddCardCommand(playerId, cardId);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            NoContent()
            : Problem(result.Errors);
    }

    // PATCH api/players/{playerId:int}/{alias}
    [HttpPatch("{playerId:int}/{alias}")]
    public async Task<IActionResult> UpdateAlias(int playerId, string alias)
    {
        var query = new UpdatePlayerAliasCommand(playerId, alias);

        var result = await _sender.Send(query);

        return result.IsSuccess ?
            Ok()
            : Problem(result.Errors);
    }

    // PUT api/players/{playerId:int}/challenge/{challengeId:int}
    [HttpPut("{playerId:int}/challenge/{challengeId:int}")]
    public async Task<IActionResult> UpdateChallengeResult(int playerId, int challengeId, [FromBody] AddChallengeResultRequest addChallengeResult)
    {
        var command = new UpdateChallengeResultCommand(playerId, challengeId, addChallengeResult.Reward);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // PUT api/players/{playerId:int}/challenge/{challengeId:int}
    [HttpPost("{playerId:int}/challenge/{challengeId:int}")]
    public async Task<IActionResult> PostPlayerChallenge(int playerId, int challengeId)
    {
        var command = new AddPlayerChallengeCommand(playerId, challengeId);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // POST api/players/{playerId:int}/donate
    [HttpPost("{playerId:int}/donate")]
    public async Task<IActionResult> MakeDonation(int playerId, [FromBody] AddDonationRequest addDonationRequest)
    {
        var command = new AddDonationCommand(
            playerId,
            addDonationRequest.ClanId,
            addDonationRequest.CardId,
            addDonationRequest.Amount);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

}
