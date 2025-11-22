using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class BattleAnalystFactory : ICreatureFactory
{
    public Damage DefaultDammage { get; init; }

    public Health DefaultHealth { get; init; }

    public BattleAnalystFactory()
    {
        DefaultDammage = new Damage(2);
        DefaultHealth = new Health(4);
    }

    public ICreatureBuilder MakeBuilder()
    {
        return new BattleAnalyst.Builder()
            .WithHealth(BattleAnalyst.DefaultHelth())
            .WithAttack(BattleAnalyst.DefaultAttack());
    }
}