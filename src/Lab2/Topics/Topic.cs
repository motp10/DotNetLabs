using Itmo.ObjectOrientedProgramming.Lab2.Destinations;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Topics.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Topics;

public class Topic
{
    public TopicName TopicName { get; }

    private readonly IReadOnlyCollection<IDestination> _destinations;

    public Topic(TopicName topicName, IReadOnlyCollection<IDestination> destinations)
    {
        TopicName = topicName;
        _destinations = destinations;
    }

    public void SendMessage(Message message)
    {
        foreach (IDestination destination in _destinations)
        {
            destination.Recieve(message);
        }
    }
}