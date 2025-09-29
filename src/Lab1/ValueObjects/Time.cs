namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record class Time
{
    public Time(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; }
}