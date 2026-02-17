using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.BuilderResultType;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class TreeGoToBuilder : IPathBuilder
{
    public string Path { get; private set; } = string.Empty;

    public ICommandBuilder WithPath(string path)
    {
        Path = path;
        return this;
    }

    public BuildResultType Build()
    {
        if (string.IsNullOrEmpty(Path)) return new BuildResultType.Failure();
        return new BuildResultType.Success(new TreeGoTo(Path));
    }
}