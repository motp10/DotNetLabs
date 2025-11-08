using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class CreaturesMaker
{
    public ICreatureBuilder MakeAmuletMaster()
    {
        return new AmuletMasterBuilder();
    }

    public ICreatureBuilder MakeBattleAnalyst()
    {
        return new BattleAnalystBuilder();
    }

    public ICreatureBuilder MakeImmortalFear()
    {
        return new ImmortalFearBuilder();
    }

    public ICreatureBuilder MakeMimic()
    {
        return new Mimic.MimicBuilder().WithHealth(Mimic.DefaultHelth()).WithAttack(Mimic.DefaultAttack());
    }

    public ICreatureBuilder MakeViciousBattler()
    {
        return new ViciousBattlerBuilder();
    }
}