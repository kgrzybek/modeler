namespace Modeler.Models.Messaging;

public class PublishedMessage
{
    public PublishedMessage(IMessagesPublisher publisher, IQueue queue, IMessage message)
    {
        Publisher = publisher;
        Queue = queue;
        Message = message;
    }

    public IMessagesPublisher Publisher { get; }
    public IQueue Queue { get; }
    public IMessage Message { get; }
}