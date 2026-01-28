using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;

public class Mimic : BaseCreature
{
    private Mimic(Damage attack, Health health)
    : base(attack, health)
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

    public class Builder : CreatureBuilder
    {
        public override ICreature Build()
        {
            var currentCreature = new Mimic(Attack, Health);
            foreach (IModificatorFactory modificator in Modificators)
            {
                modificator.ImposeModification(currentCreature);
            }

            return currentCreature;
        }
    }
}