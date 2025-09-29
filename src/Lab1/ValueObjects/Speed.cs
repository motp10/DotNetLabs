namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record class Speed
{
    public Speed(decimal value)
    {
        if (value < 0)
        {
            throw new Exception("Speed cannot be negative");
        }

        Value = value;
    }

    public Speed(Speed speed, Acceleration acceleration, Time duration)
    {
        Value = speed.Value + (acceleration.Value * duration.Value);
    }

    public static bool operator <(Speed a, Speed b) => a.Value < b.Value;

    public static bool operator >(Speed a, Speed b) => a.Value > b.Value;

    public decimal Value { get; }
}