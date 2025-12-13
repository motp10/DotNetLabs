using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.CommandParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;

public class SourcePathNode<T> : CommandNode<T> where T : ISourcePathBuilder
{
    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        commandBuilder.WithSourcePath(enumerator.Current);
        if (enumerator.MoveNext())
        {
            return NextNodeParse(commandBuilder, enumerator);
        }

        return new ParseResultType.Success(commandBuilder);
    }
}