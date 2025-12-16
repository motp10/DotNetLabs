using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers;

public abstract class CommandNode : ICommandNode
{
    public ICommandNode? NextNode { get; set; }

    public ICommandNode AddNextNode(ICommandNode node)
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

    public abstract ParseResultType TryParse(IEnumerator<string> enumerator);

    public ParseResultType NextNodeParse(IEnumerator<string> tokens)
    {
        if (NextNode != null)
        {
            return NextNode.TryParse(tokens);
        }

        return new ParseResultType.Failure();
    }
}