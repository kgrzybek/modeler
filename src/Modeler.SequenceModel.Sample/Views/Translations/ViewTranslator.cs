using Modeler.SequenceModel.Sample.Models.Parameters;
using Modeler.SequenceModel.Sample.Models.ParticipantTypes;
using Modeler.SequenceModel.Views.Shared;

namespace Modeler.SequenceModel.Sample.Views.Translations;

public class SequenceDiagramViewTranslator : ISequenceDiagramViewTranslator
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
            Models.ParticipantTypes.System => "System",
            ExternalSystem => "ExternalSystem",
            _ => throw new ArgumentException($"Invalid participant type {participantType}")
        };
    }
}