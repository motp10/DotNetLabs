using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class CreaturePeaker : ICreaturePeaker
{
    public ICreature? GiveRandomAttackCreature(IReadOnlyList<ICreature> creaturesList)
    {
        var ableToAttackCreatures = creaturesList.Where(c => !c.IsDead() && c.Attack != Damage.Zero).ToList();
        if (ableToAttackCreatures.Count == 0)
        {
            return null;
        }

        int index = RandomNumberGenerator.GetInt32(ableToAttackCreatures.Count);
        return ableToAttackCreatures[index];
    }

    public ICreature? GiveRandomDeffenceCreature(IReadOnlyList<ICreature> creaturesList)
    {
        var aliveCreatures = creaturesList.Where(c => !c.IsDead()).ToList();
        if (aliveCreatures.Count == 0)
        {
            return null;
        }

        int index = RandomNumberGenerator.GetInt32(aliveCreatures.Count);
        return aliveCreatures[index];
    }
}