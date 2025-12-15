using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileRename : ICommand
{
    private readonly string _path;

    private readonly string _name;

    public FileRename(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public CommandResultType Execute(FileSystemConnector connector)
    {
        string newPath = _path;
        if (connector.FileSystem.IsAbsolutePath(newPath))
        {
            newPath = connector.FileSystem.Combine(connector.AbsolutePath, newPath);
        }
        else
        {
            newPath = connector.FileSystem.ResolvePath(newPath, connector.CurrentPath);
        }

        if (!connector.FileSystem.IsExist(newPath)) return new CommandResultType.Failure();
        if (!connector.FileSystem.IsName(_name)) return new CommandResultType.Failure();

        FileSystemResultType result = connector.FileSystem.Rename(_path, _name);
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