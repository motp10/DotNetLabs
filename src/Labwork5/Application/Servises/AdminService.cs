using Application.Abstraction;
using Application.Contracts.Operations;
using Application.Contracts.ServicesInterfaces;
using Application.Mapping;
using Models;
using Models.Sessions;
using Models.ValueObjects;

namespace Application.Servises;

public class AdminService : IAdminServise
{
    private readonly IPersistenceContext _context;

    public AdminService(IPersistenceContext context)
    {
        _context = context;
    }

    public CreateAccount.Response CreateAccount(CreateAccount.Request request)
    {
        SessionKey key = request.Key;
        Password password = request.Password;

        if (!_context.SessionsRepository.Query(key).Any())
        {
            return new CreateAccount.Response.Unauthorized();
        }
        else if (_context.SessionsRepository.Query(key).First() is UserSession)
        {
            return new CreateAccount.Response.Unauthorized();
        }

        var number = new AccountNumber();

        _context.AccountRepository.Add(number, new BankAccount(number, password));

        return new CreateAccount.Response.Success(AccountMappingExtension.MapToDto(number, password, Money.Null));
    }
}