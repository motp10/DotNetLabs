namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class DisconnectBuilder : ICommandBuilder
{
    public ICommand Build()
    {
        return new Disconnect();
    }
}