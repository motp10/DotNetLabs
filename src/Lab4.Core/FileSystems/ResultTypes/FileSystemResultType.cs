namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.ResultTypes;

public record FileSystemResultType
{
    private FileSystemResultType() { }

    public sealed record Succes : FileSystemResultType { }

    public sealed record Failure : FileSystemResultType { }
}