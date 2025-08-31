using Modeler.Models.Common.Elements;

namespace Modeler.Models.Sequence.Participants;

public interface ISequenceParticipant : IElement
{
    public ParticipantType ParticipantType { get; }
}