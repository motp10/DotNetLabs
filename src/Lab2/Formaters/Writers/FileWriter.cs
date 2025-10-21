namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters.Writers;

public class FileWriter : IWriter
{
    private readonly FileName _fileName;

    public FileWriter(string filePath)
    {
        _fileName = new FileName(filePath);
    }

    public void Write(string str)
    {
        File.AppendAllText(_fileName.Value, str);
    }
}