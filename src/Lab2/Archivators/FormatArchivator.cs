using Itmo.ObjectOrientedProgramming.Lab2.Formaters.FormatersDecorators;
using Itmo.ObjectOrientedProgramming.Lab2.Formaters.Writers;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Archivators;

public class FormatArchivator : IArchivator
{
    private readonly FormaterDecorator _formater;

    public FormatArchivator(IWriter writer)
    {
        _formater = new FormaterDecorator(writer);
    }

    public void WriteMessage(Message msg)
    {
        _formater.Write(msg.Head.Value);
    }
}