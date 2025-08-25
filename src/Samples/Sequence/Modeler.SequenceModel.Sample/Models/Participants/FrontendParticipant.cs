using Modeler.ComponentsModel.Sample.Components.HRSystem.Frontend;
using Modeler.SequenceModel.Participants;

namespace Modeler.SequenceModel.Sample.Models.Participants;

public class FrontendParticipant : Participant
{
    public static Participant Create() => new FrontendParticipant()
        .WithName(HRFrontendApplication.ComponentName)
        .OfType(new ParticipantTypes.Application());
}