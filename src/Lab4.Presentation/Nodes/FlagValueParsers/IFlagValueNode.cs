using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagValueParsers;

public interface IFlagValueNode<T> where T : ICommandBuilder
{
    IFlagValueNode<T>? NextNode { get; }

    IFlagValueNode<T> AddNextNode(IFlagValueNode<T> node);

    ParseResultType TryParse(T builder, IEnumerator<string> enumerator);

    ParseResultType NextNodeParse(T builder, IEnumerator<string> enumerator);
}