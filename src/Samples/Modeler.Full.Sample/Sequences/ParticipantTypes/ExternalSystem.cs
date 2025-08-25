using Modeler.SequenceModel;
using Modeler.SequenceModel.Participants;

namespace Modeler.Full.Sample.Sequences.ParticipantTypes;

public class ExternalSystem : ParticipantType
{
    public static ExternalSystem Create() => new ExternalSystem();
}