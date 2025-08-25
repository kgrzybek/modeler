using Modeler.SequenceModel;
using Modeler.SequenceModel.Participants;

namespace Modeler.Full.Sample.Sequences.ParticipantTypes;

public class Actor : ParticipantType
{
    public static Actor Create() => new Actor();
}