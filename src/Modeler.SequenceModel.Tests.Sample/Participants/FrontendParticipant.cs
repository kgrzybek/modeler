namespace Modeler.SequenceModel.Tests.Sample.Participants;

public class FrontendParticipant : Participant
{
    public static Participant Create() => new FrontendParticipant()
        .WithName("Frontend")
        .OfType(new System());
}