using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class Connect : ICommand
{
    private readonly string _absolutePath;

    private readonly IFileSystem _fileSystem;

    public Connect(string absolutePath, IFileSystem fileSystem)
    {
        _absolutePath = absolutePath;
        _fileSystem = fileSystem;
    }

    public CommandResultType Execute(FileSystemConnector connector)
    {
        if (connector.IsConnected()) return new CommandResultType.Failure();

        if (!_fileSystem.IsAbsolutePath(_absolutePath)) return new CommandResultType.Failure();

        connector.Connect(_absolutePath, _fileSystem);
        return new CommandResultType.Succes();
    }
}