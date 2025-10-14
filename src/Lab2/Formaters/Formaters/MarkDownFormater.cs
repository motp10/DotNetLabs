using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters.Formaters;

public class MarkDownFormater : IFormater
{
    public string FormatHead(Message msg)
    {
        return $"# {msg.Head.Value}\n";
    }

    public string FormatBody(Message msg)
    {
        return $"# {msg.Body.Value}\n";
    }
}