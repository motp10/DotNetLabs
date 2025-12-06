using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class FileDeleteBuilder : ICommandBuilder, IPathBuilder
{
    public string AbsolutePath { get; private set; } = string.Empty;

    public ICommandBuilder WithPath(string path)
    {
        AbsolutePath = path;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(AbsolutePath)) throw new Exception("Source and Destination are required");
        return new FileDelete(AbsolutePath);
    }
}