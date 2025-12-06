using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileShow : ICommand
{
    private readonly string _fileName;

    private readonly IWriter _writer;

    public FileShow(string fileName, IWriter writer)
    {
        _fileName = fileName;
        _writer = writer;
    }

    public CommandResultType Execute(FileSystemConnector connector)
    {
        string resolvedFileName = connector.FileSystem.ResolvePath(_fileName, connector.CurrentPath);
        if (!connector.FileSystem.IsExist(resolvedFileName)) return new CommandResultType.Failure();
        if (!connector.FileSystem.IsExist(resolvedFileName)) return new CommandResultType.Failure();
        _writer.Write(connector.FileSystem.GetFileText(resolvedFileName));
        return new CommandResultType.Succes();
    }
}