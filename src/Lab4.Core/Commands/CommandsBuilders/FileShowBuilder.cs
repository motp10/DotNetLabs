using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.BuilderResultType;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class FileShowBuilder : IPathBuilder
{
    private IWriter? _writer = null;

    public string Path { get; private set; } = string.Empty;

    public ICommandBuilder WithPath(string path)
    {
        Path = path;
        return this;
    }

    public void WithWriter(IWriter? writer)
    {
        _writer = writer;
    }

    public BuildResultType Build()
    {
        if (_writer == null) return new BuildResultType.Failure();

        return new BuildResultType.Success(new FileShow(Path, _writer));
    }
}