using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers;

public abstract class CommandNode<T> : IParseNode<T> where T : ICommandBuilder
{
    public IParseNode<T>? NextNode { get; set; }

    public IParseNode<T> AddNextNode(IParseNode<T> node)
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

    public abstract ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator);

    public ParseResultType NextNodeParse(T commandBuilder, IEnumerator<string> tokens)
    {
        if (NextNode != null)
        {
            return NextNode.TryParse(commandBuilder, tokens);
        }

        return new ParseResultType.Success(commandBuilder);
    }
}