using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.TableBuilders;

public class TableBuilder : ITableBuilder
{
    private const int MaxCreatureCount = 7;

    private readonly List<ICreature> _creatureList = new List<ICreature>();

    public ITableBuilder AddCreature(ICreature creature)
    {
        if (_creatureList.Count == MaxCreatureCount)
        {
            throw new Exception("Too many new creatures");
        }

        _creatureList.Add(creature);

        return this;
    }

    public ITableBuilder AddCreatures(IReadOnlyCollection<ICreature> creatures)
    {
        if ((_creatureList.Count + creatures.Count) > MaxCreatureCount)
        {
            throw new Exception("Too many new creatures");
        }

        foreach (ICreature creature in creatures)
        {
            _creatureList.Add(creature);
        }

        return this;
    }

    public ITableBuilder ClearCreatures()
    {
        _creatureList.Clear();
        return this;
    }

    public PlayerTable Build()
    {
        return new PlayerTable(_creatureList);
    }
}