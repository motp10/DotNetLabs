using Itmo.ObjectOrientedProgramming.Lab2.Formaters.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters.FormatersDecorators;

public class FormaterDecorator
{
    private readonly IWriter _writer;

    public FormaterDecorator(IWriter writer)
    {
        _writer = writer;
    }

    public void Write(string str)
    {
        string new_str = $"# {str}\n";
        _writer.Write($"# {new_str}\n");
    }
}