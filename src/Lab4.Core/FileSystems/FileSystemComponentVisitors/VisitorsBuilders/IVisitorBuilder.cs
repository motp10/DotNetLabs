using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors.VisitorsBuilders;

public interface IVisitorBuilder
{
    int Depth { get; }

    IWriter Writer { get; }

    void WithDepth(int padding);

    void WithWriter(IWriter writer);

    void WithData(VIsitorData data);

    IFileSystemComponentVisitor Build();
}