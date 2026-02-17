using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.BuilderResultType;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class FileDeleteBuilder : ICommandBuilder, IPathBuilder
{
    public string AbsolutePath { get; private set; } = string.Empty;

    public ICommandBuilder WithPath(string path)
    {
        AbsolutePath = path;
        return this;
    }

    public BuildResultType Build()
    {
        if (string.IsNullOrEmpty(AbsolutePath)) return new BuildResultType.Failure();
        return new BuildResultType.Success(new FileDelete(AbsolutePath));
    }
}