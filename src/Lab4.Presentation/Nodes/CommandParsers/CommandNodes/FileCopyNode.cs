using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class FileCopyNode : CommandNode
{
    private string TokenName => "copy";

    private IArgumentNode<FileCopyBuilder>? _subChain;

    public CommandNode AddSubchain(IArgumentNode<FileCopyBuilder>? node)
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
            return _subChain.TryParse(new FileCopyBuilder(), tokens);
        }

        return new ParseResultType.Success(new FileCopyBuilder());
    }
}