using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;

public interface ICreatureBuilder : IHealthBuilder, IDamageBuilder
{
    ICreatureBuilder AddModificator(IModificatorFactory modificator);

    ICreature Build();
}

public interface IHealthBuilder
{
    IDamageBuilder WithHealth(Health health);
}

public interface IDamageBuilder
{
    ICreatureBuilder WithAttack(Damage attack);
}