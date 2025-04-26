namespace Modeler.SequenceModel.Sample.Models.Participants;

public class BackendParticipant : Participant
{
    public static Participant Create() => new BackendParticipant()
        .WithName("Backend")
        .OfType(new ParticipantTypes.System());
}