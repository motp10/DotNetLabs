using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagValueParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers.FlagNodes;

public class ModeNode<T> : ArgumentNode<T> where T : ICommandBuilder
{
    public string TokenName => "-m";

    public FlagValueNode<T>? SubChain { get; set; }

    public ArgumentNode<T> AddSubchain(FlagValueNode<T>? node)
    {
        SubChain = node;

        return this;
    }

    public ParseResultType NextSubchainParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        if (SubChain != null)
        {
            return SubChain.TryParse(commandBuilder, enumerator);
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
            else
            {
                return new ParseResultType.Failure();
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