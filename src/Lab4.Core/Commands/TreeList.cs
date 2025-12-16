using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors.VisitorsBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeList : ICommand
{
    private readonly IVisitorBuilder _builder;

    public TreeList(IVisitorBuilder builder)
    {
        _builder = builder;
    }

    public CommandResultType Execute(FileSystemConnector connector)
    {
        string newPath = connector.CurrentPath;
        if (connector.FileSystem.IsAbsolutePath(newPath))
        {
            newPath = connector.FileSystem.Combine(connector.AbsolutePath, newPath);
        }
        else
        {
            newPath = connector.FileSystem.ResolvePath(newPath, connector.CurrentPath);
        }

        if (!connector.FileSystem.IsExist(newPath)) return new CommandResultType.Failure();
        _builder.WithData(connector.DefaultTreeListSymbols());
        _builder.WithIterator(connector.FileSystem.GetIterator(connector.CurrentPath));
        IFileSystemComponentVisitor visitor = _builder.Build();
        visitor.Visit(new DirectoryFileSystemComponent(newPath, connector.FileSystem.GetIterator(newPath)));
        return new CommandResultType.Succes();
    }
}