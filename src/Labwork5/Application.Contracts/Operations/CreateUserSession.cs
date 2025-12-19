using Application.Contracts.Models;
using Models.ValueObjects;

namespace Application.Contracts.Operations;

public record CreateUserSession
{
    private CreateUserSession() { }

    public record Request : CreateUserSession
    {
        public Password Password { get; }

        public AccountNumber Number { get; }

        public Request(string password, Guid number)
        {
            Password = new Password(password);
            Number = new AccountNumber(number);
        }
    }

    public record Response : CreateUserSession
    {
        public sealed record Success(SessionDto SessionDto) : Response;

        public sealed record BadRequest(string Message) : Response;

        public sealed record Unauthorized() : Response;
    }
}