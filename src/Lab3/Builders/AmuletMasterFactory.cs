using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class AmuletMasterFactory : ICreatureFactory
{
    public Damage DefaultDammage { get; init; }

    public Health DefaultHealth { get; init; }

    public AmuletMasterFactory()
    {
        DefaultDammage = new Damage(5);
        DefaultHealth = new Health(2);
    }

    public ICreatureBuilder MakeBuilder()
    {
        return new AmuletMaster.Builder()
                   .WithHealth(AmuletMaster.DefaultHelth())
                   .WithAttack(AmuletMaster.DefaultAttack())
                   .AddModificator(new AttackSkillModificatorFactory())
                   .AddModificator(new MagicShieldModificatorFactory());
    }
}