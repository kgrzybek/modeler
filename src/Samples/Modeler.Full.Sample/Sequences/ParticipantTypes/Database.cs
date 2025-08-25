using Modeler.SequenceModel;
using Modeler.SequenceModel.Participants;

namespace Modeler.Full.Sample.Sequences.ParticipantTypes;

public class Database : ParticipantType
{
    public static Database Create() => new Database();
}