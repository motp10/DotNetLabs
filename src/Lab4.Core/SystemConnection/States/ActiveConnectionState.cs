using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection.FileSystemConnectionCores;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection.States;

public class ActiveConnectionState : IConnectionState
{
    public void Connect(IFileSystemConnectionCore core, string path) { }

    public void Disconnect(IFileSystemConnectionCore core)
    {
        core.State = new DeactiveConnectionState();
        core.AbsolutePath = string.Empty;
    }

    public void GotoNewPath(string path, string currentPath)
    {
        currentPath = path;
    }
}