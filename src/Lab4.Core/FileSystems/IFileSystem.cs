using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IFileSystem
{
    CommandResultType Delete(string fileName);

    CommandResultType Move(string sourceFile, string destinationFile);

    CommandResultType Copy(string sourceFile, string destinationFile);

    CommandResultType Rename(string path, string name);

    IComponentsIterator GetIterator(string root);

    string GetFileText(string path);

    bool IsExist(string fileName);

    bool IsInRoot(string path, string absolutePath);

    bool IsAbsolutePath(string path);

    string ResolvePath(string path, string currentPath);
}