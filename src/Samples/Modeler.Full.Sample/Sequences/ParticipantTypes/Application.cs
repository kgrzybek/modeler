using Modeler.SequenceModel;
using Modeler.SequenceModel.Participants;

namespace Modeler.Full.Sample.Sequences.ParticipantTypes;

public class Application : ParticipantType
{
    public static Application Create() => new Application();
}