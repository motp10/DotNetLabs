namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record class Distance
{
    public Distance(decimal value)
    {
        if (value < 0)
        {
            throw new Exception("distance is under 0");
        }

        Value = value;
    }

    public Distance(Speed speed, Time time)
    {
        Value = speed.Value * time.Value;
    }

    public static Distance Create(Distance lhs, Distance rhs)
    {
        return new Distance(lhs.Value + rhs.Value);
    }

    public static bool operator <(Distance a, Distance b) => a.Value < b.Value;

    public static bool operator >(Distance a, Distance b) => a.Value > b.Value;

    public static Distance Zero => new Distance(0);

    public decimal Value { get; }
}