using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;

public class FileFileSystemComponent : IFileSystemComponent
{
    public bool HasNextcomponent()
    {
        return false;
    }

    public IFileSystemComponent GetNextComponent()
    {
        return this;
    }

    public string Name { get; }

    public FileFileSystemComponent(string name)
    {
        Name = name;
    }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}