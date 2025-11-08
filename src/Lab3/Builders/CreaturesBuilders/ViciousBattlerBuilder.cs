using Itmo.ObjectOrientedProgramming.Lab3.Builders.SimpleInterfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;

public class ViciousBattlerBuilder : ICreatureBuilder, IDamageBuilder, IHealthBuilder
{
    private readonly List<IFactory> _modificators = new List<IFactory>();

    private Health _health;
    private Damage _attack;

    public ViciousBattlerBuilder(Damage damage, Health health)
    {
        _health = health;
        _attack = damage;
    }

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

    public IDamageBuilder WithHealth(Health health)
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
        var currCreature = new ViciousBattler(_attack, _health);
        foreach (IFactory modificator in _modificators)
        {
            modificator.ImposeModification(currCreature);
        }

        return currCreature;
    }
}