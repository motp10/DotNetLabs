using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponents;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemComponentVisitors;

public class FormatingVisitor : IFileSystemComponentVisitor
{
    private readonly StringBuilder _builder = new StringBuilder();

    private readonly int _depth;

    private readonly string _fileSymbols;

    private readonly string _directorySymbols;

    private readonly char _identation;

    public string Value => _builder.ToString();

    public FormatingVisitor(int depth, char identation, string fileSymbols, string directorySymbols)
    {
        _depth = depth;
        _fileSymbols = fileSymbols;
        _directorySymbols = directorySymbols;
        _identation = identation;
    }

    public void Visit(FileFileSystemComponent component)
    {
        Console.WriteLine($"{new string(' ', _depth * 4) + _fileSymbols} {component.Name}");
    }

    public void Visit(DirectoryFileSystemComponent component)
    {
        int currentDepth = 0;
        while (currentDepth < _depth)
        {
            Console.WriteLine($"{new string(_identation, currentDepth * 4) + _directorySymbols} {component.Name}/");
            ++currentDepth;
            while (component.HasNextcomponent())
            {
                IFileSystemComponent currComponent = component.GetNextComponent();
                if (currComponent is DirectoryFileSystemComponent)
                {
                    Console.WriteLine($"{new string(_identation, currentDepth * 4) + _directorySymbols} {currComponent.Name}/");
                }
                else
                {
                    Console.WriteLine($"{new string(_identation, currentDepth * 4) + _fileSymbols} {currComponent.Name}/");
                }
            }
        }
    }
}