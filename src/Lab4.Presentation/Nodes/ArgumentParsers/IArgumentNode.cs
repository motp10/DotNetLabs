using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers;

public interface IArgumentNode<T> where T : ICommandBuilder
{
    IArgumentNode<T>? NextNode { get; }

    IArgumentNode<T> AddNextNode(IArgumentNode<T> node);

    ParseResultType TryParse(T builder, IEnumerator<string> enumerator);

    ParseResultType NextNodeParse(T builder, IEnumerator<string> enumerator);
}