using Modeler.SequenceModel.Participants;
using Modeler.SequenceModel.Sequences;
using Models.Elements;

namespace Modeler.SequenceModel.Views.Shared;

public abstract class SequenceDiagramView : IView
{
    protected SequenceDiagramView(
        Sequence sequence,
        bool autonumberMessages = false)
    {
        Sequence = sequence;
        AutonumberMessages = autonumberMessages;
    }

    public Sequence Sequence { get; }
    
    public bool AutonumberMessages { get; }

    public List<ISequenceParticipant> ParticipantsToShow { get; protected set; }
}