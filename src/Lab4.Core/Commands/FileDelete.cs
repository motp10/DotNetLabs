using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileDelete : ICommand
{
    private readonly string _fileName;

    public FileDelete(string fileName)
    {
        _fileName = fileName;
    }

    public CommandResultType Execute(FileSystemConnector connector)
    {
        string newName = _fileName;
        string currentPath = connector.CurrentPath;
        if (connector.FileSystem.IsAbsolutePath(_fileName))
        {
            newName = connector.FileSystem.Combine(connector.AbsolutePath, _fileName);
        }
        else
        {
            newName = connector.FileSystem.ResolvePath(newName, currentPath);
        }

        string resolvedFileName = connector.FileSystem.ResolvePath(_fileName, connector.CurrentPath);
        if (!connector.FileSystem.IsExist(resolvedFileName))
            return new CommandResultType.Failure();

        FileSystemResultType result = connector.FileSystem.Delete(_fileName);
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