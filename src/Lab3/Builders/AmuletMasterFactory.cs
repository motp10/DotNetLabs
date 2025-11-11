using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class AmuletMasterFactory : ICreatureFactory
{
    public ICreatureBuilder MakeBuilder(Damage? damage = null, Health? health = null)
    {
        return new AmuletMaster.Builder()
                   .WithHealth(health ?? AmuletMaster.DefaultHelth())
                   .WithAttack(damage ?? AmuletMaster.DefaultAttack())
                   .AddModificator(new AttackSkillModificatorFactory())
                   .AddModificator(new MagicShieldModificatorFactory());
    }
}