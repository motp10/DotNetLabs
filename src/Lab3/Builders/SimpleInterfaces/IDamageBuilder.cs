using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.SimpleInterfaces;

public interface IDamageBuilder
{
    ICreatureBuilder WithAttack(Damage attack);
}