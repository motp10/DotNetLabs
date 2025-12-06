using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class TreeGoToBuilder : IPathBuilder
{
    public string Path { get; private set; } = string.Empty;

    public ICommandBuilder WithPath(string path)
    {
        Path = path;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(Path)) throw new Exception("Source and Destination are required");
        return new TreeGoTo(Path);
    }
}