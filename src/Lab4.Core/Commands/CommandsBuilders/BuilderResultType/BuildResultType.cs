namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.BuilderResultType;

public record BuildResultType
{
    private BuildResultType() { }

    public sealed record Success : BuildResultType
    {
        public ICommand Command { get; }

        public Success(ICommand command)
        {
            Command = command;
        }
    }

    public sealed record Failure : BuildResultType { }
}