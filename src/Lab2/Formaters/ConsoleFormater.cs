using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters;

public class ConsoleFormater : IFormater
{
    public void AddHead(Message msg)
    {
        Console.WriteLine(msg.Head);
    }

    public void AddBody(Message msg)
    {
        Console.WriteLine(msg.Body);
    }
}