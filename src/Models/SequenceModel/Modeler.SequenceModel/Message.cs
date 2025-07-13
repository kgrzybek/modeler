namespace Modeler.SequenceModel;

public class Message
{
    public Message(string name, ISequenceParticipant sender, ISequenceParticipant receiver, MessageParameters parameters, MessageType type)
    {
        Name = name;
        Sender = sender;
        Receiver = receiver;
        Parameters = parameters;
        Type = type;
    }

    public string Name { get; }
    
    public ISequenceParticipant Sender { get; }
    
    public ISequenceParticipant Receiver { get; }
    
    public MessageParameters Parameters { get; }
    
    public MessageType Type { get; }
}

public abstract class MessageType {

}

public class SynchronousRequestMessage : MessageType {}

public class SynchronousResponseMessage : MessageType {}

public class EventMessage : MessageType {}

public class SelfMessage : MessageType {}