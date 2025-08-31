using Modeler.Models.Components;
using Modeler.Models.Messaging;
using Modeler.Models.Sequence.Participants;
using Modeler.Samples.HR.Components.Types;
using Modeler.Samples.HR.Sequences.ParticipantTypes;

namespace Modeler.Samples.HR.Components.ExternalSystems;

public class CRM : Component, ISequenceParticipant, IMessagesSubscriber
{
    public const string ComponentName = "CRM";
    
    public static Component Create() => new CRM();
    
    private CRM() : base(ComponentName, new ExternalSystemComponentType())
    {
        ParticipantType = new ExternalSystem();
    }

    public ParticipantType ParticipantType { get; }
}