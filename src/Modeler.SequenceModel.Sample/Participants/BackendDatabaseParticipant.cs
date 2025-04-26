using Modeler.SequenceModel.Tests.Sample.ParticipantTypes;

namespace Modeler.SequenceModel.Tests.Sample.Participants;

public class BackendDatabaseParticipant : Participant
{
    public static Participant Create() => new BackendDatabaseParticipant()
        .WithName("Backend Database")
        .OfType(new Database());
}