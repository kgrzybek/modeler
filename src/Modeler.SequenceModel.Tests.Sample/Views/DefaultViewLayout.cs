using System.Drawing;
using Modeler.SequenceModel.Tests.Sample.ParticipantTypes;
using Modeler.SequenceModel.Views.PlantUml;

namespace Modeler.SequenceModel.Tests.Sample.Views;

public class DefaultViewLayout : IPlantUmlSequenceDiagramViewLayout
{
    public string GetParticipantColor(ParticipantType participantType)
    {
        return participantType switch
        {
            Actor => string.Empty,
            Database => string.Empty,
            ParticipantTypes.System => string.Empty,
            ExternalSystem => "#FFD2BE",
            _ => throw new ArgumentException($"Invalid participant type {participantType}")
        };
    }
}