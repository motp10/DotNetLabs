using Itmo.ObjectOrientedProgramming.Lab2.Formaters.Writers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivators;

public class FormatArchivator : IArchivator
{
    private readonly IWriter _formater;

    public FormatArchivator(IWriter formater)
    {
        _formater = formater;
    }

    public void WriteMessage(Message msg)
    {
        _formater.WriteHead(msg);
        _formater.WriteBody(msg);
    }
}