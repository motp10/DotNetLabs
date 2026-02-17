namespace Models.ValueObjects;

public readonly record struct Money
{
    public static Money Null => new Money(0);

    public decimal Value { get; }

    public Money(decimal value)
    {
        if (value < 0) throw new Exception("Amount cannot be negative");
        Value = value;
    }

    public static Money operator +(Money left, Money right) => new(left.Value + right.Value);

    public static Money operator -(Money left, Money right) => new(left.Value - right.Value);
}