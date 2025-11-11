using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Builders.SimpleInterfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;

public class AmuletMaster : BaseCreature
{
    public static Health DefaultHelth()
    {
        return new Health(2);
    }

    public static Damage DefaultAttack()
    {
        return new Damage(5);
    }

    private AmuletMaster(Damage attack, Health health)
    : base(attack, health)
    {
    }

    public override ICreature Clone()
    {
        return new AmuletMaster(Attack, Health);
    }

    public class Builder : ICreatureBuilder, IDamageBuilder, IHealthBuilder
    {
        private readonly List<IModificatorFactory> _modificators = new List<IModificatorFactory>();

        private Health _health;
        private Damage _attack;

        public Builder() { }

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
            foreach (IModificatorFactory modificator in _modificators)
            {
                currCreature = modificator.ImposeModification(currCreature);
            }

            return currCreature;
        }
    }
}