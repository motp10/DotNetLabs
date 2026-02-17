namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

public interface INameBuilder : ICommandBuilder
{
    ICommandBuilder WithName(string name);
}