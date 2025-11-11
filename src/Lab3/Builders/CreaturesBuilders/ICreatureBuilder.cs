using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;

public interface ICreatureBuilder
{
    ICreatureBuilder AddModificator(IModificatorFactory modificator);

    ICreature Build();
}