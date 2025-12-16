using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagValueParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers.FlagNodes;

public class ModeNode<T> : FlagNode<T> where T : ICommandBuilder
{
    public string TokenName => "-m";

    public FlagValueNode<T>? SubChain { get; set; }

    public ModeNode<T> AddSubchain(FlagValueNode<T>? node)
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

            return new ParseResultType.Success(commandBuilder);
        }

        return NextNodeParse(commandBuilder, enumerator);
    }
}