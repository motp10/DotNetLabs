using Application.Contracts.Models;
using Models.ValueObjects;

namespace Application.Mapping;

public class AccountMappingExtension
{
    public static AccountDto MapToDto(AccountNumber number, Password password, Money balance)
    {
        return new AccountDto(number, password, balance);
    }
}