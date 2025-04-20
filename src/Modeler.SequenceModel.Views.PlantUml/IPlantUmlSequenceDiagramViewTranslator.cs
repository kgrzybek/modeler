namespace Modeler.SequenceModel.Views.PlantUml;

public interface IPlantUmlSequenceDiagramViewTranslator
{
    public string TranslateMessageParameters(MessageParameters messageParameters);
    
    public string TranslateParticipantType(ParticipantType participantType);
    
    public string TranslateParticipantStereoType(ParticipantType participantType);
}