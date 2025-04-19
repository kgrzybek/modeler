namespace Modeler.SequenceModel.Views.PlantUml;

public class SequenceDiagramView
{
    public SequenceDiagramView(
        string id,
        Sequence sequence,
        IDictionary<Type, int> participantsOrder,
        bool autonumberMessages = false)
    {
        Id = id;
        Sequence = sequence;
        ParticipantsOrder = participantsOrder;
        AutonumberMessages = autonumberMessages;
    }
    
    public string Id { get; }

    public Sequence Sequence { get; }
    
    public bool AutonumberMessages { get; }

    public IDictionary<Type, int> ParticipantsOrder { get; }
}