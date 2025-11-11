using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Builders.SimpleInterfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab3.ModificationFactories;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.BaseCreatures;

public class BattleAnalyst : BaseCreature
{
    public static Health DefaultHelth()
    {
        return new Health(4);
    }

    public static Damage DefaultAttack()
    {
        return new Damage(2);
    }

    private bool _isBoosted;

    private BattleAnalyst(Damage attack, Health health, bool boost = false)
    : base(attack, health)
    {
        _isBoosted = boost;
    }

    public override void CauseDamage(ICreature target)
    {
        if (!_isBoosted)
        {
            var newAttack = new Damage(Attack.Value + 2);
            SetAttack(newAttack);
            _isBoosted = true;
        }

        base.CauseDamage(target);
    }

    public override ICreature Clone()
    {
        return new BattleAnalyst(Attack, Health, _isBoosted);
    }

    public class BattleAnalystBuilder : ICreatureBuilder, IDamageBuilder, IHealthBuilder
    {
        private readonly List<IFactory> _modificators = new List<IFactory>();

        private Health _health;
        private Damage _attack;

        public BattleAnalystBuilder(Damage damage, Health health)
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
            var currCreature = new BattleAnalyst(_attack, _health);
            foreach (IFactory modificator in _modificators)
            {
                modificator.ImposeModification(currCreature);
            }

            return currCreature;
        }
    }
}