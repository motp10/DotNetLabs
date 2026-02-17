using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;

public class DestinationPathNode<T> : ArgumentNode<T> where T : IDestinationPathBuilder
{
    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        commandBuilder.WithDestinationPath(enumerator.Current);
        if (enumerator.MoveNext())
        {
            return NextNodeParse(commandBuilder, enumerator);
        }

        return new ParseResultType.Success(commandBuilder);
    }
}