using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers.CommandNodes;

public class DisconnectNode<T> : CommandNode<T> where T : ICommandBuilder
{
    public string TokenName => "disconnect";

    public IParseNode<DisconnectBuilder>? SubChain { get; set; }

    public IParseNode<T> AddSubchain(IParseNode<DisconnectBuilder> node)
    {
        SubChain = node;

        return this;
    }

    public ParseResultType NextSubchainParse(DisconnectBuilder commandBuilder, IEnumerator<string> tokens)
    {
        if (SubChain != null)
        {
            return SubChain.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(commandBuilder);
    }

    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                if (SubChain != null) return NextSubchainParse(new DisconnectBuilder(), enumerator);
                return new ParseResultType.Success(new DisconnectBuilder());
            }
        }

        return NextNodeParse(commandBuilder, enumerator);
    }
}