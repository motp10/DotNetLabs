using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors.VisitorsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class TreeListBuilder : IPathBuilder
{
    private readonly FormatingVisitorBuilder _builder = new FormatingVisitorBuilder();

    public string Path { get; private set; } = string.Empty;

    public ICommandBuilder WithPath(string path)
    {
        Path = path;
        return this;
    }

    public void WithPadding(int padding)
    {
        _builder.WithPadding(padding);
    }

    public void WithFileSymbols(string symbols)
    {
        _builder.WithFileSymbols(symbols);
    }

    public void WithDirectorySymbols(string symbols)
    {
        _builder.WithDirectorySymbols(symbols);
    }

    public void WithIdentation(char symbol)
    {
        _builder.WithIdentation(symbol);
    }

    public ICommand Build()
    {
        return new TreeList(Path, _builder);
    }
}