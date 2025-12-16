using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors;

public class FormatingVisitor : IFileSystemComponentVisitor
{
    private readonly int _depth;

    private readonly VIsitorData _data;

    private readonly IWriter _writer;

    public FormatingVisitor(int depth, VIsitorData data, IWriter writer)
    {
        _depth = depth;
        _data = data;
        _writer = writer;
    }

    public void Visit(FileFileSystemComponent component)
    {
        _writer.Write($"{new string(' ', _depth) + _data.FileSymbols} {component.Name}");
    }

    public void Visit(DirectoryFileSystemComponent component)
    {
        _writer.Write($"{new string(_data.Identation, component.Depth) + _data.DirectorySymbols} {component.Name}/");
        while (component.HasNextcomponent())
        {
            if (component.Depth > _depth) break;
            IFileSystemComponent currComponent = component.GetNextComponent();
            if (currComponent is DirectoryFileSystemComponent)
            {
                _writer.Write($"{new string(_data.Identation, component.Depth) + _data.DirectorySymbols} {currComponent.Name}/");
            }
            else
            {
                _writer.Write($"{new string(_data.Identation, component.Depth) + _data.FileSymbols} {currComponent.Name}/");
            }
        }
    }
}