using Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

public class TextNotificationSystem : INotificationSystem
{
    private readonly TextNotice _textNotice;

    public TextNotificationSystem(string text)
    {
        _textNotice = new TextNotice(text);
    }

    public void Notice()
    {
        Console.WriteLine(_textNotice.Value);
    }
}