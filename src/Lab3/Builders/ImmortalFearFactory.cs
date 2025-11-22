using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class ImmortalFearFactory : ICreatureFactory
{
    public Damage DefaultDammage { get; init; }

    public Health DefaultHealth { get; init; }

    public ImmortalFearFactory()
    {
        DefaultDammage = new Damage(4);
        DefaultHealth = new Health(4);
    }

    public ICreatureBuilder MakeBuilder()
    {
        return new ImmortalFear.Builder()
            .WithHealth(ImmortalFear.DefaultHelth())
            .WithAttack(ImmortalFear.DefaultAttack());
    }
}