using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters;

public class FileFormater : IFormater
{
    private readonly FileName _fileName;

    public FileFormater(string filePath)
    {
        _fileName = new FileName(filePath);
    }

    public void AddHead(Message msg)
    {
        File.AppendAllText(_fileName.Value, $"# {msg.Head.Value}\n");
    }

    public void AddBody(Message msg)
    {
        File.AppendAllText(_fileName.Value, $"# {msg.Body.Value}\n");
    }
}
