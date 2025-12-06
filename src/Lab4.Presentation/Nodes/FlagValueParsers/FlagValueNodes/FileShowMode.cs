using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagValueParsers.FlagValueNodes;

public class FileShowMode<T> : FlagValueNode<T> where T : FileShowBuilder
{
    public override string TokenName => "console";

    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            commandBuilder.WithWriter(new ConsoleWriter());
            return new ParseResultType.Success(commandBuilder);
        }

        return new ParseResultType.Failure();
    }
}