using Modeler.Models.Sequence.Participants;

namespace Modeler.Samples.HR.Sequences.ParticipantTypes;

public class Database : ParticipantType
{
    public static Database Create() => new Database();
}