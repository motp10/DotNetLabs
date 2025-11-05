namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

public record Health
{
    public int Value { get; }

    public Health(int value)
    {
        Value = value;
    }
}