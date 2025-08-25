using Modeler.ComponentsModel;
using Modeler.Full.Sample.Components.Types;
using Modeler.Full.Sample.Sequences.ParticipantTypes;
using Modeler.Messaging;
using Modeler.SequenceModel;
using Modeler.SequenceModel.Participants;

namespace Modeler.Full.Sample.Components.ExternalSystems;

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