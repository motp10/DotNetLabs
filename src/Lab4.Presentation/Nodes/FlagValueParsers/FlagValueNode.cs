using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagValueParsers;

public abstract class FlagValueNode<T> : IFlagValueNode<T> where T : ICommandBuilder
{
    public IFlagValueNode<T>? NextNode { get; private set; }

    public IFlagValueNode<T> AddNextNode(IFlagValueNode<T> node)
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