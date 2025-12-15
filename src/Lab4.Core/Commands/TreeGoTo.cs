using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeGoTo : ICommand
{
    private readonly string _path;

    public TreeGoTo(string fileName)
    {
        _path = fileName;
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

        connector.Goto(newPath);
        return new CommandResultType.Succes();
    }
}