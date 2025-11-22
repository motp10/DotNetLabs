using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class ViciousBattlerFactory : ICreatureFactory
{
    public Damage DefaultDammage { get; init; }

    public Health DefaultHealth { get; init; }

    public ViciousBattlerFactory()
    {
        DefaultDammage = new Damage(1);
        DefaultHealth = new Health(6);
    }

    public ICreatureBuilder MakeBuilder()
    {
        return new ViciousBattler.Builder()
            .WithHealth(ViciousBattler.DefaultHelth())
            .WithAttack(ViciousBattler.DefaultAttack());
    }
}