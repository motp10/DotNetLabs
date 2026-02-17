using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.BuilderResultType;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class FileRenameBuilder : IPathBuilder, INameBuilder
{
    public string Path { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public ICommandBuilder WithPath(string path)
    {
        Path = path;
        return this;
    }

    public ICommandBuilder WithName(string name)
    {
        Name = name;
        return this;
    }

    public BuildResultType Build()
    {
        if (string.IsNullOrEmpty(Path) || string.IsNullOrEmpty(Name)) return new BuildResultType.Failure();
        return new BuildResultType.Success(new FileRename(Path, Name));
    }
}