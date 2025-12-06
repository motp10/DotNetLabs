using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.SystemConnection;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class Disconnect : ICommand
{
    public CommandResultType Execute(FileSystemConnector connector)
    {
        if (!connector.IsConnected()) return new CommandResultType.Failure();
        connector.Disconnect();
        return new CommandResultType.Succes();
    }
}