using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Builders.SimpleInterfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;

public class ImmortalFear : BaseCreature
{
    private bool _wasResurrected;

    public static Health DefaultHelth()
    {
        return new Health(4);
    }

    public static Damage DefaultAttack()
    {
        return new Damage(4);
    }

    public ImmortalFear(Damage attack, Health health)
    : base(attack, health)
    {
        _wasResurrected = false;
    }

    public override void ReceiveDamage(Damage damage)
    {
        base.ReceiveDamage(damage);

        if (IsDead() && !_wasResurrected)
        {
            _wasResurrected = true;
            Health = new Health(1);
        }
    }

    public override ICreature Clone()
    {
        return new ImmortalFear(Attack, Health);
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
            var currCreature = new ImmortalFear(_attack, _health);
            foreach (IModificatorFactory modificator in _modificators)
            {
                modificator.ImposeModification(currCreature);
            }

            return currCreature;
        }
    }
}