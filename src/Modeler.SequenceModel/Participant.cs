namespace Modeler.SequenceModel;

public abstract class Participant
{
    public ParticipantType Type { get; set; }
    
    public string Name { get; set; }
    
    protected Participant WithName(
        string name)
    {
        this.Name = name;

        return this;
    }
    
    public Participant OfType(
        ParticipantType type)
    {
        this.Type = type;

        return this;
    }
}