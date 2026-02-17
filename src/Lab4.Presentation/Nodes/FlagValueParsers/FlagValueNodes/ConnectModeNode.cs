using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Nodes.FlagValueParsers.FlagValueNodes;

public class ConnectModeNode<T> : FlagValueNode<T> where T : IWithFileSystemBuilder
{
    public string TokenName => "local";

    public override ParseResultType TryParse(T commandBuilder, IEnumerator<string> enumerator)
    {
        if (enumerator.Current == TokenName)
        {
            commandBuilder.WithFileSystem(new LocalFileSystem());
            return new ParseResultType.Success(commandBuilder);
        }

        return NextNodeParse(commandBuilder, enumerator);
    }
}