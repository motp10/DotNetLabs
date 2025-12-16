using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors;

public class FormatingVisitor : IFileSystemComponentVisitor
{
    private const int _spacesCount = 5;
    private readonly int _depth;

    private readonly VIsitorData _data;

    private readonly IWriter _writer;

    private int _currDepth = 0;

    public FormatingVisitor(int depth, VIsitorData data, IWriter writer, IComponentsIterator iterator)
    {
        _depth = depth;
        _data = data;
        _writer = writer;
    }

    public void Visit(FileFileSystemComponent component)
    {
        _writer.Write($"{new string(' ', _currDepth * _spacesCount) + _data.FileSymbols} {component.Name}");
    }

    public void Visit(DirectoryFileSystemComponent component)
    {
        if (_currDepth >= _depth) return;

        _writer.Write($"{new string(' ', _currDepth * _spacesCount) + _data.DirectorySymbols} {component.Name}");

        IFileSystemComponent? newComponent = component.GiveSubComponents();

        ++_currDepth;

        while (newComponent != null)
        {
            newComponent.Accept(this);
            newComponent = component.GiveSubComponents();
        }

        --_currDepth;
    }
}