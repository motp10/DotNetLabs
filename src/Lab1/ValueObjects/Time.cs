namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record class Time
{
    public static Time Create(Time lhs, Time rhs)
    {
        return new Time(lhs.Value + rhs.Value);
    }

    public Time(decimal value)
    {
        Value = value;
    }

    public static Time Zero => new Time(0);

    public decimal Value { get; }
}