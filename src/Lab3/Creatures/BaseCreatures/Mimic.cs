using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;

public class Mimic : BaseCreature
{
    public static Health DefaultHelth()
    {
        return new Health(1);
    }

    public static Damage DefaultAttack()
    {
        return new Damage(1);
    }

    public Mimic(Damage? attack = null, Health? health = null)
    : base(attack ?? DefaultAttack(), health ?? DefaultHelth())
    {
    }

    public override void CauseDamage(ICreature target)
    {
        int newAttackValue = Math.Max(Attack.Value, target.Attack.Value);
        int newHealthValue = Math.Max(Health.Value, target.Health.Value);
        SetAttack(new Damage(newAttackValue));
        SetHealth(new Health(newHealthValue));

        base.CauseDamage(target);
    }

    public override ICreature Clone()
    {
        return new Mimic(Attack, Health);
    }
}