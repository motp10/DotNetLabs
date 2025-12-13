namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors;

public class VIsitorData
{
    public string FileSymbols { get; }

    public string DirectorySymbols { get; }

    public char Identation { get; }

    public VIsitorData(string fileSymbols, string directorySymbols, char identation)
    {
        FileSymbols = fileSymbols;
        DirectorySymbols = directorySymbols;
        Identation = identation;
    }
}