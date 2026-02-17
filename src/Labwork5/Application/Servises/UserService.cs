using Application.Abstraction;
using Application.Contracts.Models;
using Application.Contracts.Operations;
using Application.Contracts.ServicesInterfaces;
using Application.Mapping;
using Models;
using Models.Operations;
using Models.Sessions;
using Models.ValueObjects;

namespace Application.Servises;

public class UserService : IUserServise
{
    private readonly IPersistenceContext _context;

    public UserService(IPersistenceContext context)
    {
        _context = context;
    }

    public DoOperation.Response GetBalance(DoOperation.Request request)
    {
        SessionKey sessionKey = request.Key;
        if (!_context.SessionsRepository.Query(sessionKey).Any())
        {
            return new DoOperation.Response.Unauthorized();
        }

        ISession session = _context.SessionsRepository.Query(sessionKey).First();

        AccountNumber accountNumber;

        if (session is not UserSession userSession)
        {
            return new DoOperation.Response.Unauthorized();
        }

        accountNumber = userSession.AccountNumber;

        BankAccount bankAccount = _context.AccountRepository.Query(accountNumber).First();

        DateTime now = DateTime.Now;

        var operation = new Operation(OperationType.CheckBalance, now, accountNumber, bankAccount.Balance);

        _context.HistoryRepository.Add(accountNumber, operation);

        return new DoOperation.Response.Success(OperationMapingExtension.MapToDto(operation));
    }

    public DoOperation.Response Deposit(DoOperation.Request request)
    {
        SessionKey sessionKey = request.Key;
        if (!_context.SessionsRepository.Query(sessionKey).Any())
        {
            return new DoOperation.Response.Unauthorized();
        }

        ISession session = _context.SessionsRepository.Query(sessionKey).First();

        AccountNumber accountNumber;

        if (session is not UserSession userSession)
        {
            return new DoOperation.Response.Unauthorized();
        }

        accountNumber = userSession.AccountNumber;

        BankAccount bankAccount = _context.AccountRepository.Query(accountNumber).First();

        bankAccount.Deposit(request.Amount);

        DateTime now = DateTime.Now;

        var operation = new Operation(OperationType.Deposit, now, accountNumber, request.Amount);

        _context.HistoryRepository.Add(accountNumber, operation);

        return new DoOperation.Response.Success(OperationMapingExtension.MapToDto(operation));
    }

    public DoOperation.Response WithDraw(DoOperation.Request request)
    {
        SessionKey sessionKey = request.Key;
        Money amount = request.Amount;

        if (!_context.SessionsRepository.Query(sessionKey).Any())
        {
            return new DoOperation.Response.Unauthorized();
        }

        ISession session = _context.SessionsRepository.Query(sessionKey).First();

        AccountNumber accountNumber;

        if (session is not UserSession userSession)
        {
            return new DoOperation.Response.Unauthorized();
        }

        accountNumber = userSession.AccountNumber;

        BankAccount bankAccount = _context.AccountRepository.Query(accountNumber).First();

        bool operationResult = bankAccount.WithDraw(amount);

        if (!operationResult)
        {
            return new DoOperation.Response.BadRequest("not enough money on balance");
        }

        DateTime now = DateTime.Now;

        var operation = new Operation(OperationType.WithDraw, now, accountNumber, amount);

        _context.HistoryRepository.Add(accountNumber, operation);

        return new DoOperation.Response.Success(OperationMapingExtension.MapToDto(operation));
    }

    public GetHistory.Response OperationHistory(GetHistory.Request request)
    {
        SessionKey sessionKey = request.Key;
        if (!_context.SessionsRepository.Query(sessionKey).Any())
        {
            return new GetHistory.Response.Unauthorized();
        }

        ISession session = _context.SessionsRepository.Query(sessionKey).First();

        AccountNumber accountNumber;

        if (session is not UserSession userSession)
        {
            return new GetHistory.Response.Unauthorized();
        }

        accountNumber = userSession.AccountNumber;

        IEnumerable<OperationDto> history = _context.HistoryRepository.QueryByAccountNumber(accountNumber)
                                                                      .Select(x => OperationMapingExtension.MapToDto(x));

        return new GetHistory.Response.Success(HistoryMappingExtension.MapToDto(history));
    }
}