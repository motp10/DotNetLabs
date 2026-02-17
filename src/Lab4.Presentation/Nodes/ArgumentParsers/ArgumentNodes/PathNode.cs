using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;

public class PathNode<T> : ArgumentNode<T> where T : IPathBuilder
{
    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        commandBuilder.WithPath(enumerator.Current);
        if (enumerator.MoveNext())
        {
            return NextNodeParse(commandBuilder, enumerator);
        }

        return new ParseResultType.Success(commandBuilder);
    }
}