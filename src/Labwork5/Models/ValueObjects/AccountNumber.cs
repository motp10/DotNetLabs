namespace Models.ValueObjects;

public readonly record struct AccountNumber
{
    public Guid Value { get; }

    public AccountNumber()
    {
        Value = Guid.NewGuid();
    }

    public AccountNumber(Guid value)
    {
        Value = value;
    }
}