using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagValueParsers;

public abstract class FlagValueNode<T> where T : ICommandBuilder
{
    public FlagValueNode<T>? NextNode { get; set; }

    public FlagValueNode<T> AddNextNode(FlagValueNode<T> node)
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