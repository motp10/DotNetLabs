using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class DisconnectNode : CommandNode
{
    private string TokenName => "disconnect";

    private IParseNode<DisconnectBuilder>? _subChain;

    public ICommandNode AddSubchain(IParseNode<DisconnectBuilder> node)
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

    private ParseResultType NextSubchainParse(IEnumerator<string> enumerator)
    {
        if (_subChain != null)
        {
            return _subChain.TryParse(new DisconnectBuilder(), enumerator);
        }

        return new ParseResultType.Success(new DisconnectBuilder());
    }
}