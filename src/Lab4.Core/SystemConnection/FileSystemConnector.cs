using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection.FileSystemConnectionCores;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection.States;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection;

public class FileSystemConnector
{
    private IFileSystemConnectionCore _core;

    public string AbsolutePath => _core.AbsolutePath;

    public string CurrentPath => _core.CurrentPath;

    public IFileSystem FileSystem => _core.FileSystem;

    public FileSystemConnector()
    {
        _core = new FileSystemConnectionCore(new EmptyFileSystem());
    }

    public FileSystemConnector(IFileSystem fileSystem)
    {
        _core = new FileSystemConnectionCore(fileSystem);
    }

    public FileSystemConnector(IFileSystemConnectionCore core)
    {
        _core = core;
    }

    public void Connect(string absolutePath, IFileSystem fileSystem)
    {
        _core = new FileSystemConnectionCore(fileSystem);
        _core.Connect(absolutePath);
    }

    public void Disconnect()
    {
        _core.Disconnect();
    }

    public void Goto(string newCurrentPath)
    {
        _core.GoToNewPath(newCurrentPath);
    }

    public bool IsConnected()
    {
        return _core.State is ActiveConnectionState;
    }
}