namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors.VisitorsBuilders;

public class FormatingVisitorBuilder : IVisitorBuilder
{
    public int Padding { get; private set; }

    public string FileSymbols { get; private set; }

    public string DirectorySymbols { get; private set; }

    public char Identation { get; private set; }

    public FormatingVisitorBuilder()
    {
        Padding = -1;
        FileSymbols = string.Empty;
        DirectorySymbols = string.Empty;
        Identation = ' ';
    }

    public void WithPadding(int padding)
    {
        Padding = padding;
    }

    public void WithFileSymbols(string symbols)
    {
        FileSymbols = symbols;
    }

    public void WithDirectorySymbols(string symbols)
    {
        DirectorySymbols = symbols;
    }

    public void WithIdentation(char symbol)
    {
        Identation = symbol;
    }
}