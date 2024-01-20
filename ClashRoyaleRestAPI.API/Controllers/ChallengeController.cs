using ClashRoyaleRestAPI.API.Common.Requests;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.AddModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.DeleteModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Commands.UpdateModel;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Models.Challenge.Queries.GetAllOpen;
using ClashRoyaleRestAPI.Domain.Errors;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers;

[Route("api/challenges")]
public class ChallengeController : ApiController
{
    public ChallengeController(ISender sender) : base(sender)
    {
    }

    // GET api/challenges/{id:int}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var challengeId = ChallengeId.Create(id);

        var quey = new GetModelByIdQuery<ChallengeModel, ChallengeId>(challengeId);

        var result = await _sender.Send(quey);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/challenges/open
    [HttpGet("open")]
    public async Task<IActionResult> GetAllOpenChallenges()
    {
        var query = new GetAllOpenChallengeQuery();

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // POST api/challenges
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddChallengeRequest challengeRequest)
    {
        var challenge = ChallengeModel.Create(challengeRequest.Name!, challengeRequest.Description!,
                                              challengeRequest.Cost, challengeRequest.AmountReward,
                                              challengeRequest.StartDate, challengeRequest.DurationInHours,
                                              challengeRequest.IsOpen, challengeRequest.MinLevel,
                                              challengeRequest.LossLimit);

        var command = new AddModelCommand<ChallengeModel, ChallengeId>(challenge);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            Created($"api/challenges/{result.Value}", result.Value) :
            Problem(result.Errors);
    }

    // PUT api/challenges/{id:int}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateChallengeRequest challengeRequest)
    {
        if (id != challengeRequest.Id)
            return Problem(ErrorTypes.Models.IdsNotMatch());

        var challenge = ChallengeModel.Create(challengeRequest.Id, challengeRequest.Name!, 
                                              challengeRequest.Description!, challengeRequest.Cost, 
                                              challengeRequest.AmountReward, challengeRequest.StartDate, 
                                              challengeRequest.DurationInHours, challengeRequest.IsOpen, 
                                              challengeRequest.MinLevel, challengeRequest.LossLimit);

        var command = new UpdateModelCommand<ChallengeModel, ChallengeId>(challenge);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }

    // DELETE api/challenges/{id:int}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var challengeId = ChallengeId.Create(id);

        var command = new DeleteModelCommand<ChallengeModel, ChallengeId>(challengeId);

        var result = await _sender.Send(command);

        return result.IsSuccess ? NoContent() : Problem(result.Errors);
    }
}
