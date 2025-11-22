using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;

public class ImmortalFear : BaseCreature
{
    private bool _wasResurrected;

    public ImmortalFear(Damage attack, Health health, bool wasResurrected = false)
    : base(attack, health)
    {
        _wasResurrected = wasResurrected;
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
        return new ImmortalFear(Attack, Health,  _wasResurrected);
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