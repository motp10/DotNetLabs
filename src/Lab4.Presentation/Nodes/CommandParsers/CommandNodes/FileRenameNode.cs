using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class FileRenameNode : CommandNode
{
    public override string TokenName => "rename";

    public override ParseResultType TryParse(ICommandBuilder commandBuilder, IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                if (NextSubcommand != null) return NextSubcommandParse(commandBuilder, enumerator);
                if (NextArgument != null) return NextArgumentParse(new FileRenameBuilder(), enumerator);
                if (NextFlag != null) return NextFlagParse(new FileRenameBuilder(), enumerator);
            }

            return new ParseResultType.Success(new FileRenameBuilder());
        }

        return NextNodeParse(commandBuilder, enumerator);
    }
}