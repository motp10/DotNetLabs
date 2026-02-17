using Application.Abstraction.Repositories;
using Models;
using Models.ValueObjects;

namespace Infrastracture.Persistence.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly Dictionary<AccountNumber, BankAccount> _values = [];

    public void Add(AccountNumber number, BankAccount account)
    {
        _values.Add(number, account);
    }

    public IEnumerable<BankAccount> Query(AccountNumber number)
    {
        return _values.Values;
    }

    public IEnumerable<AccountNumber> FindSmth()
    {
        return _values.Keys;
    }
}