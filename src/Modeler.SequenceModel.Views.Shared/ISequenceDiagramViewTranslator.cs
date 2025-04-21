namespace Modeler.SequenceModel.Views.Shared;

public interface ISequenceDiagramViewTranslator
{
    public string TranslateMessageParameters(MessageParameters messageParameters);
    
    public string TranslateParticipantType(ParticipantType participantType);
    
    public string TranslateParticipantStereoType(ParticipantType participantType);
}