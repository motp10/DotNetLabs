using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;

public class ViciousBattler : BaseCreature
{
    private ViciousBattler(Damage attack, Health health)
    : base(attack, health)
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

    public class Builder : CreatureBuilder
    {
        public override ICreature Build()
        {
            var currentCreature = new ViciousBattler(Attack, Health);
            foreach (IModificatorFactory modificator in Modificators)
            {
                modificator.ImposeModification(currentCreature);
            }

            return currentCreature;
        }
    }
}