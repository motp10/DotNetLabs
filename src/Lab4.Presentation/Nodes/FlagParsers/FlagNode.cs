using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers;

public abstract class FlagNode<T> : IFlagNode<T> where T : ICommandBuilder
{
    public IFlagNode<T>? NextNode { get; set; }

    public IFlagNode<T> AddNextNode(IFlagNode<T> node)
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

    public abstract ParseResultType TryParse(T builder, IEnumerator<string> enumerator);

    public ParseResultType NextNodeParse(T builder, IEnumerator<string> enumerator)
    {
        if (NextNode != null)
        {
            return NextNode.TryParse(builder, enumerator);
        }

        return new ParseResultType.Failure();
    }
}