using Modeler.SequenceModel.Tests.Sample.Parameters;
using Modeler.SequenceModel.Tests.Sample.ParticipantTypes;
using Modeler.SequenceModel.Views.PlantUml;

namespace Modeler.SequenceModel.Tests.Sample.Views;

public class PlantUmlSequenceDiagramViewTranslator : IPlantUmlSequenceDiagramViewTranslator
{
    public string TranslateMessageParameters(MessageParameters messageParameters)
    {
        if (messageParameters is NoMessageParameters)
        {
            return "()";
        }
        
        if (messageParameters is StringMessageParameter stringMessageParameter)
        {
            return $"({stringMessageParameter.Name})";
        }
        
        throw new ArgumentException($"Invalid message parameter type {messageParameters.GetType()}");
    }

    public string TranslateParticipantType(ParticipantType participantType)
    {
        return participantType switch
        {
            Actor => "actor",
            Database => "database",
            _ => "participant"
        };
    }

    public string TranslateParticipantStereoType(ParticipantType participantType)
    {
        return participantType switch
        {
            Actor => "Actor",
            Database => "Database",
            System => "System",
            _ => throw new ArgumentException($"Invalid participant type {participantType}")
        };
    }
}