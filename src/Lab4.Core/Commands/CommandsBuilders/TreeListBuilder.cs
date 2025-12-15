using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors;
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

    public void WithData(VIsitorData data)
    {
        _builder.WithData(data);
    }

    public ICommand Build()
    {
        return new TreeList(Path, _builder);
    }
}