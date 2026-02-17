using Application.Contracts.Models;
using Models.ValueObjects;

namespace Application.Contracts.Operations;

public record GetHistory
{
    private GetHistory() { }

    public record Request : GetHistory
    {
        public SessionKey Key { get; }

        public Request(Guid password)
        {
            Key = new SessionKey(password);
        }
    }

    public record Response : GetHistory
    {
        public sealed record Success(HistoryDto History) : Response;

        public sealed record BadRequest(string Message) : Response;

        public sealed record Unauthorized() : Response;
    }
}