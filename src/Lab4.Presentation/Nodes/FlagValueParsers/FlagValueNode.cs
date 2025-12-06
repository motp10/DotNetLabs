using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagValueParsers;

public abstract class FlagValueNode<T> : IParseNode where T : ICommandBuilder
{
    public abstract string TokenName { get; }

    public abstract ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator);

    ParseResultType IParseNode.TryParse(ICommandBuilder commandBuilder, IEnumerator<string> enumerator)
    {
        if (commandBuilder is T typedBuilder)
        {
            return TryParse(typedBuilder, enumerator);
        }

        return new ParseResultType.Failure();
    }
}