namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record class Mass
{
    public Mass(decimal value)
    {
        if (value <= 0)
        {
            throw new Exception("mass is under 0");
        }

        this.Value = value;
    }

    public decimal Value { get; }
}