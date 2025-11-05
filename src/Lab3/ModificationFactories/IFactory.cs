using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

public interface IFactory
{
    ICreature ImposeModification(ICreature creature);
}