using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class ConnectBuilder : IPathBuilder, IWithFileSystem
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

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(AbsolutePath)) throw new Exception("Absolute path not set");
        if (FileSystem == null) throw new Exception("FileSystem not set");
        return new Connect(AbsolutePath, FileSystem);
    }
}
