using Itmo.ObjectOrientedProgramming.Lab3.Builders.CreaturesBuilders;
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

    public class Builder : CreatureBuilder
    {
        public override ICreature Build()
        {
            ICreature currentCreature = new AmuletMaster(Attack, Health);
            foreach (IModificatorFactory modificator in Modificators)
            {
                currentCreature = modificator.ImposeModification(currentCreature);
            }

            return currentCreature;
        }
    }
}