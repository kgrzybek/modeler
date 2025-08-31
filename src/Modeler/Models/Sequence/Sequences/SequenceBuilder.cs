using Modeler.Models.Messaging;
using Modeler.Models.RestApi;
using Modeler.Models.Sequence.Messages;
using Modeler.Models.Sequence.Messages.Types;
using Modeler.Models.Sequence.Participants;

namespace Modeler.Models.Sequence.Sequences;

public class SequenceBuilder<T> where T : Sequence, new()
{
    private readonly string _sequenceName;
    private readonly List<Message> _messages;

    public SequenceBuilder(string name)
    {
        _sequenceName = name;
        _messages = new List<Message>();
    }
    
    public void AddSynchronousRequestMessage(ISequenceParticipant sender, string name, string content, ISequenceParticipant recipient)
    {
        var message = new Message(name, sender, recipient, content, new SynchronousRequestMessage());
        _messages.Add(message);
    }
    
    public void AddSynchronousRequestMessage(ISequenceParticipant sender, Endpoint endpoint, ISequenceParticipant recipient)
    {
        _messages.Add(Message.RequestEndpointMessage(sender, endpoint, recipient));
    }
    
    public void AddSelfMessage(ISequenceParticipant sender, string name, string content)
    {
        var message = new Message(name, sender, sender, content, new SelfMessage());
        _messages.Add(message);
    }
    
    public void AddSynchronousResponseMessage(ISequenceParticipant sender, string name, string content, ISequenceParticipant recipient)
    {
        var message = new Message(name, sender, recipient, content, new SynchronousResponseMessage());
        _messages.Add(message);
    }
    
    public void AddOkResponseMessage(ISequenceParticipant sender, string name, ISequenceParticipant recipient)
    {
        var message = new Message(name, sender, recipient, "OK" , new SynchronousResponseMessage());
        _messages.Add(message);
    }
    
    public void AddSynchronousResponseMessage(ISequenceParticipant sender, Endpoint endpoint, ISequenceParticipant recipient)
    {
        _messages.Add(Message.ResponseEndpointMessage(sender, endpoint, recipient));
    }
    
    public void AddEventMessage(ISequenceParticipant sender, string name, string content, ISequenceParticipant recipient)
    {
        var message = new Message(name, sender, recipient, content, new EventMessage());
        _messages.Add(message);
    }
    
    public void AddEventMessage(ISequenceParticipant sender, IMessage @event, ISequenceParticipant recipient)
    {
        _messages.Add(Message.FromEvent(sender, @event, recipient));
    }

    public T Build()
    {
        var participants = new List<ISequenceParticipant>();
        participants.AddRange(_messages.Select(x => x.Sender).ToList());
        participants.AddRange(_messages.Select(x => x.Receiver).ToList());

        var sequence = new T();
        sequence.SetParticipants(participants.Distinct().ToList());
        sequence.SetName(_sequenceName);
        sequence.SetMessages(_messages);

        return sequence;
    }
}