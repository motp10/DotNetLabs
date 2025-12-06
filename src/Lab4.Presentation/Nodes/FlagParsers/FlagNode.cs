using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.PrimaryNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers;

public abstract class FlagNode<T> : IFlagChain where T : ICommandBuilder
{
    public IFlagChain? NextNode { get; set; }

    public abstract string TokenName { get; }

    public IFlagChain AddNextFlag(IFlagChain node)
    {
        if (NextNode == null)
        {
            NextNode = node;
        }
        else
        {
            NextNode.AddNextFlag(node);
        }

        return this;
    }

    public virtual void AddNextNode(FlagNode<T>? node)
    {
        NextNode = node;
    }

    public virtual ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        ParseResultType result;

        if (enumerator.Current == TokenName)
        {
            result = NextFlagParse(commandBuilder, enumerator);
            if (result is ParseResultType.Failure) return NextFlagParse(commandBuilder, enumerator);
        }

        return NextFlagParse(commandBuilder, enumerator);
    }

    public virtual ParseResultType NextFlagParse(T commandBuilder, IEnumerator<string> tokens)
    {
        if (NextNode != null)
        {
            return NextNode.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(commandBuilder);
    }

    ParseResultType IParseNode.TryParse(ICommandBuilder commandBuilder, IEnumerator<string> enumerator)
    {
        if (commandBuilder is T typedBuilder)
        {
            return TryParse(typedBuilder, enumerator);
        }

        return new ParseResultType.Failure();
    }
}