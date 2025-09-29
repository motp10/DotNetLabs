namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record class Force
{
    public Force(decimal value)
    {
        Value = value;
    }

    public static bool operator <(Force a, Force b) => a.Value < b.Value;

    public static bool operator >(Force a, Force b) => a.Value > b.Value;

    public decimal Value { get; }
}