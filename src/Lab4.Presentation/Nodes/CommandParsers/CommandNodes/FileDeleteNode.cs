using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class FileDeleteNode : CommandNode
{
    public override string TokenName => "delete";

    public override ParseResultType TryParse(ICommandBuilder commandBuilder, IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                if (NextSubcommand != null) return NextSubcommandParse(commandBuilder, enumerator);
                if (NextArgument != null) return NextArgumentParse(new FileDeleteBuilder(), enumerator);
                if (NextFlag != null) return NextFlagParse(new FileDeleteBuilder(), enumerator);
                return new ParseResultType.Success(new FileDeleteBuilder());
            }
        }

        return NextNodeParse(commandBuilder, enumerator);
    }
}