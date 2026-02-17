using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class EmptyFileSystem : IFileSystem
{
    public FileSystemResultType Delete(string fileName)
    {
        return new FileSystemResultType.Failure();
    }

    public FileSystemResultType Move(string sourceFile, string destinationFile)
    {
        return new FileSystemResultType.Failure();
    }

    public FileSystemResultType Copy(string sourceFile, string destinationFile)
    {
        return new FileSystemResultType.Failure();
    }

    public FileSystemResultType Connect(string path)
    {
        return new FileSystemResultType.Failure();
    }

    public FileSystemResultType Disconnect()
    {
        return new FileSystemResultType.Failure();
    }

    public FileSystemResultType TreeGoTo(string path)
    {
        return new FileSystemResultType.Failure();
    }

    public IComponentsIterator GetIterator(string root)
    {
        throw new NotImplementedException();
    }

    public string Combine(string absolutePath, string inputPath)
    {
        throw new NotImplementedException();
    }

    public FileSystemResultType Rename(string path, string name)
    {
        return new FileSystemResultType.Failure();
    }

    public string GetFileText(string path)
    {
        throw new NotImplementedException();
    }

    public bool IsExist(string fileName)
    {
        throw new NotImplementedException();
    }

    public bool IsInRoot(string path, string absolutePath)
    {
        throw new NotImplementedException();
    }

    public bool IsAbsolutePath(string path)
    {
        throw new NotImplementedException();
    }

    public string ResolvePath(string path, string currentPath)
    {
        throw new NotImplementedException();
    }

    public bool IsName(string name)
    {
        return false;
    }
}