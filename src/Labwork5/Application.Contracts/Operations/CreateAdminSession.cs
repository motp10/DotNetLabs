using Application.Contracts.Models;
using Models.ValueObjects;

namespace Application.Contracts.Operations;

public record CreateAdminSession
{
    private CreateAdminSession() { }

    public record Request : CreateAdminSession
    {
        public Password Password { get; }

        public Request(string password)
        {
            Password = new Password(password);
        }
    }

    public record Response : CreateAdminSession
    {
        public sealed record Success(SessionDto SessionDto) : Response;

        public sealed record BadRequest(string Message) : Response;

        public sealed record Unauthorized() : Response;
    }
}