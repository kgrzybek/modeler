using Modeler.Models.Sequence.Participants;

namespace Modeler.Samples.HR.Sequences.ParticipantTypes;

public class Application : ParticipantType
{
    public static Application Create() => new Application();
}