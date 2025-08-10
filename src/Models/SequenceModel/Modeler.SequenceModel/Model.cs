using Models.Elements;

namespace Modeler.SequenceModel;

public abstract class Model : IModel
{
    private List<ISequenceParticipant> _participants;

    private readonly List<Sequence> _sequences;

    protected Model(ModelElementsRegistry elementsRegistry)
    {
        _participants = elementsRegistry.GetElements<ISequenceParticipant>().ToList();
        _sequences = elementsRegistry.GetElements<Sequence>().ToList();
    }
    
    public List<Sequence> GetSequences() => _sequences;
    
    public Sequence GetSequence<T>() where T: Sequence
    {
        var type = _sequences.OfType<T>().SingleOrDefault();
        
        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }

    public List<ISequenceParticipant> GetParticipants()
    {
        return _participants.ToList();
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