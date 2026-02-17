namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ResultTypes;

public record CommandResultType
{
    private CommandResultType() { }

    public sealed record Succes : CommandResultType { }

    public sealed record Failure : CommandResultType { }
}