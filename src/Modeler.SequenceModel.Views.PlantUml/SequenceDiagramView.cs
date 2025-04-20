namespace Modeler.SequenceModel.Views.PlantUml;

public class SequenceDiagramView
{
    public SequenceDiagramView(
        string id,
        Sequence sequence,
        List<Participant> participantsToShow,
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

    public List<Participant> ParticipantsToShow { get; }
}