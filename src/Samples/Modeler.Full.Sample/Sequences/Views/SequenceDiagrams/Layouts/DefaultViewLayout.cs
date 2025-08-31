using Modeler.Full.Sample.Sequences.ParticipantTypes;
using Modeler.SequenceModel;
using Modeler.SequenceModel.Participants;
using Modeler.Views.Sequence.Diagram.Shared;

namespace Modeler.Full.Sample.Sequences.Views.Layouts;

public class DefaultViewLayout : ISequenceDiagramViewLayout
{
    public string GetParticipantColor(ParticipantType participantType)
    {
        return participantType switch
        {
            Actor => string.Empty,
            Database => string.Empty,
            Application => string.Empty,
            ExternalSystem => "#FFD2BE",
            _ => throw new ArgumentException($"Invalid participant type {participantType}")
        };
    }
}