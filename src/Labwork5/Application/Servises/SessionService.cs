using Application.Abstraction;
using Application.Contracts.Operations;
using Application.Contracts.ServicesInterfaces;
using Application.Mapping;
using Models;
using Models.Sessions;
using Models.ValueObjects;

namespace Application.Servises;

public class SessionService : ISessionService
{
    private readonly IPersistenceContext _context;

    public SessionService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateUserSession.Response CreateUserSession(CreateUserSession.Request request)
    {
        AccountNumber number = request.Number;
        Password password = request.Password;

        if (!_context.AccountRepository.Query(number).Any())
        {
            return new CreateUserSession.Response.Unauthorized();
        }

        BankAccount account = _context.AccountRepository.Query(number).First();
        if (!account.AcceptPassword(password))
        {
            return new CreateUserSession.Response.Unauthorized();
        }

        var key = new SessionKey();

        _context.SessionsRepository.Add(key, new UserSession(key, number));

        return new CreateUserSession.Response.Success(
            SessionMappingExtension.MapToDto(key, SessionType.User));
    }

    public CreateAdminSession.Response CreateAdminSession(CreateAdminSession.Request request)
    {
        Password adminPassword = request.Password;

        if (_context.AdminPassword.Password != adminPassword)
        {
            return new CreateAdminSession.Response.Unauthorized();
        }

        var key = new SessionKey();

        _context.SessionsRepository.Add(key, new AdminSession(key));

        return new CreateAdminSession.Response.Success(SessionMappingExtension.MapToDto(key, SessionType.Admin));
    }
}