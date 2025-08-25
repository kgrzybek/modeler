using Modeler.SequenceModel.Participants;

namespace Modeler.SequenceModel.Views.Shared;

public interface ISequenceDiagramViewTranslator
{
    public string TranslateParticipantType(ParticipantType participantType);
    
    public string TranslateParticipantStereoType(ParticipantType participantType);
}