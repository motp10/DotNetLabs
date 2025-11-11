using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class MimicFactory : ICreatureFactory
{
    public ICreatureBuilder MakeBuilder(Damage? damage = null, Health? health = null)
    {
        return new Mimic.Builder()
            .WithHealth(health ?? Mimic.DefaultHelth())
            .WithAttack(damage ?? Mimic.DefaultAttack());
    }
}