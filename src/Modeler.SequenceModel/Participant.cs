namespace Modeler.SequenceModel;

public abstract class Participant
{
    public ParticipantType Type { get; set; }
    
    public string Name { get; set; }
    
    public string Id { get; set; }
    
    protected Participant WithName(
        string name)
    {
        this.Name = name;

        this.Id = this.Name.Replace(" ", "_").Trim().ToLower();

        return this;
    }
    
    public Participant OfType(
        ParticipantType type)
    {
        this.Type = type;

        return this;
    }
}