using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders.PrimaryBuilders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandsBuilders;

public class FileCopyBuilder : IDestinationPathBuilder, ISourcePathBuilder
{
    public string SourceFile { get; private set; } = string.Empty;

    public string DestinationFile { get; private set; } = string.Empty;

    public ICommandBuilder WithSourcePath(string sourcePath)
    {
        SourceFile = sourcePath;
        return this;
    }

    public ICommandBuilder WithDestinationPath(string destinationPath)
    {
        DestinationFile = destinationPath;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(SourceFile) || string.IsNullOrEmpty(DestinationFile)) throw new Exception("Source and destination paths must be set");
        return new FileCopy(SourceFile, DestinationFile);
    }
}