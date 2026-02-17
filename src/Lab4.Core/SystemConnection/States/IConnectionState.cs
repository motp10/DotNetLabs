using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection.FileSystemConnectionCores;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection.States;

public interface IConnectionState
{
    void Connect(IFileSystemConnectionCore core, string path);

    void Disconnect(IFileSystemConnectionCore core);

    void GotoNewPath(string path, string currentPath);
}
