using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.Potions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class PlayerTable
{
    private readonly List<ICreature> _creatureList;

    private readonly ICreaturePeaker _peaker;

    public void ApplySpell(ISpell spell, int creatureIndex)
    {
        if (creatureIndex < _creatureList.Count)
        {
            _creatureList[creatureIndex] = spell.Apply(_creatureList[creatureIndex]);
        }
    }

    public PlayerTable(IReadOnlyCollection<ICreature> creatures, ICreaturePeaker peaker)
    {
        _creatureList = creatures.ToList();
        _peaker = peaker;
    }

    public PlayerTable Clone()
    {
        var copiedCreatures = _creatureList.Select(creature => creature.Clone()).ToList();
        return new PlayerTable(copiedCreatures, _peaker);
    }

    public ICreature? GiveRandomAttackCreature()
    {
        var ableToAttackCreatures = _creatureList.Where(c => !c.IsDead() && c.Attack != Damage.Zero).ToList();
        if (ableToAttackCreatures.Count == 0)
        {
            return null;
        }

        return _peaker.GiveRandomCreature(ableToAttackCreatures);
    }

    public ICreature? GiveRandomDeffenceCreature()
    {
        var aliveCreatures = _creatureList.Where(c => !c.IsDead()).ToList();
        if (aliveCreatures.Count == 0)
        {
            return null;
        }

        return _peaker.GiveRandomCreature(aliveCreatures);
    }
}