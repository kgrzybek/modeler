

namespace Modeler.SequenceModel.Tests.Sample.Participants;

public class OtherParticipant : Participant
{
    public static Participant Create() => new OtherParticipant()
        .WithName("Other")
        .OfType(new System());
}