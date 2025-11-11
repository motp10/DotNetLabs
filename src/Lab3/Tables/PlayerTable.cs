using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class PlayerTable
{
    private readonly List<ICreature> _creatureList;

    private readonly CreaturePeaker _peaker = new CreaturePeaker();

    public PlayerTable()
    {
        _creatureList = new List<ICreature>();
    }

    public PlayerTable(IReadOnlyCollection<ICreature> creatures)
    {
        _creatureList = creatures.ToList();
    }

    public PlayerTable Clone()
    {
        var copiedCreatures = _creatureList.Select(creature => creature.Clone()).ToList();
        return new PlayerTable(copiedCreatures);
    }

    public ICreature? GiveRandomAttackCreature()
    {
        return _peaker.GiveRandomAttackCreature(_creatureList);
    }

    public ICreature? GiveRandomDeffenceCreature()
    {
        return _peaker.GiveRandomDeffenceCreature(_creatureList);
    }
}