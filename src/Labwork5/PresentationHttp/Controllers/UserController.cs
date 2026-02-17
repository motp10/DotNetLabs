using Application.Contracts.Models;
using Application.Contracts.Operations;
using Application.Contracts.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using PresentationHttp.Models;
using System.Diagnostics;

namespace PresentationHttp.Controllers;

[ApiController]
[Route("/api/operations")]

public class UserController : ControllerBase
{
    private readonly IUserServise _itemService;

    public UserController(IUserServise itemService)
    {
        _itemService = itemService;
    }

    [HttpGet("balance")]
    public ActionResult<OperationDto> GetBalance([FromBody] OperationRequest httpRequest)
    {
        var request = new DoOperation.Request(httpRequest.Key, httpRequest.Amount);
        DoOperation.Response response = _itemService.GetBalance(request);

        return response switch
        {
            DoOperation.Response.Success success => Ok(response),
            DoOperation.Response.Unauthorized failure => Unauthorized(),
            DoOperation.Response.BadRequest failure => BadRequest(failure.Message),

            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("deposit")]
    public ActionResult<OperationDto> Deposit([FromBody] OperationRequest httpRequest)
    {
        var request = new DoOperation.Request(httpRequest.Key, httpRequest.Amount);
        DoOperation.Response response = _itemService.Deposit(request);

        return response switch
        {
            DoOperation.Response.Success success => Ok(response),
            DoOperation.Response.Unauthorized failure => Unauthorized(),
            DoOperation.Response.BadRequest failure => BadRequest(failure.Message),

            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("withdraw")]
    public ActionResult<OperationDto> Withdraw([FromBody] OperationRequest httpRequest)
    {
        var request = new DoOperation.Request(httpRequest.Key, httpRequest.Amount);
        DoOperation.Response response = _itemService.WithDraw(request);

        return response switch
        {
            DoOperation.Response.Success success => Ok(response),
            DoOperation.Response.Unauthorized failure => Unauthorized(),
            DoOperation.Response.BadRequest failure => BadRequest(failure.Message),

            _ => throw new UnreachableException(),
        };
    }

    [HttpGet("history")]
    public ActionResult<OperationDto> GetHistory([FromBody] OperationRequest httpRequest)
    {
        var request = new GetHistory.Request(httpRequest.Key);
        GetHistory.Response response = _itemService.OperationHistory(request);

        return response switch
        {
            GetHistory.Response.Success success => Ok(response),
            GetHistory.Response.Unauthorized failure => Unauthorized(),
            GetHistory.Response.BadRequest failure => BadRequest(failure.Message),

            _ => throw new UnreachableException(),
        };
    }
}