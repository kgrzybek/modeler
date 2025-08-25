using Modeler.ComponentsModel;
using Modeler.Full.Sample.Components.Types;
using Modeler.SequenceModel;
using Modeler.SequenceModel.Participants;
using Models.Elements;

namespace Modeler.Full.Sample.Components.System.Database;

public class HRDatabase : Component, ISequenceParticipant
{
    public static IElement Create()
    {
        return new HRDatabase();
    }
    
    public const string ComponentName = "HR Database";
    
    public HRDatabase() : base(ComponentName, new DatabaseComponentType())
    {
        ParticipantType = new Sequences.ParticipantTypes.Database();
    }

    public ParticipantType ParticipantType { get; }
}