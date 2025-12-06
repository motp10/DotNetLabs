using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class ConnectNode : CommandNode
{
    public override string TokenName => "connect";

    public override ParseResultType TryParse(ICommandBuilder commandBuilder, IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                if (NextSubcommand != null) return NextSubcommandParse(commandBuilder, enumerator);
                if (NextArgument != null) return NextArgumentParse(new ConnectBuilder(), enumerator);
                if (NextFlag != null) return NextFlagParse(new ConnectBuilder(), enumerator);
            }

            return new ParseResultType.Success(new ConnectBuilder());
        }

        return NextNodeParse(commandBuilder, enumerator);
    }
}