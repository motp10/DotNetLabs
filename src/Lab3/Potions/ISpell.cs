using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Potions;

public interface ISpell
{
    ICreature Apply(ICreature currentCreature);
}