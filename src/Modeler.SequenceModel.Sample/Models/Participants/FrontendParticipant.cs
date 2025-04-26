namespace Modeler.SequenceModel.Sample.Models.Participants;

public class FrontendParticipant : Participant
{
    public static Participant Create() => new FrontendParticipant()
        .WithName("Frontend")
        .OfType(new ParticipantTypes.System());
}