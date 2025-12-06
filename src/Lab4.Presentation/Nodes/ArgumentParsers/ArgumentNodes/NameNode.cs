using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ArgumentParsers.ArgumentNodes;

public class NameNode<T> : ArgumentNode<T> where T : INameBuilder
{
    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        if (enumerator.MoveNext())
        {
            commandBuilder.WithName(enumerator.Current);
            return ParseNextArgument(commandBuilder, enumerator);
        }

        return new ParseResultType.Failure();
    }
}