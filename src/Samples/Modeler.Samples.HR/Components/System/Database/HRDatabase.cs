using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Components;
using Modeler.Models.Sequence.Participants;
using Modeler.Samples.HR.Components.Types;

namespace Modeler.Samples.HR.Components.System.Database;

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