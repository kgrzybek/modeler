namespace Modeler.SequenceModel;

public class SequenceBuilder<T> where T : Sequence, new()
{
    private readonly string _sequenceName;
    private readonly List<Message> _messages;

    public SequenceBuilder(string name)
    {
        _sequenceName = name;
        _messages = new List<Message>();
    }
    
    public void AddSynchronousRequestMessage(Participant sender, string name, MessageParameters parameters, Participant recipient)
    {
        var message = new Message(name, sender, recipient, parameters, new SynchronousRequestMessage());
        _messages.Add(message);
    }
    
    public void AddSynchronousResponseMessage(Participant sender, string name, MessageParameters parameters, Participant recipient)
    {
        var message = new Message(name, sender, recipient, parameters, new SynchronousResponseMessage());
        _messages.Add(message);
    }

    public T Build()
    {
        var participants = new List<Participant>();
        participants.AddRange(_messages.Select(x => x.Sender).ToList());
        participants.AddRange(_messages.Select(x => x.Receiver).ToList());

        var sequence = new T();
        sequence.SetParticipants(participants.Distinct().ToList());
        sequence.SetName(_sequenceName);
        sequence.SetMessages(_messages);

        return sequence;
    }
}