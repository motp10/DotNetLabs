using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class FileRenameBuilder : IPathBuilder, INameBuilder
{
    public string Path { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public ICommandBuilder WithPath(string path)
    {
        Path = path;
        return this;
    }

    public ICommandBuilder WithName(string name)
    {
        Name = name;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(Path) || string.IsNullOrEmpty(Name)) throw new Exception("Source and Destination are required");
        return new FileRename(Path, Name);
    }
}