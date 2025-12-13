namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

public interface IWithDepthBuilder
{
    ICommandBuilder WithDepth(int depth);
}