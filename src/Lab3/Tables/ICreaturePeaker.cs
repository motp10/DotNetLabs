using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public interface ICreaturePeaker
{
    ICreature? GiveRandomAttackCreature(IReadOnlyList<ICreature> creaturesList);

    ICreature? GiveRandomDeffenceCreature(IReadOnlyList<ICreature> creaturesList);
}