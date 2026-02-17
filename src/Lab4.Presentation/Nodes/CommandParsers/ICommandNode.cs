using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers;

public interface ICommandNode
{
    ICommandNode? NextNode { get; set; }

    ICommandNode AddNextNode(ICommandNode node);

    ParseResultType TryParse(IEnumerator<string> enumerator);

    ParseResultType NextNodeParse(IEnumerator<string> tokens);
}