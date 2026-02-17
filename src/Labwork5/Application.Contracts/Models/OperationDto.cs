using Models.Operations;
using Models.ValueObjects;

namespace Application.Contracts.Models;

public sealed record OperationDto(OperationType OperationType, DateTime DateTime, AccountNumber AccountNumber, Money Amount);