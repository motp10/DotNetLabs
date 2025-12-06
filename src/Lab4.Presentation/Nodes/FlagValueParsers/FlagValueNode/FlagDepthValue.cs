using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagValueParsers.FlagValueNode;

public class FlagDepthValue<T> : FlagValueNode<T> where T : TreeListBuilder
{
    public override string TokenName => string.Empty;

    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        if (int.TryParse(enumerator.Current, out int number))
        {
            if (number > 0)
            {
                commandBuilder.WithPadding(number);
                return new ParseResultType.Success(commandBuilder);
            }
        }

        return new ParseResultType.Failure();
    }
}