using Modeler.SequenceModel.Participants;
using Models.Elements;

namespace Modeler.Views.Sequence.Diagram.Shared;

public abstract class SequenceDiagramView : IView
{
    protected SequenceDiagramView(
        SequenceModel.Sequences.Sequence sequence,
        bool autonumberMessages = false)
    {
        Sequence = sequence;
        AutonumberMessages = autonumberMessages;
    }

    public SequenceModel.Sequences.Sequence Sequence { get; }
    
    public bool AutonumberMessages { get; }

    public List<ISequenceParticipant> ParticipantsToShow { get; protected set; }
}