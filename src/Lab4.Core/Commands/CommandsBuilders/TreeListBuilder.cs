using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors.VisitorsBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class TreeListBuilder : ICommandBuilder, IWithDepthBuilder
{
    private readonly FormatingVisitorBuilder _builder = new FormatingVisitorBuilder();

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
        return new TreeList(_builder);
    }
}