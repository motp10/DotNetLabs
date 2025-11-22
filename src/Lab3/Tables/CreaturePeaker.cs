using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class CreaturePeaker : ICreaturePeaker
{
    public ICreature? GiveRandomCreature(IReadOnlyList<ICreature> creaturesList)
    {
        int index = RandomNumberGenerator.GetInt32(creaturesList.Count);
        return creaturesList[index];
    }
}