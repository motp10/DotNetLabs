namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters.Writers;

public class FileWriter : IWriter
{
    private readonly FileName _fileName;

    public FileWriter(string filePath)
    {
        _fileName = new FileName(filePath);
    }

    public void WriteHead(string text)
    {
        File.AppendAllText(_fileName.ToString(), $"{text}\n");
    }

    public void WriteBody(string text)
    {
        File.AppendAllText(_fileName.ToString(), $"{text}\n");
    }
}