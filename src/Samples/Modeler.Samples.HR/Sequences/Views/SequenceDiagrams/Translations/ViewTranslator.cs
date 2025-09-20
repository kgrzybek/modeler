using Modeler.Models.Sequence.Participants;
using Modeler.Samples.HR.Sequences.ParticipantTypes;
using Modeler.Views.Sequence.Diagram.Shared;

namespace Modeler.Samples.HR.Sequences.Views.SequenceDiagrams.Translations;

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