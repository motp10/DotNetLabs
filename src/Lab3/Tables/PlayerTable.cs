using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Potions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class PlayerTable
{
    private readonly List<ICreature> _creatureList;

    private readonly ICreaturePeaker _peaker = new CreaturePeaker();

    public void ApplySpell(ISpell spell, int creatureIndex)
    {
        if (creatureIndex < _creatureList.Count)
        {
            _creatureList[creatureIndex] = spell.Apply(_creatureList[creatureIndex]);
        }
    }

    public PlayerTable(ICreaturePeaker? peaker = null)
    {
        _peaker = peaker ?? new CreaturePeaker();
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