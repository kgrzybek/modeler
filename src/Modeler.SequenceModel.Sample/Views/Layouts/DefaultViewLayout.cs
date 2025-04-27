using Modeler.SequenceModel.Sample.Models.ParticipantTypes;
using Modeler.SequenceModel.Views.Shared;

namespace Modeler.SequenceModel.Sample.Views.Layouts;

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