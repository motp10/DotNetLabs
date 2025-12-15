using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class FileRenameNode : CommandNode
{
    public string TokenName => "rename";

    public PathNode<FileRenameBuilder>? SubChain { get; set; }

    public CommandNode AddSubchain(PathNode<FileRenameBuilder>? node)
    {
        SubChain = node;

        return this;
    }

    public ParseResultType NextSubchainParse(IEnumerator<string> tokens)
    {
        if (SubChain != null)
        {
            return SubChain.TryParse(new FileRenameBuilder(), tokens);
        }

        return new ParseResultType.Success(new FileRenameBuilder());
    }

    public override ParseResultType TryParse(IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                return NextSubchainParse(enumerator);
            }
        }

        return NextNodeParse(enumerator);
    }
}