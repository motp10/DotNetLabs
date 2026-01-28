using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class MimicFactory : ICreatureFactory
{
    private const int _defaulDamageValue = 1;
    private const int _defaultHealthValue = 1;

    private Damage DefaultDamage() => new Damage(_defaulDamageValue);

    private Health DefaultHealth() => new Health(_defaultHealthValue);

    public MimicFactory()
    {
    }

    public ICreatureBuilder MakeBuilder()
    {
        return new Mimic.Builder()
            .WithHealth(DefaultHealth())
            .WithAttack(DefaultDamage());
    }
}