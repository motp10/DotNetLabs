using Itmo.ObjectOrientedProgramming.Lab2.Formaters.Formaters;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters.Writers;

public class FileWriter : IWriter
{
    private readonly IFormater _formater;

    private readonly FileName _fileName;

    public FileWriter(string filePath, IFormater formater)
    {
        _fileName = new FileName(filePath);
        _formater = formater;
    }

    public void WriteHead(Message msg)
    {
        File.AppendAllText(_fileName.Value, _formater.FormatHead(msg));
    }

    public void WriteBody(Message msg)
    {
        File.AppendAllText(_fileName.Value, _formater.FormatBody(msg));
    }
}