using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class TreeNode : CommandNode
{
    private string TokenName => "tree";

    private CommandNode? _subChain;

    public CommandNode AddSubchain(CommandNode? node)
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

            return new ParseResultType.Failure();
        }

        return NextNodeParse(enumerator);
    }

    private ParseResultType NextSubchainParse(IEnumerator<string> tokens)
    {
        if (_subChain != null)
        {
            return _subChain.TryParse(tokens);
        }

        return new ParseResultType.Failure();
    }
}