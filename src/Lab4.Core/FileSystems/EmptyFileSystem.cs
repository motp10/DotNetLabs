using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class EmptyFileSystem : IFileSystem
{
    public CommandResultType Delete(string fileName)
    {
        return new CommandResultType.Failure();
    }

    public CommandResultType Move(string sourceFile, string destinationFile)
    {
        return new CommandResultType.Failure();
    }

    public CommandResultType Copy(string sourceFile, string destinationFile)
    {
        return new CommandResultType.Failure();
    }

    public CommandResultType Connect(string path)
    {
        return new CommandResultType.Failure();
    }

    public CommandResultType Disconnect()
    {
        return new CommandResultType.Failure();
    }

    public CommandResultType TreeGoTo(string path)
    {
        return new CommandResultType.Failure();
    }

    public IComponentsIterator GetIterator(string root)
    {
        throw new NotImplementedException();
    }

    public CommandResultType Rename(string path, string name)
    {
        return new CommandResultType.Failure();
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
}