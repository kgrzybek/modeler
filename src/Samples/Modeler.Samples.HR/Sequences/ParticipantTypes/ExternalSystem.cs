using Modeler.Models.Sequence.Participants;

namespace Modeler.Samples.HR.Sequences.ParticipantTypes;

public class ExternalSystem : ParticipantType
{
    public static ExternalSystem Create() => new ExternalSystem();
}