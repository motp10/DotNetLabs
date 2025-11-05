using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;

public class ImmortalFear : BaseCreature
{
    private bool _wasResurrected;

    public static Health DefaultHelth()
    {
        return new Health(4);
    }

    public static Damage DefaultAttack()
    {
        return new Damage(4);
    }

    public ImmortalFear(Damage? attack = null, Health? health = null)
    : base(attack ?? DefaultAttack(), health ?? DefaultHelth())
    {
        _wasResurrected = false;
    }

    public override void ReceiveDamage(Damage damage)
    {
        base.ReceiveDamage(damage);

        if (IsDead() && !_wasResurrected)
        {
            _wasResurrected = true;
            Health = new Health(1);
        }
    }

    public override ICreature Clone()
    {
        return new ImmortalFear(Attack, Health);
    }
}