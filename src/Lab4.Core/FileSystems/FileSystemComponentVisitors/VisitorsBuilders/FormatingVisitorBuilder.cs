using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors.VisitorsBuilders;

public class FormatingVisitorBuilder : IVisitorBuilder
{
    public int Depth { get; private set; }

    public string FileSymbols { get; private set; }

    public string DirectorySymbols { get; private set; }

    public char Identation { get; private set; }

    public IWriter Writer { get; private set; }

    public FormatingVisitorBuilder()
    {
        Depth = -1;
        FileSymbols = string.Empty;
        DirectorySymbols = string.Empty;
        Identation = ' ';
        Writer = new ConsoleWriter();
    }

    public void WithDepth(int padding)
    {
        Depth = padding;
    }

    public void WithPadding(int padding)
    {
        throw new NotImplementedException();
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

    public void WithWriter(IWriter writer)
    {
        Writer = writer;
    }
}