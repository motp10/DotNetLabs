using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public interface ICreatureBuilder
{
    ICreatureBuilder WithHealth(Health health);

    ICreatureBuilder WithAttack(Damage attack);

    ICreatureBuilder AddModificator(IFactory modificator);

    ICreatureBuilder AddModificators(IReadOnlyCollection<IFactory> modificators);

    ICreature Build();
}