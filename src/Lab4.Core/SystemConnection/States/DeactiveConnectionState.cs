using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection.FileSystemConnectionCores;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection.States;

public class DeactiveConnectionState : IConnectionState
{
    public void Connect(IFileSystemConnectionCore core, string path)
    {
        core.State = new ActiveConnectionState();
        core.AbsolutePath = path;
    }

    public void Disconnect(IFileSystemConnectionCore core) { }

    public void GotoNewPath(string path, string currentPath) { }
}