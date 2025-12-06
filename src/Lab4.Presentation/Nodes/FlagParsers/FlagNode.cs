using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.PrimaryNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers;

public abstract class FlagNode<T> : IFlagChain where T : ICommandBuilder
{
    public IFlagChain? NextNode { get; set; }

    public IParseNode? FlagValue { get; set; }

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

    public IFlagChain AddValueNode(IParseNode node)
    {
        FlagValue = node;
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
            result = NextValueParse(commandBuilder, enumerator);
            if (result is ParseResultType.Failure) return new ParseResultType.Failure();
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

    public virtual ParseResultType NextValueParse(T commandBuilder, IEnumerator<string> tokens)
    {
        if (FlagValue != null)
        {
            return FlagValue.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Failure();
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