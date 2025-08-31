using Modeler.Models.Common.Elements;
using Modeler.Models.Common.Models;
using Modeler.Models.Sequence.Participants;

namespace Modeler.Models.Sequence;

public abstract class SequencesModel : IModel
{
    private readonly List<ISequenceParticipant> _participants;

    private readonly List<Sequences.Sequence> _sequences;

    protected SequencesModel(ModelElementsRegistry elementsRegistry)
    {
        _participants = elementsRegistry.GetElements<ISequenceParticipant>().ToList();
        _sequences = elementsRegistry.GetElements<Sequences.Sequence>().ToList();
    }
    
    public Sequences.Sequence GetSequence<T>() where T: Sequences.Sequence
    {
        var type = _sequences.OfType<T>().SingleOrDefault();
        
        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }

    public ISequenceParticipant GetParticipant<T>() where T: ISequenceParticipant
    {
        var type = _participants.OfType<T>().SingleOrDefault();
        
        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }
}