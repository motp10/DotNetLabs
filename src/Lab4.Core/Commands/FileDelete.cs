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
        string resolvedFileName = connector.FileSystem.ResolvePath(_fileName, connector.CurrentPath);
        if (!connector.FileSystem.IsExist(resolvedFileName))
            return new CommandResultType.Failure();
        if (!connector.FileSystem.IsInRoot(resolvedFileName, connector.AbsolutePath))
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