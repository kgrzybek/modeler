using System.Reflection;

namespace Modeler.SequenceModel;

public abstract class Model
{
    private List<Participant> _participants;

    private readonly List<Sequence> _sequences;
    
    private readonly List<ParticipantType> _participantTypes;

    protected Model()
    {
        _participants = new List<Participant>();
        _participantTypes = new List<ParticipantType>();
        _sequences = new List<Sequence>();
        RegisterTypes<ParticipantType>();
        RegisterParticipants();
        InitializeSequences();
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

    public List<Participant> GetParticipants()
    {
        return _participants.ToList();
    }

    public Participant GetParticipant<T>() where T: Participant
    {
        var type = _participants.OfType<T>().SingleOrDefault();
        
        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }

    public void AddSequence(Sequence sequence)
    {
        _sequences.Add(sequence);
    }

    private void InitializeSequences()
    {
        var assembly = Assembly.GetAssembly(this.GetType())!;
        var types = assembly
            .GetTypes()
            .Where(t =>
                typeof(Sequence).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                staticMethod.Invoke(null, new object?[]{ this });
            }
        }
    }

    private void RegisterParticipants()
    {
        var assembly = Assembly.GetAssembly(this.GetType());
        _participants = new List<Participant>();
        var types = assembly!
            .GetTypes()
            .Where(t =>
                typeof(Participant).IsAssignableFrom(t))
            .ToList();
        
        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var entity = staticMethod.Invoke(null, null);
                _participants.Add((Participant) entity!);
            }
        }
    }
    
    private void RegisterTypes<T>() where T: ParticipantType
    {
        var assembly = Assembly.GetAssembly(this.GetType());
        
        var types = assembly!
            .GetTypes()
            .Where(t =>
                typeof(T).IsAssignableFrom(t))
            .ToList();
        
        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var entity = staticMethod.Invoke(null, null);
                _participantTypes.Add((T) entity!);
            }
        }
    }
}