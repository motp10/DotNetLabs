using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;

public class BattleAnalyst : BaseCreature
{
    public static Health DefaultHelth()
    {
        return new Health(4);
    }

    public static Damage DefaultAttack()
    {
        return new Damage(2);
    }

    private bool _isBoosted;

    public BattleAnalyst(Damage? attack = null, Health? health = null, bool boost = false)
    : base(attack ?? DefaultAttack(), health ?? DefaultHelth())
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
}