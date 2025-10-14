using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formaters.Formaters;

public interface IFormater
{
    string FormatHead(Message msg);

    string FormatBody(Message msg);
}