using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection.States;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection.FileSystemConnectionCores;

public interface IFileSystemConnectionCore
{
    IFileSystem FileSystem { get; }

    IConnectionState State { get; set; }

    string AbsolutePath { get; set; }

    string CurrentPath { get; set; }

    void Connect(string absolutePath);

    void Disconnect();

    void GoToNewPath(string path);
}