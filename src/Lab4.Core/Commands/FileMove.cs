using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileMove : ICommand
{
    private readonly string _sourceFile;

    private readonly string _destinationFile;

    public FileMove(string sourceFile, string destinationFile)
    {
        _sourceFile = sourceFile;
        _destinationFile = destinationFile;
    }

    public CommandResultType Execute(FileSystemConnector connector)
    {
        if (!connector.IsConnected()) return new CommandResultType.Failure();

        string currentPath = connector.CurrentPath;
        string absolutePath = connector.AbsolutePath;
        string newSourcePath = _sourceFile;
        string newDestinationPath = _destinationFile;
        if (connector.FileSystem.IsAbsolutePath(_sourceFile))
        {
            newSourcePath = connector.FileSystem.Combine(connector.AbsolutePath, _sourceFile);
        }
        else
        {
            newSourcePath = connector.FileSystem.ResolvePath(_sourceFile, currentPath);
        }

        if (connector.FileSystem.IsAbsolutePath(_destinationFile))
        {
            newDestinationPath = connector.FileSystem.Combine(connector.AbsolutePath, _destinationFile);
        }
        else
        {
            newDestinationPath = connector.FileSystem.ResolvePath(_destinationFile, currentPath);
        }

        if (!connector.FileSystem.IsExist(newSourcePath)) return new CommandResultType.Failure();
        if (!connector.FileSystem.IsExist(newDestinationPath)) return new CommandResultType.Failure();

        FileSystemResultType result = connector.FileSystem.Move(newSourcePath, newDestinationPath);
        if (result is FileSystemResultType.Succes)
        {
            return new CommandResultType.Succes();
        }
        else
        {
            return new CommandResultType.Failure();
        }
    }
}