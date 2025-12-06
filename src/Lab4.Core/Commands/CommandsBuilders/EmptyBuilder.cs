namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class EmptyBuilder : ICommandBuilder
{
    public ICommand Build()
    {
        throw new NotImplementedException();
    }
}