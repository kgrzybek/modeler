using Modeler.SequenceModel.Tests.Sample.ParticipantTypes;

namespace Modeler.SequenceModel.Tests.Sample.Participants;

public class CrmParticipant : Participant
{
    public static Participant Create() => new CrmParticipant()
        .WithName("CRM")
        .OfType(new ExternalSystem());
}