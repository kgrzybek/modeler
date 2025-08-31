using Models.Elements;

namespace Modeler.SequenceModel.Participants;

public interface ISequenceParticipant : IElement
{
    public ParticipantType ParticipantType { get; }
}