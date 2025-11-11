using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class ViciousBattlerFactory : ICreatureFactory
{
    public ICreatureBuilder MakeBuilder(Damage? damage = null, Health? health = null)
    {
        return new ViciousBattler.Builder()
            .WithHealth(health ?? ViciousBattler.DefaultHelth())
            .WithAttack(damage ?? ViciousBattler.DefaultAttack());
    }
}