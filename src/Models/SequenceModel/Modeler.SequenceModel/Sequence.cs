namespace Modeler.SequenceModel;

public abstract class Sequence
{
    private List<Participant> _participants;
    
    private List<Message> _messages;
    
    public string Name { get; private set; }

    protected Sequence()
    {
        _participants = new List<Participant>();
        _messages = new List<Message>();
        Name = string.Empty;
    }

    public List<Participant> GetParticipants()
    {
        return _participants;
    }
    
    public List<Message> GetMessages()
    {
        return _messages;
    }

    internal void SetParticipants(List<Participant> participants)
    {
        _participants = participants;
    }
    
    internal void SetMessages(List<Message> messages)
    {
        _messages = messages;
    }

    internal void SetName(string name)
    {
        Name = name;
    }
}