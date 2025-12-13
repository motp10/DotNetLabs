using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors;

public class FormatingVisitor : IFileSystemComponentVisitor
{
    private readonly StringBuilder _builder = new StringBuilder();

    private readonly int _depth;

    private readonly VIsitorData _data;

    private readonly IWriter _writer;

    public string Value => _builder.ToString();

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
        int currentDepth = 0;
        while (currentDepth < _depth)
        {
            _writer.Write($"{new string(_data.Identation, currentDepth) + _data.DirectorySymbols} {component.Name}/");
            ++currentDepth;
            while (component.HasNextcomponent())
            {
                IFileSystemComponent currComponent = component.GetNextComponent();
                if (currComponent is DirectoryFileSystemComponent)
                {
                    _writer.Write($"{new string(_data.Identation, currentDepth) + _data.DirectorySymbols} {currComponent.Name}/");
                }
                else
                {
                    _writer.Write($"{new string(_data.Identation, currentDepth) + _data.FileSymbols} {currComponent.Name}/");
                }
            }
        }
    }
}