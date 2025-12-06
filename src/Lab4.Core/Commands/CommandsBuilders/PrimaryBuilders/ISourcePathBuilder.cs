namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

public interface ISourcePathBuilder : ICommandBuilder
{
    ICommandBuilder WithSourcePath(string sourcePath);
}