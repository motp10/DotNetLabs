using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreature
{
    Health Health { get; }

    Damage Attack { get; }

    bool IsDead();

    void CauseDamage(ICreature target);

    void ReceiveDamage(Damage damage);

    void SetHealth(Health newHealth);

    void SetAttack(Damage newAttack);

    ICreature Clone();
}