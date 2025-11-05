using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Potions;

public class EnduranceSpell : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        var newHealth = new Health(creature.Health.Value + 5);
        creature.SetHealth(newHealth);
        return creature;
    }
}