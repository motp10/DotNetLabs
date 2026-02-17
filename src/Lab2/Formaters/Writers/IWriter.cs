namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters.Writers;

public interface IWriter
{
    void WriteHead(string text);

    void WriteBody(string text);
}