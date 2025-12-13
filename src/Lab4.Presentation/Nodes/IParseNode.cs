using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes;

public interface IParseNode<T> where T : ICommandBuilder
{
    ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator);

    IParseNode<T> AddNextNode(IParseNode<T> node);
}