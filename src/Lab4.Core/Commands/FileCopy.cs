using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileCopy : ICommand
{
    private readonly string _sourceFile;

    private readonly string _destinationFile;

    public FileCopy(string sourceFile, string destinationFile)
    {
        _sourceFile = sourceFile;
        _destinationFile = destinationFile;
    }

    public CommandResultType Execute(FileSystemConnector connector)
    {
        if (!connector.IsConnected()) return new CommandResultType.Failure();

        string currentPath = connector.CurrentPath;
        string absolutePath = connector.AbsolutePath;
        string resolevedSourcePath = connector.FileSystem.ResolvePath(_sourceFile, currentPath);
        string resolevedDestinationPath = connector.FileSystem.ResolvePath(_destinationFile, currentPath);

        if (!connector.FileSystem.IsInRoot(resolevedSourcePath, absolutePath)) return new CommandResultType.Failure();
        if (!connector.FileSystem.IsInRoot(resolevedDestinationPath, absolutePath)) return new CommandResultType.Failure();
        if (!connector.FileSystem.IsExist(resolevedSourcePath)) return new CommandResultType.Failure();
        if (!connector.FileSystem.IsExist(resolevedDestinationPath)) return new CommandResultType.Failure();

        return connector.FileSystem.Copy(_sourceFile,  _destinationFile);
    }
}