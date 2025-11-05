using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

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

    public AmuletMaster(Damage? attack = null, Health? health = null)
    : base(attack ?? DefaultAttack(),  health ?? DefaultHelth())
    {
    }

    public override ICreature Clone()
    {
        return new AmuletMaster();
    }
}