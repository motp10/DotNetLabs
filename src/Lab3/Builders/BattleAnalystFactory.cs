using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class BattleAnalystFactory : ICreatureFactory
{
    private const int _defaulDamageValue = 2;
    private const int _defaultHealthValue = 4;

    private Damage DefaultDamage() => new Damage(_defaulDamageValue);

    private Health DefaultHealth() => new Health(_defaultHealthValue);

    public BattleAnalystFactory() { }

    public ICreatureBuilder MakeBuilder()
    {
        return new BattleAnalyst.Builder()
            .WithHealth(DefaultHealth())
            .WithAttack(DefaultDamage());
    }
}