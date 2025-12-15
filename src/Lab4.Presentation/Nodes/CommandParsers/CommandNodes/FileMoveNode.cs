using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class FileMoveNode : CommandNode
{
    public string TokenName => "move";

    public SourcePathNode<FileMoveBuilder>? SubChain { get; set; }

    public CommandNode AddSubchain(SourcePathNode<FileMoveBuilder>? node)
    {
        SubChain = node;

        return this;
    }

    public ParseResultType NextSubchainParse(IEnumerator<string> tokens)
    {
        if (SubChain != null)
        {
            return SubChain.TryParse(new FileMoveBuilder(), tokens);
        }

        return new ParseResultType.Success(new FileMoveBuilder());
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