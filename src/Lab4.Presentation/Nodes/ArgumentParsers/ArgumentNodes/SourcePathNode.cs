using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;

public class SourcePathNode<T> : ArgumentNode<T> where T : ISourcePathBuilder
{
    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        commandBuilder.WithSourcePath(enumerator.Current);
        if (enumerator.MoveNext())
        {
            return ParseNextArgument(commandBuilder, enumerator);
        }

        return new ParseResultType.Failure();
    }
}