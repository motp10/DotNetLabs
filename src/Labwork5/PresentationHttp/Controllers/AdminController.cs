using Application.Contracts.Models;
using Application.Contracts.Operations;
using Application.Contracts.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using PresentationHttp.Models;
using System.Diagnostics;

namespace PresentationHttp.Controllers;

[ApiController]
[Route("/api/create")]
public sealed class AdminController : ControllerBase
{
    private readonly IAdminServise _itemService;

    public AdminController(IAdminServise itemService)
    {
        _itemService = itemService;
    }

    [HttpPost("account")]
    public ActionResult<AccountDto> CreateAccount([FromBody] CreateAccountRequest httpRequest)
    {
        var request = new CreateAccount.Request(httpRequest.Key, httpRequest.Password ?? string.Empty);
        CreateAccount.Response response = _itemService.CreateAccount(request);

        return response switch
        {
            CreateAccount.Response.Success success => Ok(response),
            CreateAccount.Response.BadRequest failure => BadRequest(failure.Message),
            CreateAccount.Response.Unauthorized failure => BadRequest(),
            _ => throw new UnreachableException(),
        };
    }
}