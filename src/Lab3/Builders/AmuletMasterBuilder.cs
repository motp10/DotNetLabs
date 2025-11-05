using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders;

public class AmuletMasterBuilder : ICreatureBuilder
{
    private readonly List<IFactory> _modificators = new List<IFactory>
    {
        new AttackSkillFactory(),
        new MagicShieldFactory(),
    };

    private Health _health = AmuletMaster.DefaultHelth();
    private Damage _attack = AmuletMaster.DefaultAttack();

    public ICreatureBuilder AddModificator(IFactory modificator)
    {
        _modificators.Add(modificator);
        return this;
    }

    public ICreatureBuilder AddModificators(IReadOnlyCollection<IFactory> modificators)
    {
        foreach (IFactory factory in modificators)
        {
            _modificators.Add(factory);
        }

        return this;
    }

    public ICreatureBuilder WithHealth(Health health)
    {
        _health = health;
        return this;
    }

    public ICreatureBuilder WithAttack(Damage attack)
    {
        _attack = attack;
        return this;
    }

    public ICreature Build()
    {
        ICreature currCreature = new AmuletMaster(_attack, _health);
        foreach (IFactory modificator in _modificators)
        {
            currCreature = modificator.ImposeModification(currCreature);
        }

        return currCreature;
    }
}