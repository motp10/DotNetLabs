using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;

public abstract class CreatureBuilder : ICreatureBuilder, IDamageBuilder, IHealthBuilder
{
    public Health Health { get; protected set; }

    public Damage Attack { get; protected set; }

    private readonly List<IModificatorFactory> _modificators = new List<IModificatorFactory>();

    protected IReadOnlyList<IModificatorFactory> Modificators => _modificators.AsReadOnly();

    protected CreatureBuilder() { }

    public ICreatureBuilder AddModificator(IModificatorFactory modificator)
    {
        _modificators.Add(modificator);
        return this;
    }

    public ICreatureBuilder AddModificators(IReadOnlyCollection<IModificatorFactory> modificators)
    {
        foreach (IModificatorFactory factory in modificators)
        {
            _modificators.Add(factory);
        }

        return this;
    }

    public IDamageBuilder WithHealth(Health health)
    {
        Health = health;
        return this;
    }

    public ICreatureBuilder WithAttack(Damage attack)
    {
        Attack = attack;
        return this;
    }

    public abstract ICreature Build();
}