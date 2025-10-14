using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters.Writers;

public interface IWriter
{
    void WriteHead(Message msg);

    void WriteBody(Message msg);
}