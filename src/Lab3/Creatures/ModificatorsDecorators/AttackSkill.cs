using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ModificatorsDecorators;

public class AttackSkill : ICreature
{
    private readonly ICreature _creature;

    public Damage Attack => _creature.Attack;

    public Health Health => _creature.Health;

    public AttackSkill(ICreature creature)
    {
        _creature = creature;
    }

    public virtual bool IsDead()
    {
        return _creature.IsDead();
    }

    public void ReceiveDamage(Damage damage)
    {
        _creature.ReceiveDamage(damage);
    }

    public void CauseDamage(ICreature target)
    {
        _creature.CauseDamage(target);

        if (target.IsDead()) return;

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
        return new AttackSkill(_creature.Clone());
    }
}