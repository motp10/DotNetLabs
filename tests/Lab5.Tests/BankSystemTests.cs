using Application.Abstraction;
using Application.Abstraction.Repositories;
using Application.Contracts.Operations;
using Application.Servises;
using Models;
using Models.Operations;
using Models.Sessions;
using Models.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankSystemTests
{
    [Fact]
    public void Deposit()
    {
        // Arrange
        var adminPassword = new Password("admin");
        var accountPassword = new Password("password");
        var accountNumber = new AccountNumber(Guid.NewGuid());
        var account = new BankAccount(accountNumber, accountPassword);
        var sessionKey = new SessionKey(Guid.NewGuid());

        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        accountRepository
            .Query(accountNumber)
            .Returns(new[] { account });

        IAdminPasswordRepository adminPasswordRepository = Substitute.For<IAdminPasswordRepository>();
        adminPasswordRepository.Password.Returns(adminPassword);

        IHistoryRepository historyRepository = Substitute.For<IHistoryRepository>();

        ISessionsRepository sessionsRepository = Substitute.For<ISessionsRepository>();
        ISession session = new UserSession(sessionKey, accountNumber);
        sessionsRepository
            .Query(sessionKey)
            .Returns(new[] { session });

        IPersistenceContext context = Substitute.For<IPersistenceContext>();
        context.AccountRepository.Returns(accountRepository);
        context.AdminPassword.Returns(adminPasswordRepository);
        context.HistoryRepository.Returns(historyRepository);
        context.SessionsRepository.Returns(sessionsRepository);

        var userService = new UserService(context);

        var request = new DoOperation.Request(sessionKey.Value, 1000);

        // Act
        DoOperation.Response response = userService.Deposit(request);

        // Assert
        Assert.IsType<DoOperation.Response.Success>(response);

        Assert.Equal(new Money(1000), account.Balance);

        historyRepository.Received(1).Add(
            accountNumber,
            Arg.Is<Operation>(op =>
                op.Type == OperationType.Deposit &&
                op.AccountNumber == accountNumber &&
                op.Amount == new Money(1000)));
    }

    [Fact]
    public void CorrectWithDraw()
    {
        // Arrange
        var adminPassword = new Password("admin");
        var accountPassword = new Password("password");
        var accountNumber = new AccountNumber(Guid.NewGuid());
        var account = new BankAccount(accountNumber, accountPassword);
        var sessionKey = new SessionKey(Guid.NewGuid());

        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        accountRepository
            .Query(accountNumber)
            .Returns(new[] { account });

        IAdminPasswordRepository adminPasswordRepository = Substitute.For<IAdminPasswordRepository>();
        adminPasswordRepository.Password.Returns(adminPassword);

        IHistoryRepository historyRepository = Substitute.For<IHistoryRepository>();

        ISessionsRepository sessionsRepository = Substitute.For<ISessionsRepository>();
        ISession session = new UserSession(sessionKey, accountNumber);
        sessionsRepository
            .Query(sessionKey)
            .Returns(new[] { session });

        IPersistenceContext context = Substitute.For<IPersistenceContext>();
        context.AccountRepository.Returns(accountRepository);
        context.AdminPassword.Returns(adminPasswordRepository);
        context.HistoryRepository.Returns(historyRepository);
        context.SessionsRepository.Returns(sessionsRepository);

        var userService = new UserService(context);

        var request = new DoOperation.Request(sessionKey.Value, 1000);
        var withdrawRequest = new DoOperation.Request(sessionKey.Value, 1000);

        // Act
        userService.Deposit(request);
        DoOperation.Response response = userService.WithDraw(withdrawRequest);

        // Assert
        Assert.IsType<DoOperation.Response.Success>(response);

        Assert.Equal(new Money(0), account.Balance);

        historyRepository.Received(1).Add(
            accountNumber,
            Arg.Is<Operation>(op =>
                op.Type == OperationType.WithDraw &&
                op.AccountNumber == accountNumber &&
                op.Amount == new Money(1000)));
    }

    [Fact]
    public void NotEnughMoneyWithdraw()
    {
        // Arrange
        var adminPassword = new Password("admin");
        var accountPassword = new Password("password");
        var accountNumber = new AccountNumber(Guid.NewGuid());
        var account = new BankAccount(accountNumber, accountPassword);
        var sessionKey = new SessionKey(Guid.NewGuid());

        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        accountRepository
            .Query(accountNumber)
            .Returns(new[] { account });

        IAdminPasswordRepository adminPasswordRepository = Substitute.For<IAdminPasswordRepository>();
        adminPasswordRepository.Password.Returns(adminPassword);

        IHistoryRepository historyRepository = Substitute.For<IHistoryRepository>();

        ISessionsRepository sessionsRepository = Substitute.For<ISessionsRepository>();
        ISession session = new UserSession(sessionKey, accountNumber);
        sessionsRepository
            .Query(sessionKey)
            .Returns(new[] { session });

        IPersistenceContext context = Substitute.For<IPersistenceContext>();
        context.AccountRepository.Returns(accountRepository);
        context.AdminPassword.Returns(adminPasswordRepository);
        context.HistoryRepository.Returns(historyRepository);
        context.SessionsRepository.Returns(sessionsRepository);

        var userService = new UserService(context);

        var request = new DoOperation.Request(sessionKey.Value, 1000);
        var withdrawRequest = new DoOperation.Request(sessionKey.Value, 1001);

        // Act
        userService.Deposit(request);
        DoOperation.Response response = userService.WithDraw(withdrawRequest);

        // Assert
        Assert.IsType<DoOperation.Response.BadRequest>(response);
    }
}