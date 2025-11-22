using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class MimicFactory : ICreatureFactory
{
    public Damage DefaultDammage { get; init; }

    public Health DefaultHealth { get; init; }

    public MimicFactory()
    {
        DefaultDammage = new Damage(1);
        DefaultHealth = new Health(1);
    }

    public ICreatureBuilder MakeBuilder()
    {
        return new Mimic.Builder()
            .WithHealth(Mimic.DefaultHelth())
            .WithAttack(Mimic.DefaultAttack());
    }
}