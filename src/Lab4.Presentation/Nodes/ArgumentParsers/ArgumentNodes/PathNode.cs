using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;

public class PathNode<T> : ArgumentNode<T> where T : IPathBuilder
{
    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        if (enumerator.MoveNext())
        {
            commandBuilder.WithPath(enumerator.Current);
            return ParseNextArgument(commandBuilder, enumerator);
        }

        return new ParseResultType.Failure();
    }
}