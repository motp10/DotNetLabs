using Itmo.ObjectOrientedProgramming.Lab2.Formaters.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters.FormatersDecorators;

public class Formater : IWriter
{
    private readonly IWriter _writer;

    public Formater(IWriter writer)
    {
        _writer = writer;
    }

    public void WriteHead(string text)
    {
        string new_str = $"# {text}\n";
        _writer.WriteHead($"# {new_str}\n");
    }

    public void WriteBody(string text)
    {
        string new_str = $" {text}\n";
        _writer.WriteBody($" {new_str}\n");
    }
}