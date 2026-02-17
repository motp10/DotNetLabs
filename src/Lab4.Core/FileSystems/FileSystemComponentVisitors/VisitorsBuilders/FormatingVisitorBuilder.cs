using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors.VisitorsBuilders;

public class FormatingVisitorBuilder : IVisitorBuilder
{
    private VIsitorData? _data;

    public int Depth { get; private set; }

    public IWriter Writer { get; private set; }

    public IComponentsIterator? Iterator { get; private set; }

    public FormatingVisitorBuilder()
    {
        Depth = -1;
        _data = null;
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

    public void WithData(VIsitorData data)
    {
        _data = data;
    }

    public void WithWriter(IWriter writer)
    {
        Writer = writer;
    }

    public void WithIterator(IComponentsIterator iterator)
    {
        Iterator = iterator;
    }

    public IFileSystemComponentVisitor Build()
    {
        if (_data == null)
        {
            throw new Exception("Data is null");
        }

        if (Iterator == null) throw new Exception("Iterator is null");
        return new FormatingVisitor(Depth, _data, Writer, Iterator);
    }
}