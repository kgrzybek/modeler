using Modeler.Models.Sequence.Participants;
using Modeler.Samples.HR.Sequences.ParticipantTypes;
using Modeler.Views.Sequence.Diagram.Shared;

namespace Modeler.Samples.HR.Sequences.Views.SequenceDiagrams.Layouts;

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