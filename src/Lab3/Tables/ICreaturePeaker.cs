using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public interface ICreaturePeaker
{
    ICreature? GiveRandomCreature(IReadOnlyList<ICreature> creaturesList);
}