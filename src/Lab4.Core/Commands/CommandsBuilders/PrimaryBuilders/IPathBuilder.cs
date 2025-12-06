namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

public interface IPathBuilder : ICommandBuilder
{
    ICommandBuilder WithPath(string path);
}