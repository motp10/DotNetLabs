using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class PlayerTable
{
    private const int MaxCreatureCount = 7;

    private readonly List<ICreature> _creatureList;

    public PlayerTable()
    {
        _creatureList = new List<ICreature>();
    }

    public PlayerTable(IReadOnlyCollection<ICreature> creatures)
    {
        if (creatures.Count > MaxCreatureCount)
        {
            throw new Exception($"creatures must be not more than {MaxCreatureCount}");
        }

        _creatureList = creatures.ToList();
    }

    public bool TryAddNewCreature(ICreature creature)
    {
        if (_creatureList.Count >= MaxCreatureCount)
        {
            return false;
        }

        _creatureList.Add(creature);
        return true;
    }

    public PlayerTable Clone()
    {
        var copiedCreatures = _creatureList.Select(creature => creature.Clone()).ToList();
        return new PlayerTable(copiedCreatures);
    }

    public ICreature? GiveRandomAttackCreature()
    {
        var ableToAttackCreatures = _creatureList.Where(c => !c.IsDead() && c.Attack != Damage.Zero).ToList();
        if (ableToAttackCreatures.Count == 0)
        {
            return null;
        }

        int index = RandomNumberGenerator.GetInt32(ableToAttackCreatures.Count);
        return ableToAttackCreatures[index];
    }

    public ICreature? GiveRandomDeffenceCreature()
    {
        var aliveCreatures = _creatureList.Where(c => !c.IsDead()).ToList();
        if (aliveCreatures.Count == 0)
        {
            return null;
        }

        int index = RandomNumberGenerator.GetInt32(aliveCreatures.Count);
        return aliveCreatures[index];
    }
}