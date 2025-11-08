using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.SimpleInterfaces;

public interface IHealthBuilder
{
    IDamageBuilder WithHealth(Health health);
}