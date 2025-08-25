using Modeler.SequenceModel.Participants;
using Modeler.SequenceModel.Sample.Models.ParticipantTypes;
using Modeler.SequenceModel.Views.Shared;

namespace Modeler.SequenceModel.Sample.Views.Translations;

public class SequenceDiagramViewTranslator : ISequenceDiagramViewTranslator
{
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
            Application => "Application",
            ExternalSystem => "ExternalSystem",
            _ => throw new ArgumentException($"Invalid participant type {participantType}")
        };
    }
}