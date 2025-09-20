using Modeler.Models.Common.Elements;
using Modeler.Models.Components;

namespace Modeler.Models.Messaging;

public abstract class BrokerComponent : Component
{
    private readonly List<IQueue> _queues;

    private readonly List<PublishedMessage> _publishedMessages;

    private readonly List<SubscribedMessage> _subscribedMessages;

    protected BrokerComponent(ModelElementsRegistry elementsRegistry, string name, ComponentType type) : base(name, type)
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