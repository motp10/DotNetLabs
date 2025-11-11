using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ModificatorsDecorators;

namespace Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

public class MagicShieldModificatorFactory : IModificatorFactory
{
    public ICreature ImposeModification(ICreature creature)
    {
        creature = new MagicShield(creature);
        return creature;
    }
}