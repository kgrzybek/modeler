using Modeler.SequenceModel.Tests.Sample.ParticipantTypes;

namespace Modeler.SequenceModel.Tests.Sample.Participants;

public class UserParticipant : Participant
{
    public static Participant Create() => new UserParticipant()
        .WithName("User")
        .OfType(new Actor());
}