using Application.Contracts.Models;
using Models.ValueObjects;

namespace Application.Contracts.Operations;

public record CreateAccount
{
    private CreateAccount() { }

    public readonly record struct Request
    {
        public SessionKey Key { get; }

        public Password Password { get; }

        public Request(Guid key, string password)
        {
            Key = new SessionKey(key);
            Password = new Password(password);
        }
    }

    public record Response
    {
        private Response() { }

        public sealed record Success(AccountDto AccountDto) : Response;

        public sealed record BadRequest(string Message) : Response;

        public sealed record Unauthorized() : Response;
    }
}