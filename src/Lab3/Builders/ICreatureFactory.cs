using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public interface ICreatureFactory
{
    ICreatureBuilder MakeBuilder();
}