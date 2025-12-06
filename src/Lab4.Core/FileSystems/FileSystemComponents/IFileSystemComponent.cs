using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;

public interface IFileSystemComponent
{
    bool HasNextcomponent();

    IFileSystemComponent GetNextComponent();

    string Name { get; }

    void Accept(IFileSystemComponentVisitor visitor);
}