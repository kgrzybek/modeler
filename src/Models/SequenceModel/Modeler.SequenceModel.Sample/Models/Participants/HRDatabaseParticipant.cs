using Modeler.SequenceModel.Sample.Models.ParticipantTypes;

namespace Modeler.SequenceModel.Sample.Models.Participants;

public class HRDatabaseParticipant : Participant
{
    public static Participant Create() => new HRDatabaseParticipant()
        .WithName("HR Database")
        .OfType(new Database());
}