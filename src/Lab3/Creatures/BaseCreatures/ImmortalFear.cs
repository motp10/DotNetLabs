using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

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

    public ImmortalFear(Damage attack, Health health)
    : base(attack, health)
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

    public class Builder : CreatureBuilder
    {
        public override ICreature Build()
        {
            var currentCreature = new ImmortalFear(Attack, Health);
            foreach (IModificatorFactory modificator in Modificators)
            {
                modificator.ImposeModification(currentCreature);
            }

            return currentCreature;
        }
    }
}