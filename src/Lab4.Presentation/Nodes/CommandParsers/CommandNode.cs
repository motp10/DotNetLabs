using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.PrimaryNodes;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers;

public abstract class CommandNode : IFlagChain, IArgumentChain, ISubcommandChain
{
    public CommandNode? NextNode { get; set; }

    public ISubcommandChain? NextSubcommand { get; set; }

    public IArgumentChain? NextArgument { get; set; }

    public IFlagChain? NextFlag { get; set; }

    public abstract string TokenName { get; }

    public virtual CommandNode AddNextNode(CommandNode node)
    {
        if (NextNode == null)
        {
            NextNode = node;
        }
        else
        {
            NextNode.AddNextNode(node);
        }

        return this;
    }

    public virtual ISubcommandChain AddNextSubcommand(ISubcommandChain node)
    {
        if (NextSubcommand == null)
        {
            NextSubcommand = node;
        }
        else
        {
            NextSubcommand.AddNextSubcommand(node);
        }

        return this;
    }

    public virtual IArgumentChain AddNextArgument(IArgumentChain node)
    {
        if (NextArgument == null)
        {
            NextArgument = node;
        }
        else
        {
            NextArgument.AddNextArgument(node);
        }

        return this;
    }

    public virtual IFlagChain AddNextFlag(IFlagChain node)
    {
        if (NextFlag == null)
        {
            NextFlag = node;
        }
        else
        {
            NextFlag.AddNextFlag(node);
        }

        return this;
    }

    public virtual ParseResultType TryParse(ICommandBuilder commandBuilder, IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                if (NextSubcommand != null) return NextSubcommandParse(commandBuilder, enumerator);
                if (NextArgument != null) return NextArgumentParse(commandBuilder, enumerator);
                if (NextFlag != null) return NextFlagParse(commandBuilder, enumerator);
            }

            return new ParseResultType.Success(commandBuilder);
        }

        return NextNodeParse(commandBuilder, enumerator);
    }

    public virtual ParseResultType NextNodeParse(ICommandBuilder commandBuilder, IEnumerator<string> tokens)
    {
        if (NextNode != null)
        {
            return NextNode.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(commandBuilder);
    }

    public virtual ParseResultType NextArgumentParse(ICommandBuilder commandBuilder, IEnumerator<string> tokens)
    {
        if (NextArgument != null)
        {
            return NextArgument.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(commandBuilder);
    }

    public virtual ParseResultType NextSubcommandParse(ICommandBuilder commandBuilder, IEnumerator<string> tokens)
    {
        if (NextSubcommand != null)
        {
            return NextSubcommand.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(commandBuilder);
    }

    public virtual ParseResultType NextFlagParse(ICommandBuilder commandBuilder, IEnumerator<string> tokens)
    {
        if (NextFlag != null)
        {
            while (true)
            {
                NextFlag.TryParse(commandBuilder, tokens);
                if (!tokens.MoveNext()) return new ParseResultType.Success(commandBuilder);
            }
        }

        return new ParseResultType.Success(commandBuilder);
    }
}