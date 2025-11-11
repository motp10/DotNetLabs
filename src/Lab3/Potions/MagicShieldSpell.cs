using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Potions;

public class MagicShieldSpell : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        var shieldFactory = new MagicShieldModificatorFactory();
        return shieldFactory.ImposeModification(creature);
    }
}