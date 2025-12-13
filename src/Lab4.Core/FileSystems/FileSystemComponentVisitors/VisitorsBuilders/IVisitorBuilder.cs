using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors.VisitorsBuilders;

public interface IVisitorBuilder
{
    int Depth { get; }

    string FileSymbols { get; }

    string DirectorySymbols { get; }

    char Identation { get; }

    IWriter Writer { get; }

    void WithDepth(int padding);

    void WithFileSymbols(string symbols);

    void WithDirectorySymbols(string symbols);

    void WithIdentation(char symbol);

    void WithWriter(IWriter writer);

    IFileSystemComponentVisitor Build()
    {
        return new FormatingVisitor(Depth, new VIsitorData(FileSymbols, DirectorySymbols, Identation), Writer);
    }
}