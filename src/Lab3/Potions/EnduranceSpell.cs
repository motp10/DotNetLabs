using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Potions;

public class EnduranceSpell : ISpell
{
    private const int IncreceHealthValue = 5;

    public ICreature Apply(ICreature currentCreature)
    {
        ICreature creature = currentCreature.Clone();
        var newHealth = new Health(creature.Health.Value + IncreceHealthValue);
        creature.SetHealth(newHealth);
        return creature;
    }
}