using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class DisconnectNode : CommandNode
{
    public string TokenName => "disconnect";

    public IParseNode<DisconnectBuilder>? SubChain { get; set; }

    public CommandNode AddSubchain(IParseNode<DisconnectBuilder> node)
    {
        SubChain = node;

        return this;
    }

    public ParseResultType NextSubchainParse(IEnumerator<string> enumerator)
    {
        if (SubChain != null)
        {
            return SubChain.TryParse(new DisconnectBuilder(), enumerator);
        }

        return new ParseResultType.Success(new DisconnectBuilder());
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