namespace Modeler.SequenceModel.Views.Shared;

public class SequenceDiagramView
{
    public SequenceDiagramView(
        string id,
        Sequence sequence,
        List<ISequenceParticipant> participantsToShow,
        bool autonumberMessages = false)
    {
        Id = id;
        Sequence = sequence;
        ParticipantsToShow = participantsToShow;
        AutonumberMessages = autonumberMessages;
    }
    
    public string Id { get; }

    public Sequence Sequence { get; }
    
    public bool AutonumberMessages { get; }

    public List<ISequenceParticipant> ParticipantsToShow { get; }
}