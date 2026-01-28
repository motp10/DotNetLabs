using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

public interface IModificatorFactory
{
    ICreature ImposeModification(ICreature creature);
}