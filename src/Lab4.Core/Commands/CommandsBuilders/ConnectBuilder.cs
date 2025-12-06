using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class ConnectBuilder : IPathBuilder
{
    public string AbsolutePath { get; private set; } = string.Empty;

    public ICommandBuilder WithPath(string path)
    {
        AbsolutePath = path;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(AbsolutePath)) throw new Exception("Absolute path not set");
        return new Connect(AbsolutePath);
    }
}
