using Models;
using Models.ValueObjects;

namespace Application.Abstraction.Repositories;

public interface IAccountRepository
{
    void Add(AccountNumber number, BankAccount account);

    IEnumerable<BankAccount> Query(AccountNumber number);

    IEnumerable<AccountNumber> FindSmth();
}