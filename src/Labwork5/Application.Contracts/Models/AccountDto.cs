using Models.ValueObjects;

namespace Application.Contracts.Models;

public sealed record AccountDto(AccountNumber AccountId, Password Password, Money Balance);