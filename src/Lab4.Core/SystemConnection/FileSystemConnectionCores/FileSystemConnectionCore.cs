using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection.States;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection.FileSystemConnectionCores;

public class FileSystemConnectionCore : IFileSystemConnectionCore
{
    public IFileSystem FileSystem { get; set; }

    public IConnectionState State { get; set; }

    public string AbsolutePath { get; set; }

    public string CurrentPath { get; set; }

    public FileSystemConnectionCore(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;

        State = new DeactiveConnectionState();

        AbsolutePath = string.Empty;

        CurrentPath = string.Empty;
    }

    public void Connect(string absolutePath)
    {
        State.Connect(this, absolutePath);
    }

    public void Disconnect()
    {
        State.Disconnect(this);
    }

    public void GoToNewPath(string path)
    {
        State.GotoNewPath(path, CurrentPath);
    }
}