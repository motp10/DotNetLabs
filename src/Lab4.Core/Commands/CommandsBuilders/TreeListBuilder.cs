using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors.VisitorsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class TreeListBuilder : IPathBuilder, IWithDepthBuilder
{
    private readonly FormatingVisitorBuilder _builder = new FormatingVisitorBuilder();

    public string Path { get; private set; } = string.Empty;

    public ICommandBuilder WithPath(string path)
    {
        Path = path;
        return this;
    }

    public ICommandBuilder WithDepth(int depth)
    {
        _builder.WithDepth(depth);
        return this;
    }

    public ICommandBuilder WithFileSymbols(string symbols)
    {
        _builder.WithFileSymbols(symbols);
        return this;
    }

    public ICommandBuilder WithDirectorySymbols(string symbols)
    {
        _builder.WithDirectorySymbols(symbols);
        return this;
    }

    public ICommandBuilder WithIdentation(char symbol)
    {
        _builder.WithIdentation(symbol);
        return this;
    }

    public ICommand Build()
    {
        return new TreeList(Path, _builder);
    }
}