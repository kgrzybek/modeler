using Models.Elements;

namespace Modeler.SequenceModel;

public abstract class Sequence : IElement
{
    private List<ISequenceParticipant> _participants;
    
    private List<Message> _messages;
    
    public string Name { get; private set; }
    public string Id { get; private set; }

    protected Sequence()
    {
        _participants = new List<ISequenceParticipant>();
        _messages = new List<Message>();
        Name = string.Empty;
        Id = string.Empty;
    }

    public List<ISequenceParticipant> GetParticipants()
    {
        return _participants;
    }
    
    public List<Message> GetMessages()
    {
        return _messages;
    }

    internal void SetParticipants(List<ISequenceParticipant> participants)
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
        Id = ElementIdGenerator.GenerateElementId(this.GetType(), Name);
    }
}