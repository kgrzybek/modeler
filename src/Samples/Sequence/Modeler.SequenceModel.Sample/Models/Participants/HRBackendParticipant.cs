using Modeler.ComponentsModel.Sample.Components.HRSystem.Backend;

namespace Modeler.SequenceModel.Sample.Models.Participants;

public class HRBackendParticipant : Participant
{
    public static Participant Create() => new HRBackendParticipant()
        .WithName(HRBackendApplication.ComponentName)
        .OfType(new ParticipantTypes.Application());
}