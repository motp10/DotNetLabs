using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.PrimaryNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers;

public abstract class ArgumentNode<T> : IArgumentChain where T : ICommandBuilder
{
    public virtual IArgumentChain? NextArgumentNode { get; set; }

    ParseResultType IParseNode.TryParse(ICommandBuilder commandBuilder, IEnumerator<string> enumerator)
    {
        if (commandBuilder is T typedBuilder)
        {
            return TryParse(typedBuilder, enumerator);
        }

        return new ParseResultType.Failure();
    }

    public IArgumentChain AddNextArgument(IArgumentChain node)
    {
        if (NextArgumentNode == null)
        {
            NextArgumentNode = node;
        }
        else
        {
            NextArgumentNode.AddNextArgument(node);
        }

        return this;
    }

    public virtual ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        if (enumerator.MoveNext())
        {
            return ParseNextArgument(commandBuilder, enumerator);
        }

        return new ParseResultType.Success(commandBuilder);
    }

    public virtual ParseResultType ParseNextArgument(T commandBuilder, IEnumerator<string> tokens)
    {
        if (NextArgumentNode != null)
        {
            return NextArgumentNode.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(commandBuilder);
    }
}