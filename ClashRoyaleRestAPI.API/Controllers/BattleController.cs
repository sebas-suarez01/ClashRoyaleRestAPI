using AutoMapper;
using ClashRoyaleRestAPI.API.Common.Requests;
using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Queries.GetAllModel;
using ClashRoyaleRestAPI.Application.Models.Battle.Command.AddBattle;
using ClashRoyaleRestAPI.Application.Models.Battle.Queries.GetBattleByIdWithIncludes;
using ClashRoyaleRestAPI.Domain.Models;
using ClashRoyaleRestAPI.Domain.Primitives.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ClashRoyaleRestAPI.API.Controllers;

[Route("api/battles")]
public class BattleController : ApiController
{
    private readonly IMapper _mapper;
    public BattleController(ISender sender, IMapper mapper) : base(sender)
    {
        _mapper = mapper;
    }

    // GET: api/battles
    [HttpGet]
    public async Task<IActionResult> GetAll(string? sortOrder, int? page, int? pageSize)
    {
        var query = new GetAllModelQuery<BattleModel, BattleId>(sortOrder,
                                                                page.GetValueOrDefault(1),
                                                                pageSize.GetValueOrDefault(10));

        var result = await _sender.Send(query);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Errors);
    }

    // GET api/battles/{id:Guid}
    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var battleId = ValueObjectId.Create<BattleId>(id);

        var query = new GetBattleByIdWithIncludesQuery(battleId);

        var result = await _sender.Send(query);

        return result.IsSuccess ?
            Ok(result.Value)
            : Problem(result.Errors);
    }

    // POST api/battles
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddBattleRequest battleRequest)
    {

        var winnerId = ValueObjectId.Create<PlayerId>(battleRequest.WinnerId);
        
        var loserId = ValueObjectId.Create<PlayerId>(battleRequest.LoserId);

        var command = new AddBattleCommand(winnerId,
                                           loserId,
                                           battleRequest.AmountTrophies,
                                           battleRequest.DurationInSeconds,
                                           battleRequest.Date);

        var result = await _sender.Send(command);

        return result.IsSuccess ?
            Created($"api/battles/{result.Value}", result.Value)
            : Problem(result.Errors);
    }
}
