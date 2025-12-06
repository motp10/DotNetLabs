using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers.FlagNodes;

public class ModeNode<T> : FlagNode<T> where T : FileShowBuilder
{
    public override string TokenName => "-m";

    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                return NextFlagParse(commandBuilder, enumerator);
            }

            return new ParseResultType.Failure();
        }

        return NextFlagParse(commandBuilder, enumerator);
    }
}