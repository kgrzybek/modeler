namespace Modeler.SequenceModel.Tests.Sample.Participants;

public class UserParticipant : Participant
{
    public static Participant Create() => new UserParticipant()
        .WithName("Employee")
        .OfType(new Actor());
}