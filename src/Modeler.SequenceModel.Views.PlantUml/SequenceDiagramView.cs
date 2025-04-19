namespace Modeler.SequenceModel.Views.PlantUml;

public class SequenceDiagramView
{
    public SequenceDiagramView(
        string id,
        Sequence sequence,
        bool autonumberMessages = false)
    {
        Id = id;
        Sequence = sequence;
        AutonumberMessages = autonumberMessages;
    }
    
    public string Id { get; }

    public Sequence Sequence { get; }
    
    public bool AutonumberMessages { get; }
}