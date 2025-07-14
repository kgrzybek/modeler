using Modeler.SequenceModel;

namespace Modeler.Full.Sample.Sequences.ParticipantTypes;

public class ExternalSystem : ParticipantType
{
    public static ExternalSystem Create() => new ExternalSystem();
}