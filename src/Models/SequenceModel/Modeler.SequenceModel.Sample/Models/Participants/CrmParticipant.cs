using Modeler.ComponentsModel.Sample.Components.ExternalSystems;
using Modeler.SequenceModel.Sample.Models.ParticipantTypes;

namespace Modeler.SequenceModel.Sample.Models.Participants;

public class CrmParticipant : Participant
{
    public static Participant Create() => new CrmParticipant()
        .WithName(CRM.ComponentName)
        .OfType(new ExternalSystem());
}