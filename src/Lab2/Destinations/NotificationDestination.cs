using Itmo.ObjectOrientedProgramming.Lab2.Destinations.Cencorators;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.NotificationSystems;

namespace Itmo.ObjectOrientedProgramming.Lab2.Destinations;

public class NotificationDestination : IDestination
{
    private readonly INotificationSystem _notificationSystem;

    private readonly ICensorator _censorator;

    public NotificationDestination(INotificationSystem notificationSystem, ICensorator censorator)
    {
        _notificationSystem = notificationSystem;
        _censorator = censorator;
    }

    public void Recieve(Message message)
    {
        if (_censorator.CheckMessage(message))
        {
            _notificationSystem.Notice();
        }
    }
}