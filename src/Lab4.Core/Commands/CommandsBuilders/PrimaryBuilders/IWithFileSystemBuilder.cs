using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

public interface IWithFileSystemBuilder : ICommandBuilder
{
    ICommandBuilder WithFileSystem(IFileSystem fileSystem);
}