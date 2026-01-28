using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class ImmortalFearFactory : ICreatureFactory
{
    private const int _defaulDamageValue = 4;
    private const int _defaultHealthValue = 4;

    private Damage DefaultDamage() => new Damage(_defaulDamageValue);

    private Health DefaultHealth() => new Health(_defaultHealthValue);

    public ImmortalFearFactory() { }

    public ICreatureBuilder MakeBuilder()
    {
        return new ImmortalFear.Builder()
            .WithHealth(DefaultHealth())
            .WithAttack(DefaultDamage());
    }
}