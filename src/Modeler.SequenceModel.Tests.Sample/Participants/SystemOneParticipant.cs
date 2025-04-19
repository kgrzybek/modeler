namespace Modeler.SequenceModel.Tests.Sample.Participants;

public class SystemOneParticipant : Participant
{
    public static Participant Create() => new SystemOneParticipant()
        .WithName("SystemOne")
        .OfType(new System());
}