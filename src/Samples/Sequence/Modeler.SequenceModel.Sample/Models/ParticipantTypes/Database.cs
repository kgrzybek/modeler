using Modeler.SequenceModel.Participants;

namespace Modeler.SequenceModel.Sample.Models.ParticipantTypes;

public class Database : ParticipantType
{
    public static Database Create() => new Database();
}