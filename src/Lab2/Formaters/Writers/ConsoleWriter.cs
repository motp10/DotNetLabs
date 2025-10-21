namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters.Writers;

public class ConsoleWriter : IWriter
{
    public void Write(string str)
    {
        Console.WriteLine(str);
    }
}