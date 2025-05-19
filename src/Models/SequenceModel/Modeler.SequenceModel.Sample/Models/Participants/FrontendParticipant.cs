using Modeler.ComponentsModel.Sample.Components.HRSystem.Frontend;

namespace Modeler.SequenceModel.Sample.Models.Participants;

public class FrontendParticipant : Participant
{
    public static Participant Create() => new FrontendParticipant()
        .WithName(HRFrontendApplication.ComponentName)
        .OfType(new ParticipantTypes.Application());
}