using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class AmuletMasterFactory : ICreatureFactory
{
    private const int _defaulDamageValue = 5;
    private const int _defaultHealthValue = 2;

    private Damage DefaultDamage() => new Damage(_defaulDamageValue);

    private Health DefaultHealth() => new Health(_defaultHealthValue);

    public AmuletMasterFactory() { }

    public ICreatureBuilder MakeBuilder()
    {
        return new AmuletMaster.Builder()
                   .WithHealth(DefaultHealth())
                   .WithAttack(DefaultDamage())
                   .AddModificator(new AttackSkillModificatorFactory())
                   .AddModificator(new MagicShieldModificatorFactory());
    }
}