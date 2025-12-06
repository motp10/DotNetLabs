namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;

public interface IComponentsIterator
{
    bool HasNextcomponent();

    IFileSystemComponent GetNextComponent();
}