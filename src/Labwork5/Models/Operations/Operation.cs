using Models.ValueObjects;

namespace Models.Operations;

public class Operation
{
    public OperationId ID { get; }

    public OperationType Type { get; }

    public DateTime DateTime { get; }

    public AccountNumber AccountNumber { get; }

    public Money Amount { get; }

    public Operation(OperationType type, DateTime dateTime, AccountNumber accountNumber, Money amount)
    {
        Type = type;
        DateTime = dateTime;
        AccountNumber = accountNumber;
        Amount = amount;
    }
}