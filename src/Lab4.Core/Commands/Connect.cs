using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class Connect : ICommand
{
    private readonly string _absolutePath;

    public Connect(string absolutePath)
    {
        _absolutePath = absolutePath;
    }

    public CommandResultType Execute(FileSystemConnector connector)
    {
        if (!connector.IsConnected()) return new CommandResultType.Failure();

        if (!connector.FileSystem.IsAbsolutePath(_absolutePath)) return new CommandResultType.Failure();

        connector.Connect(_absolutePath);
        return new CommandResultType.Succes();
    }
}