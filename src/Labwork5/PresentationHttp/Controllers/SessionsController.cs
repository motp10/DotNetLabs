using Application.Contracts.Models;
using Application.Contracts.Operations;
using Application.Contracts.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using PresentationHttp.Models;
using System.Diagnostics;

namespace PresentationHttp.Controllers;

[ApiController]
[Route("/api/sessions")]
public class SessionsController : ControllerBase
{
    private readonly ISessionService _itemService;

    public SessionsController(ISessionService itemService)
    {
        _itemService = itemService;
    }

    [HttpPost("user")]
    public ActionResult<SessionDto> CreateUserSession([FromBody] CreateUserSessionRequest httpRequest)
    {
        var request = new CreateUserSession.Request(httpRequest.Password ?? string.Empty, httpRequest.Number);
        CreateUserSession.Response response = _itemService.CreateUserSession(request);

        return response switch
        {
            CreateUserSession.Response.Success success => Ok(response),
            CreateUserSession.Response.Unauthorized failure => Unauthorized(),
            CreateUserSession.Response.BadRequest failure => BadRequest(failure.Message),

            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("admin")]
    public ActionResult<SessionDto> CreateAdminSession([FromBody] CreateAdminSessionRequest httpRequest)
    {
        var request = new CreateAdminSession.Request(httpRequest.Password ?? string.Empty);
        CreateAdminSession.Response response = _itemService.CreateAdminSession(request);

        return response switch
        {
            CreateAdminSession.Response.Success success => Ok(response),
            CreateAdminSession.Response.BadRequest failure => BadRequest(failure.Message),
            CreateAdminSession.Response.Unauthorized failure => BadRequest(),
            _ => throw new UnreachableException(),
        };
    }
}