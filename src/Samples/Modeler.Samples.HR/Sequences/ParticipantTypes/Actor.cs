using Modeler.Models.Sequence.Participants;

namespace Modeler.Samples.HR.Sequences.ParticipantTypes;

public class Actor : ParticipantType
{
    public static Actor Create() => new Actor();
}