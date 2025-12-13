using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;

public class PathNode<T> : CommandNode<T> where T : IPathBuilder
{
    public CommandNode<T>? SubChain { get; set; }

    public IParseNode<T> AddSubchain(CommandNode<T>? node)
    {
        SubChain = node;

        return this;
    }

    public ParseResultType NextSubchainParse(T commandBuilder, IEnumerator<string> tokens)
    {
        if (SubChain != null)
        {
            return SubChain.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(commandBuilder);
    }

    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        commandBuilder.WithPath(enumerator.Current);
        if (enumerator.MoveNext())
        {
            return NextNodeParse(commandBuilder, enumerator);
        }

        return new ParseResultType.Success(commandBuilder);
    }
}