

namespace Modeler.SequenceModel.Sample.Models.Participants;

public class OtherParticipant : Participant
{
    public static Participant Create() => new OtherParticipant()
        .WithName("Other")
        .OfType(new ParticipantTypes.System());
}