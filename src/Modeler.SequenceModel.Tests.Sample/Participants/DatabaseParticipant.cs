using Modeler.SequenceModel.Tests.Sample.ParticipantTypes;

namespace Modeler.SequenceModel.Tests.Sample.Participants;

public class DatabaseParticipant : Participant
{
    public static Participant Create() => new DatabaseParticipant()
        .WithName("Database")
        .OfType(new Database());
}