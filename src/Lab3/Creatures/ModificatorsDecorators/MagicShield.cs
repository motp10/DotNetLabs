using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ModificatorsDecorators;

public class MagicShield : ICreature
{
    private readonly ICreature _creature;

    private bool _hasShield;

    public Damage Attack => _creature.Attack;

    public Health Health => _creature.Health;

    public MagicShield(ICreature creature, bool hasShield = true)
    {
        _creature = creature;
        _hasShield = true;
    }

    public virtual bool IsDead()
    {
        return _creature.IsDead();
    }

    public void ReceiveDamage(Damage damage)
    {
        if (_hasShield)
        {
            _hasShield = false;
            return;
        }

        _creature.ReceiveDamage(damage);
    }

    public void CauseDamage(ICreature target)
    {
        _creature.CauseDamage(target);
    }

    public void SetAttack(Damage newAttack)
    {
        _creature.SetAttack(newAttack);
    }

    public void SetHealth(Health newHealth)
    {
        _creature.SetHealth(newHealth);
    }

    public ICreature Clone()
    {
        return new MagicShield(_creature.Clone(), _hasShield);
    }
}