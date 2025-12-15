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

    string Combine(string absolutePath, string inputPath);

    bool IsName(string name);

    string GetFileText(string path);

    bool IsExist(string fileName);

    bool IsAbsolutePath(string path);

    string ResolvePath(string path, string currentPath);
}