namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors.VisitorsBuilders;

public interface IVisitorBuilder
{
    int Padding { get; }

    string FileSymbols { get; }

    string DirectorySymbols { get; }

    char Identation { get; }

    void WithPadding(int padding);

    void WithFileSymbols(string symbols);

    void WithDirectorySymbols(string symbols);

    void WithIdentation(char symbol);

    IFileSystemComponentVisitor Build()
    {
        return new FormatingVisitor(Padding, Identation, FileSymbols,  DirectorySymbols);
    }
}