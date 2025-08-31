namespace Modeler.Models.Messaging;

public class SubscribedMessage
{
    public SubscribedMessage(IMessagesSubscriber subscriber, IQueue queue, IMessage message)
    {
        Subscriber = subscriber;
        Queue = queue;
        Message = message;
    }

    public IMessagesSubscriber Subscriber { get; }
    public IQueue Queue { get; }
    public IMessage Message { get; }
}