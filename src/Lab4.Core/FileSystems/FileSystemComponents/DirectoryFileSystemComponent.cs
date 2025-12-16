using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;

public class DirectoryFileSystemComponent : IFileSystemComponent
{
    public string Name { get; }

    private readonly IComponentsIterator _iterator;

    public IFileSystemComponent? GiveSubComponents()
    {
        if (_iterator.HasNextcomponent())
        {
            return _iterator.GetNextComponent();
        }

        return null;
    }

    public DirectoryFileSystemComponent(string name, IComponentsIterator iterator)
    {
        Name = name;
        _iterator = iterator;
    }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}