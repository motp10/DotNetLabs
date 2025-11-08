using Itmo.ObjectOrientedProgramming.Lab3.Battles.ResultType;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;

namespace Itmo.ObjectOrientedProgramming.Lab3.Battles;

public class Battle
{
    private readonly PlayerTable _firstPlayer;
    private readonly PlayerTable _secondPlayer;

    public Battle(PlayerTable firstPlayer, PlayerTable secondPlayer)
    {
        _firstPlayer = firstPlayer.Clone();
        _secondPlayer = secondPlayer.Clone();
    }

    public BattleResult Fight()
    {
        PlayerTable defensePlayer = _firstPlayer;
        PlayerTable attackPlayer = _secondPlayer;
        bool isFirstAttack = false;

        while (true)
        {
            (attackPlayer, defensePlayer) = (defensePlayer, attackPlayer);
            isFirstAttack = !isFirstAttack;
            ICreature? attackCreature = attackPlayer.GiveRandomAttackCreature();
            ICreature? defenceCreature = defensePlayer.GiveRandomDeffenceCreature();

            if (attackCreature == null)
            {
                if (defenceCreature == null)
                {
                    return new BattleResult.Draw();
                }

                continue;
            }

            if (defenceCreature == null)
            {
                if (isFirstAttack)
                {
                    return new BattleResult.FirstWinner();
                }

                return new BattleResult.SecondWinner();
            }

            attackCreature.CauseDamage(defenceCreature);
        }
    }
}