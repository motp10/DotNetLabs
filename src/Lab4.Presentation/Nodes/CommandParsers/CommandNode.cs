using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers;

public abstract class CommandNode
{
    public CommandNode? NextNode { get; set; }

    public CommandNode AddNextNode(CommandNode node)
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