using Modeler.Models.Sequence.Participants;

namespace Modeler.Views.Sequence.Diagram.Shared;

public interface ISequenceDiagramViewLayout
{
    public string GetParticipantColor(ParticipantType participantType);
}