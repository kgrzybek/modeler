using Models.Elements;

namespace Modeler.SequenceModel;

public interface ISequenceParticipant : IElement
{
    public ParticipantType ParticipantType { get; }
}