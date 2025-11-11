using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class BattleAnalystFactory : ICreatureFactory
{
    public ICreatureBuilder MakeBuilder(Damage? damage = null, Health? health = null)
    {
        return new BattleAnalyst.Builder()
            .WithHealth(health ?? BattleAnalyst.DefaultHelth())
            .WithAttack(damage ?? BattleAnalyst.DefaultAttack());
    }
}