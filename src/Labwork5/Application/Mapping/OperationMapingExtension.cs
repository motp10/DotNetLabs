using Application.Contracts.Models;
using Models.Operations;
using Models.ValueObjects;

namespace Application.Mapping;

public class OperationMapingExtension
{
    public static OperationDto MapToDto(OperationType operationType, DateTime date, AccountNumber number, Money balance)
    {
        return new OperationDto(operationType, date, number, balance);
    }

    public static OperationDto MapToDto(Operation operation)
    {
        return new OperationDto(operation.Type, operation.DateTime, operation.AccountNumber, operation.Amount);
    }
}