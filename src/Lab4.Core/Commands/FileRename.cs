using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
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
        string resolvedPath = connector.FileSystem.ResolvePath(_path, connector.CurrentPath);
        if (!connector.FileSystem.IsExist(resolvedPath)) return new CommandResultType.Failure();
        if (!connector.FileSystem.IsInRoot(resolvedPath, connector.AbsolutePath)) return new CommandResultType.Failure();
        return connector.FileSystem.Rename(_path,  _name);
    }
}