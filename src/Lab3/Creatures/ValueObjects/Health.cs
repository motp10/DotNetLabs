namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

public readonly record struct Health
{
    public int Value { get; }

    public Health(int value)
    {
        Value = value;
    }
}