using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Potions;

public class PowerSpell : ISpell
{
    public ICreature Apply(ICreature currentCreature)
    {
        ICreature creature = currentCreature.Clone();
        var newAttack = new Damage(creature.Attack.Value + 5);
        creature.SetAttack(newAttack);
        return creature;
    }
}