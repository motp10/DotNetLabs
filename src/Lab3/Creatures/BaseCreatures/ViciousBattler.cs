using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;

public class ViciousBattler : BaseCreature
{
    public static Health DefaultHelth()
    {
        return new Health(6);
    }

    public static Damage DefaultAttack()
    {
        return new Damage(1);
    }

    public ViciousBattler(Damage? attack = null, Health? health = null)
    : base(attack ?? DefaultAttack(),  health ?? DefaultHelth())
    {
    }

    public override void ReceiveDamage(Damage damage)
    {
        base.ReceiveDamage(damage);

        if (!IsDead()) SetAttack(Attack * 2);
    }

    public override ICreature Clone()
    {
        return new ViciousBattler(Attack, Health);
    }
}