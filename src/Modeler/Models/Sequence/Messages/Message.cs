using Modeler.Models.Messaging;
using Modeler.Models.RestApi;
using Modeler.Models.Sequence.Messages.Types;
using Modeler.Models.Sequence.Participants;

namespace Modeler.Models.Sequence.Messages;

public class Message
{
    public Message(string name, ISequenceParticipant sender, ISequenceParticipant receiver, string? content, MessageType type)
    {
        Name = name;
        Sender = sender;
        Receiver = receiver;
        Content = content;
        Type = type;
    }

    public static Message FromEvent(ISequenceParticipant sender, IMessage message, ISequenceParticipant receiver)
    {
        return new Message(message.Name, sender, receiver, message.Name, new EventMessage());
    }
    
    public static Message RequestEndpointMessage(ISequenceParticipant sender, Endpoint endpoint, ISequenceParticipant receiver)
    {
        string? content = null;
        if (endpoint.RequestModel != null)
        {
            content = endpoint.RequestModel.Name;
        }
        
        return new Message(endpoint.Name, sender, receiver, content, new SynchronousRequestMessage());
    }
    
    public static Message ResponseEndpointMessage(ISequenceParticipant sender, Endpoint endpoint, ISequenceParticipant receiver)
    {
        string? content = null;
        if (endpoint.ResponseModel != null)
        {
            content = endpoint.ResponseModel.Name;
        }
        
        return new Message(endpoint.Name, sender, receiver, content, new SynchronousResponseMessage());
    }

    public string Name { get; }
    
    public ISequenceParticipant Sender { get; }
    
    public ISequenceParticipant Receiver { get; }
    
    public MessageType Type { get; }
    
    public string? Content { get; }
}