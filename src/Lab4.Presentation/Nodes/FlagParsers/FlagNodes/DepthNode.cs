using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers.FlagNodes;

public class DepthNode<T> : FlagNode<T> where T : TreeListBuilder
{
    public override string TokenName => "-d";

    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                NextValueParse(commandBuilder, enumerator);
            }

            return new ParseResultType.Failure();
        }

        return NextFlagParse(commandBuilder, enumerator);
    }
}