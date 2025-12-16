using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class FileMoveNode : CommandNode
{
    private string TokenName => "move";

    private SourcePathNode<FileMoveBuilder>? _subChain;

    public CommandNode AddSubchain(SourcePathNode<FileMoveBuilder>? node)
    {
        _subChain = node;
        return this;
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

    private ParseResultType NextSubchainParse(IEnumerator<string> tokens)
    {
        if (_subChain != null)
        {
            return _subChain.TryParse(new FileMoveBuilder(), tokens);
        }

        return new ParseResultType.Success(new FileMoveBuilder());
    }
}