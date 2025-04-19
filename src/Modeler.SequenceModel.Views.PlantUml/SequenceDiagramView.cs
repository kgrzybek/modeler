namespace Modeler.SequenceModel.Views.PlantUml;

public class SequenceDiagramView
{
    public SequenceDiagramView(
        string id,
        Sequence sequence)
    {
        Sequence = sequence;
        Id = id;
    }
    
    public string Id { get; }

    public Sequence Sequence { get; }
}