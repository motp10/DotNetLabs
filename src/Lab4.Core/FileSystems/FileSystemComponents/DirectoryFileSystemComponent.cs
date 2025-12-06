using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;

public class DirectoryFileSystemComponent : IFileSystemComponent
{
    public string Name { get; }

    private readonly IComponentsIterator _iterator;

    public DirectoryFileSystemComponent(string name, IComponentsIterator iterator)
    {
        Name = name;
        _iterator = iterator;
    }

    public bool HasNextcomponent()
    {
        return _iterator.HasNextcomponent();
    }

    public IFileSystemComponent GetNextComponent()
    {
        return _iterator.GetNextComponent();
    }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}