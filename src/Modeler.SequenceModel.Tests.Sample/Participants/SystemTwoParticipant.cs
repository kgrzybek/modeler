namespace Modeler.SequenceModel.Tests.Sample.Participants;

public class SystemTwoParticipant : Participant
{
    public static Participant Create() => new SystemTwoParticipant()
        .WithName("SystemTwo")
        .OfType(new System());
}