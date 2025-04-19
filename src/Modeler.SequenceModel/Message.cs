namespace Modeler.SequenceModel;

public class Message
{
    public Message(string name, Participant sender, Participant receiver, MessageParameters parameters)
    {
        Name = name;
        Sender = sender;
        Receiver = receiver;
        Parameters = parameters;
    }

    public string Name { get; }
    
    public Participant Sender { get; }
    
    public Participant Receiver { get; }
    
    public MessageParameters Parameters { get; }
}