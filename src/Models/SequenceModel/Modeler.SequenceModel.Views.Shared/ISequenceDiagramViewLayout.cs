using Modeler.SequenceModel.Participants;

namespace Modeler.SequenceModel.Views.Shared;

public interface ISequenceDiagramViewLayout
{
    public string GetParticipantColor(ParticipantType participantType);
}