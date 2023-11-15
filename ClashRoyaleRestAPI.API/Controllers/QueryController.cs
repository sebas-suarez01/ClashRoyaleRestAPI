using ClashRoyaleRestAPI.Application.Abstractions.CQRS.Generic.Queries.GetModelById;
using ClashRoyaleRestAPI.Application.Predefined_Queries.FifthQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.FirstQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.FourthQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.SecondQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.SeventhQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.SixthQuery;
using ClashRoyaleRestAPI.Application.Predefined_Queries.ThirdQuery;
using ClashRoyaleRestAPI.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClashRoyaleRestAPI.API.Controllers;

[Route("api/queries")]
public class QueryController : ApiController
{
    public QueryController(IMediator sender) : base(sender)
    {
        
    }

    // GET api/queries/firstquery
    [HttpGet("firstquery")]
    public async Task<IActionResult> GetFirstQuery()
    {
        var query = new FirstQuery();

        var result = await _sender.Send(query);

        return Ok(result.Value);
    }

    // GET api/queries/secondquery
    [HttpGet("secondquery")]
    public async Task<IActionResult> GetSecondQuery()
    {
        var query = new SecondQuery();

        var result = await _sender.Send(query);

        return Ok(result.Value);
    }

    // GET api/queries/thirdquery
    [HttpGet("thirdquery")]
    public async Task<IActionResult> GetThirdQuery()
    {
        var query = new ThirdQuery();

        var result = await _sender.Send(query);

        return Ok(result.Value);
    }

    // GET api/queries/fourthquery
    [HttpGet("fourthquery")]
    public async Task<IActionResult> GetFourthQuery()
    {
        var query = new FourthQuery();

        var result = await _sender.Send(query);

        return Ok(result.Value);
    }

    // GET api/queries/fifthquery/{playerId:int}
    [HttpGet("fifthquery/{playerId:int}")]
    public async Task<IActionResult> GetFifthQuery(int playerId)
    {
        var queryPlayer = new GetModelByIdQuery<PlayerModel, int>(playerId);

        var resultPlayer = await _sender.Send(queryPlayer);

        if(!resultPlayer.IsSuccess)
            return Problem(resultPlayer.Errors);

        var query = new FifthQuery(resultPlayer.Value.Elo);

        var result = await _sender.Send(query);

        return Ok(result.Value);
    }

    // GET api/queries/sixthquery
    [HttpGet("sixthquery")]
    public async Task<IActionResult> GetSixthQuery()
    {
        var query = new SixthQuery();

        var result = await _sender.Send(query);

        return Ok(result.Value);
    }

    // GET api/queries/seventhquery/{year:int}
    [HttpGet("seventhquery/{year:int}")]
    public async Task<IActionResult> GetSeventhQuery(int year)
    {
        var query = new SeventhQuery(year);

        var result = await _sender.Send(query);

        return Ok(result.Value);
    }
}
