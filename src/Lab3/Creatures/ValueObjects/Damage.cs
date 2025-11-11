namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

public readonly record struct Damage
{
    public static Damage Zero => new Damage(0);

    public int Value { get; }

    public Damage(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value, "Value cannot be negative.");
        }

        Value = value;
    }

    public static Damage operator *(Damage lhs, int rhs)
    {
        return new Damage(lhs.Value * rhs);
    }
}