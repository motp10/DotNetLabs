using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers;

public abstract class FlagNode<T> where T : ICommandBuilder
{
    public FlagNode<T>? NextNode { get; set; }

    public FlagNode<T> AddNextNode(FlagNode<T> node)
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