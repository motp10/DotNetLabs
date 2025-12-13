using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public interface IFileSystem
{
    FileSystemResultType Delete(string fileName);

    FileSystemResultType Move(string sourceFile, string destinationFile);

    FileSystemResultType Copy(string sourceFile, string destinationFile);

    FileSystemResultType Rename(string path, string name);

    IComponentsIterator GetIterator(string root);

    bool IsName(string name);

    string GetFileText(string path);

    bool IsExist(string fileName);

    bool IsInRoot(string path, string absolutePath);

    bool IsAbsolutePath(string path);

    string ResolvePath(string path, string currentPath);
}