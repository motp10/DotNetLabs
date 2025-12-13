using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers.FlagNodes;

public class ModeNode<T> : CommandNode<T> where T : ICommandBuilder
{
    public string TokenName => "-m";

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
        if (enumerator.Current == TokenName)
        {
            if (enumerator.MoveNext())
            {
                NextSubchainParse(commandBuilder, enumerator);
            }

            while (enumerator.MoveNext())
            {
                NextNodeParse(commandBuilder, enumerator);
            }

            return new ParseResultType.Failure();
        }

        return NextNodeParse(commandBuilder, enumerator);
    }
}