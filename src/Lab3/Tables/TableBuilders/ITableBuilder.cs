using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.TableBuilders;

public interface ITableBuilder
{
    ITableBuilder AddCreature(ICreature creature);

    ITableBuilder AddCreatures(IReadOnlyCollection<ICreature> creatures);

    ITableBuilder ClearCreatures();

    PlayerTable Build();
}
