using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;

public abstract class BaseCreature : ICreature
{
    public Health Health { get; protected set; }

    public Damage Attack { get; protected set; }

    protected BaseCreature(Damage damage, Health health)
    {
        Health = health;
        Attack = damage;
    }

    public bool IsDead()
    {
        return Health.Value <= 0;
    }

    public virtual void CauseDamage(ICreature target)
    {
        if (IsDead()) return;
        target.ReceiveDamage(Attack);
    }

    public virtual void ReceiveDamage(Damage damage)
    {
        if (IsDead()) return;
        Health = new Health(Math.Max(Health.Value - damage.Value, 0));
    }

    public void SetHealth(Health newHealth)
    {
        Health = newHealth;
    }

    public void SetAttack(Damage newAttack)
    {
        Attack = newAttack;
    }

    public abstract ICreature Clone();
}