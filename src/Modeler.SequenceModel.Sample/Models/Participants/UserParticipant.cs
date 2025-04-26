using Modeler.SequenceModel.Sample.Models.ParticipantTypes;

namespace Modeler.SequenceModel.Sample.Models.Participants;

public class UserParticipant : Participant
{
    public static Participant Create() => new UserParticipant()
        .WithName("User")
        .OfType(new Actor());
}