using Models.ValueObjects;

namespace Models;

public class BankAccount
{
    public AccountNumber Number { get; }

    private readonly Password _password;

    public Money Balance { get; private set; } = Money.Null;

    public BankAccount(AccountNumber number, Password password)
    {
        Number = number;
        _password = password;
    }

    public bool AcceptPassword(Password password)
    {
        return _password == password;
    }

    public bool Deposit(Money amount)
    {
        Balance += amount;
        return true;
    }

    public bool WithDraw(Money amount)
    {
        if (amount.Value > Balance.Value)
        {
            return false;
        }

        Balance -= amount;
        return true;
    }
}