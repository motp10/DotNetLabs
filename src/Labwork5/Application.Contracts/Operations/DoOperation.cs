using Application.Contracts.Models;
using Models.ValueObjects;

namespace Application.Contracts.Operations;

public record DoOperation
{
    private DoOperation() { }

    public record Request : DoOperation
    {
        public SessionKey Key { get; }

        public Money Amount { get; }

        public Request(Guid key, decimal amount)
        {
            Key = new SessionKey(key);
            Amount = new Money(amount);
        }
    }

    public record Response : DoOperation
    {
        public sealed record Success(OperationDto OperationDto) : Response;

        public sealed record BadRequest(string Message) : Response;

        public sealed record Unauthorized() : Response;
    }
}