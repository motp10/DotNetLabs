using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.BuilderResultType;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class ConnectBuilder : IPathBuilder, IWithFileSystemBuilder
{
    public string AbsolutePath { get; private set; } = string.Empty;

    public IFileSystem? FileSystem { get; private set; }

    public ICommandBuilder WithPath(string path)
    {
        AbsolutePath = path;
        return this;
    }

    public ICommandBuilder WithFileSystem(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
        return this;
    }

    public BuildResultType Build()
    {
        if (string.IsNullOrEmpty(AbsolutePath) || (FileSystem == null)) return new BuildResultType.Failure();
        return new BuildResultType.Success(new Connect(AbsolutePath, FileSystem));
    }
}
