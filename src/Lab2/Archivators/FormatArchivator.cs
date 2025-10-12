using Itmo.ObjectOrientedProgramming.Lab2.Formaters;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivators;

public class FormatArchivator : IArchivator
{
    private readonly IFormater _formater;

    public FormatArchivator(IFormater formater)
    {
        _formater = formater;
    }

    public void WriteMessage(Message msg)
    {
        _formater.AddHead(msg);
        _formater.AddBody(msg);
    }
}