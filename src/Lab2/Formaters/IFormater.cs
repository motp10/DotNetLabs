using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters;

public interface IFormater
{
    void AddHead(Message msg);

    void AddBody(Message msg);
}