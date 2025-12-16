using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagParsers;

public interface IFlagNode<T> where T : ICommandBuilder
{
    IFlagNode<T>? NextNode { get; }

    IFlagNode<T> AddNextNode(IFlagNode<T> node);

    ParseResultType TryParse(T builder, IEnumerator<string> enumerator);

    ParseResultType NextNodeParse(T builder, IEnumerator<string> enumerator);
}