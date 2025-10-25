using Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

public class TextNotificationSystem : INotificationSystem
{
    private readonly TextNotice _textNotice;

    public TextNotificationSystem()
    {
        _textNotice = new TextNotice("Achtung Achtung");
    }

    public void Notice()
    {
        Console.WriteLine(_textNotice.Value);
    }
}