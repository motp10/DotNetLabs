namespace Itmo.ObjectOrientedProgramming.Lab3.Battles.ResultType;

public record BattleResult
{
    private BattleResult() { }

    public record Draw : BattleResult { }

    public record FirstWinner : BattleResult { }

    public record SecondWinner : BattleResult { }
}