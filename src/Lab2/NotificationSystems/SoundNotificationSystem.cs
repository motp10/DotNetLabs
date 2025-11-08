namespace Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

public class SoundNotificationSystem : INotificationSystem
{
    public void Notice()
    {
        Console.Beep();
    }
}