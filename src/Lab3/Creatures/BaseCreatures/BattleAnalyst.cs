using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;

public class BattleAnalyst : BaseCreature
{
    private bool _isBoosted;

    private BattleAnalyst(Damage attack, Health health, bool boost = false)
    : base(attack, health)
    {
        _isBoosted = boost;
    }

    public override void CauseDamage(ICreature target)
    {
        if (!_isBoosted)
        {
            var newAttack = new Damage(Attack.Value + 2);
            SetAttack(newAttack);
            _isBoosted = true;
        }

        base.CauseDamage(target);
    }

    public override ICreature Clone()
    {
        return new BattleAnalyst(Attack, Health, _isBoosted);
    }

    public class Builder : CreatureBuilder
    {
        public override ICreature Build()
        {
            var currentCreature = new BattleAnalyst(Attack, Health);
            foreach (IModificatorFactory modificator in Modificators)
            {
                modificator.ImposeModification(currentCreature);
            }

            return currentCreature;
        }
    }
}