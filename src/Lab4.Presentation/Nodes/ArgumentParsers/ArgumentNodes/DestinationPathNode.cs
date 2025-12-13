using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;

public class DestinationPathNode<T> : CommandNode<T> where T : IDestinationPathBuilder
{
    public CommandNode<IDestinationPathBuilder>? SubChain { get; set; }

    public IParseNode<T> AddSubchain(DestinationPathNode<IDestinationPathBuilder>? node)
    {
        SubChain = node;

        return this;
    }

    public ParseResultType NextSubchainParse(IDestinationPathBuilder commandBuilder, IEnumerator<string> tokens)
    {
        if (SubChain != null)
        {
            return SubChain.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(commandBuilder);
    }

    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        commandBuilder.WithDestinationPath(enumerator.Current);
        if (enumerator.MoveNext())
        {
            return NextSubchainParse(commandBuilder, enumerator);
        }

        return new ParseResultType.Success(commandBuilder);
    }
}