using Models.Elements;

namespace Modeler.Messaging;

public abstract class BrokerModel : IModel
{
    private readonly List<IQueue> _queues;

    private readonly List<PublishedMessage> _publishedMessages;

    private readonly List<SubscribedMessage> _subscribedMessages;

    public BrokerModel(ModelElementsRegistry elementsRegistry)
    {
        _queues = elementsRegistry.GetElements<IQueue>();
        _publishedMessages = new List<PublishedMessage>();
        _subscribedMessages = new List<SubscribedMessage>();
    }

    protected void PublishMessage(IMessagesPublisher publisher, IQueue queue, IMessage message)
    {
        _publishedMessages.Add(new PublishedMessage(publisher, queue, message));
    }

    protected void SubscribeToMessage(IMessagesSubscriber publisher, IQueue queue, IMessage message)
    {
        _subscribedMessages.Add(new SubscribedMessage(publisher, queue, message));
    }

    protected void AddQueue(IQueue queue)
    {
        _queues.Add(queue);
    }

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

    public List<IMessage> GetAllMessages()
    {
        var allMessages = _subscribedMessages.Select(x => x.Message).ToList();
        allMessages.AddRange(_publishedMessages.Select(x => x.Message));

        return allMessages.Distinct().ToList();
    }

    public List<IMessagesPublisher> GetPublishers(IMessage message)
    {
        return _publishedMessages.Where(x => x.Message == message)
            .Select(x => x.Publisher)
            .ToList();
    }
    
    public List<IMessagesSubscriber> GetSubscribers(IMessage message)
    {
        return _subscribedMessages.Where(x => x.Message == message)
            .Select(x => x.Subscriber)
            .ToList();
    }
}