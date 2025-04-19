namespace Modeler.SequenceModel;

public class Message
{
    public Message(string name, Participant sender, Participant receiver, MessageParameters parameters, MessageType type)
    {
        Name = name;
        Sender = sender;
        Receiver = receiver;
        Parameters = parameters;
        Type = type;
    }

    public string Name { get; }
    
    public Participant Sender { get; }
    
    public Participant Receiver { get; }
    
    public MessageParameters Parameters { get; }
    
    public MessageType Type { get; }
}

public abstract class MessageType {

}

public class SynchronousRequestMessage : MessageType {}

public class SynchronousResponseMessage : MessageType {}

public class SelfMessage : MessageType {}