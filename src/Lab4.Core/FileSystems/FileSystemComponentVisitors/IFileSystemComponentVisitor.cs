using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent component) { }

    void Visit(DirectoryFileSystemComponent component) { }
}