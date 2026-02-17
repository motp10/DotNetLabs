namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

public interface IDestinationPathBuilder : ICommandBuilder
{
    ICommandBuilder WithDestinationPath(string destinationPath);
}