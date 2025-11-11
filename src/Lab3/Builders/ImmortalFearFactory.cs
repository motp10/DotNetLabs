using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class ImmortalFearFactory : ICreatureFactory
{
    public ICreatureBuilder MakeBuilder(Damage? damage = null, Health? health = null)
    {
        return new ImmortalFear.Builder()
            .WithHealth(health ?? ImmortalFear.DefaultHelth())
            .WithAttack(damage ?? ImmortalFear.DefaultAttack());
    }
}