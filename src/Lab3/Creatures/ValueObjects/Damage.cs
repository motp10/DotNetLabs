namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

public readonly record struct Damage
{
    public static Damage Zero => new Damage(0);

    public int Value { get; }

    public Damage(int value)
    {
        if (value < 0)
        {
            value = 0;
        }

        Value = value;
    }

    public static Damage operator *(Damage lhs, int rhs)
    {
        return new Damage(lhs.Value * rhs);
    }
}