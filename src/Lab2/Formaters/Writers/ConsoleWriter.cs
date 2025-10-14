using Itmo.ObjectOrientedProgramming.Lab2.Formaters.Formaters;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters.Writers;

public class ConsoleWriter : IWriter
{
    private readonly IFormater _formater;

    public ConsoleWriter(IFormater formater)
    {
        _formater = formater;
    }

    public void WriteHead(Message msg)
    {
        Console.WriteLine(_formater.FormatHead(msg));
    }

    public void WriteBody(Message msg)
    {
        Console.WriteLine(_formater.FormatBody(msg));
    }
}