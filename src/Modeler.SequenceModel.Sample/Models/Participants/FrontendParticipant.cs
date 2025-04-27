namespace Modeler.SequenceModel.Sample.Models.Participants;

public class FrontendParticipant : Participant
{
    public static Participant Create() => new FrontendParticipant()
        .WithName("HR Frontend")
        .OfType(new ParticipantTypes.System());
}