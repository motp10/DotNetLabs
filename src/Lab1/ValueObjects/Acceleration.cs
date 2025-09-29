namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public record class Acceleration
{
    public Acceleration(decimal value)
    {
        Value = value;
    }

    public Acceleration(Force force, Mass mass)
    {
        Value = force.Value / mass.Value;
    }

    public decimal Value { get; }
}