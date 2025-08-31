using Modeler.Models.Sequence.Participants;

namespace Modeler.Views.Sequence.Diagram.Shared;

public interface ISequenceDiagramViewTranslator
{
    public string TranslateParticipantType(ParticipantType participantType);
    
    public string TranslateParticipantStereoType(ParticipantType participantType);
}