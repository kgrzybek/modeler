using Modeler.Models.Common;
using Modeler.Models.Sequence.Participants;
using Modeler.Views.Common;

namespace Modeler.Views.Sequence.Diagram.Shared;

public abstract class SequenceDiagramView : IView
{
    protected SequenceDiagramView(
        Models.Sequence.Sequences.Sequence sequence,
        bool autonumberMessages = false)
    {
        Sequence = sequence;
        AutonumberMessages = autonumberMessages;
    }

    public Models.Sequence.Sequences.Sequence Sequence { get; }
    
    public bool AutonumberMessages { get; }

    public List<ISequenceParticipant> ParticipantsToShow { get; protected set; }
}