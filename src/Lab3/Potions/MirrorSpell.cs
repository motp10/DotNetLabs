using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Potions;

public class MirrorSpell : ISpell
{
    public ICreature Apply(ICreature creature)
    {
        var newHealth = new Health(creature.Attack.Value);
        var newDamage = new Damage(creature.Health.Value);

        creature.SetHealth(newHealth);
        creature.SetAttack(newDamage);

        return creature;
    }
}