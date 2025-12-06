using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors.VisitorsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeList : ICommand
{
    private readonly string _path;

    private readonly IVisitorBuilder _builder;

    public TreeList(string fileName, IVisitorBuilder builder)
    {
        _path = fileName;
        _builder = builder;
    }

    public CommandResultType Execute(FileSystemConnector connector)
    {
        string resolvedPath = connector.FileSystem.ResolvePath(_path, connector.CurrentPath);
        if (!connector.FileSystem.IsExist(resolvedPath)) return new CommandResultType.Failure();
        if (!connector.FileSystem.IsInRoot(resolvedPath, connector.AbsolutePath)) return new CommandResultType.Failure();
        IFileSystemComponentVisitor visitor = _builder.Build();
        visitor.Visit(new DirectoryFileSystemComponent(resolvedPath, connector.FileSystem.GetIterator(resolvedPath)));
        return new CommandResultType.Succes();
    }
}