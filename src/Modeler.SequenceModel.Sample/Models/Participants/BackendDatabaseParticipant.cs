using Modeler.SequenceModel.Sample.Models.ParticipantTypes;

namespace Modeler.SequenceModel.Sample.Models.Participants;

public class BackendDatabaseParticipant : Participant
{
    public static Participant Create() => new BackendDatabaseParticipant()
        .WithName("Backend Database")
        .OfType(new Database());
}