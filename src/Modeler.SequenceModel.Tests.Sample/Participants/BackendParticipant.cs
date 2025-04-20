namespace Modeler.SequenceModel.Tests.Sample.Participants;

public class BackendParticipant : Participant
{
    public static Participant Create() => new BackendParticipant()
        .WithName("Backend")
        .OfType(new System());
}