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
        string newCurrentcPath = connector.FileSystem.ResolvePath(_path, connector.CurrentPath);
        if (!connector.FileSystem.IsExist(newCurrentcPath)) return new CommandResultType.Failure();
        if (!connector.FileSystem.IsInRoot(newCurrentcPath, connector.AbsolutePath)) return new CommandResultType.Failure();

        connector.Goto(newCurrentcPath);
        return new CommandResultType.Succes();
    }
}