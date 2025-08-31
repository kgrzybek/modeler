using Modeler.SequenceModel.Participants;
using Modeler.SequenceModel.Sequences;
using Models.Elements;

namespace Modeler.SequenceModel;

public abstract class SequencesModel : IModel
{
    private readonly List<ISequenceParticipant> _participants;

    private readonly List<Sequence> _sequences;

    protected SequencesModel(ModelElementsRegistry elementsRegistry)
    {
        _participants = elementsRegistry.GetElements<ISequenceParticipant>().ToList();
        _sequences = elementsRegistry.GetElements<Sequence>().ToList();
    }
    
    public Sequence GetSequence<T>() where T: Sequence
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