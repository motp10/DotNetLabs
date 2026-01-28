namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

public readonly record struct Health
{
    public int Value { get; }

    public Health(int value)
    {
        if (value < 0)
        {
            throw new Exception("Health value cannot be negative");
        }

        Value = value;
    }
}